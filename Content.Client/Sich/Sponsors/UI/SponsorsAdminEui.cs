using Content.Client.Administration.Managers;
using Content.Client.Eui;
using Content.Client.Stylesheets;
using Content.Shared.Eui;
using Content.Shared.Sich.Sponsors;
using JetBrains.Annotations;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using Robust.Shared.Utility;
using System.Linq;
using System.Numerics;
using static Content.Shared.Sich.Sponsors.SponsorsEuiMsg;
using static Robust.Client.UserInterface.Controls.BoxContainer;

namespace Content.Client.Sich.Sponsors.UI;

[UsedImplicitly]
public sealed partial class SponsorsAdminEui : BaseEui
{
    private const int NoRank = -1;

    private readonly Menu _menu;
    private readonly List<DefaultWindow> _subWindows = new();

    private Dictionary<int, SponsorsEuiState.SponsorRankData> _ranks =
        new();

    public SponsorsAdminEui()
    {
        IoCManager.InjectDependencies(this);

        _menu = new Menu(this);
        _menu.AddSponsorButton.OnPressed += AddSponsorPressed;
        _menu.AddSponsorRankButton.OnPressed += AddSponsorRankPressed;
        _menu.OnClose += CloseEverything;
    }

    public override void Closed()
    {
        base.Closed();

        SendMessage(new CloseEuiMessage());
        CloseEverything();
    }

    private void CloseEverything()
    {
        foreach (var subWindow in _subWindows.ToArray())
        {
            subWindow.Close();
        }

        _menu.Close();
    }

    private void AddSponsorPressed(BaseButton.ButtonEventArgs obj)
    {
        OpenEditWindow(null);
    }

    private void AddSponsorRankPressed(BaseButton.ButtonEventArgs obj)
    {
        OpenRankEditWindow(null);
    }


    private void OnEditPressed(SponsorsEuiState.SponsorData sponsor)
    {
        OpenEditWindow(sponsor);
    }

    private void OpenEditWindow(SponsorsEuiState.SponsorData? data)
    {
        var window = new EditSponsorWindow(this, data);
        window.SaveButton.OnPressed += _ => SaveSponsorPressed(window);
        window.OpenCentered();
        window.OnClose += () => _subWindows.Remove(window);
        if (data != null)
        {
            window.RemoveButton!.OnPressed += _ => RemoveButtonPressed(window);
        }

        _subWindows.Add(window);
    }


    private void OpenRankEditWindow(KeyValuePair<int, SponsorsEuiState.SponsorRankData>? rank)
    {
        var window = new EditSponsorRankWindow(this, rank);
        window.SaveButton.OnPressed += _ => SaveSponsorRankPressed(window);
        window.OpenCentered();
        window.OnClose += () => _subWindows.Remove(window);
        if (rank != null)
        {
            window.RemoveButton!.OnPressed += _ => RemoveRankButtonPressed(window);
        }

        _subWindows.Add(window);
    }

    private void RemoveButtonPressed(EditSponsorWindow window)
    {
        SendMessage(new RemoveSponsor { UserId = window.SourceData!.Value.UserId });

        window.Close();
    }

    private void RemoveRankButtonPressed(EditSponsorRankWindow window)
    {
        SendMessage(new RemoveSponsorRank { Id = window.SourceId!.Value });

        window.Close();
    }

    private void SaveSponsorPressed(EditSponsorWindow popup)
    {
        int? rank = popup.RankButton.SelectedId;
        if (rank == NoRank)
        {
            rank = null;
        }

        var title = string.IsNullOrWhiteSpace(popup.TitleEdit.Text) ? null : popup.TitleEdit.Text;

        if (popup.SourceData is { } src)
        {
            SendMessage(new UpdateSponsor
            {
                UserId = src.UserId,
                RankId = rank
            });
        }
        else
        {
            DebugTools.AssertNotNull(popup.NameEdit);

            SendMessage(new AddSponsor
            {
                UserNameOrId = popup.NameEdit!.Text,
                RankId = rank
            });
        }

        popup.Close();
    }


    private void SaveSponsorRankPressed(EditSponsorRankWindow popup)
    {
        var name = popup.NameEdit.Text;

        if (popup.SourceId is { } src)
        {
            SendMessage(new UpdateSponsorRank
            {
                Id = src,
                Name = name,
                Color = popup.ColorEdit.Color
            });
        }
        else
        {
            SendMessage(new AddSponsorRank
            {
                Name = name,
                Color = popup.ColorEdit.Color
            });
        }

        popup.Close();
    }

    public override void Opened()
    {
        _menu.OpenCentered();
    }

    public override void HandleState(EuiStateBase state)
    {
        var s = (SponsorsEuiState)state;

        if (s.IsLoading)
        {
            return;
        }

        _ranks = s.SponsorRanks;

        _menu.SponsorsList.RemoveAllChildren();
        foreach (var sponsor in s.Sponsors.OrderBy(d => d.UserName))
        {
            var al = _menu.SponsorsList;
            var name = sponsor.UserName ?? sponsor.UserId.ToString();

            var nameLabel = new Label { Text = name };

            al.AddChild(nameLabel);


            bool italic;
            string rank;
            Color rankColor;
            if (sponsor.RankId is { } rankId)
            {
                italic = false;
                var rankData = s.SponsorRanks[rankId];
                rank = rankData.Name;
                rankColor = rankData.Color;
            }
            else
            {
                italic = true;
                rank = Loc.GetString("sponsors-eui-edit-no-rank-text").ToLowerInvariant();
                rankColor = Color.White;
            }

            var rankControl = new Label { Text = rank };
            rankControl.HorizontalAlignment = Control.HAlignment.Center;
            rankControl.HorizontalExpand = true;

            if (italic)
            {
                rankControl.StyleClasses.Add(StyleClass.Italic);
            }

            rankControl.FontColorOverride = rankColor;
            nameLabel.FontColorOverride = rankColor;

            al.AddChild(rankControl);

            var editButton = new Button { Text = Loc.GetString("sponsors-eui-edit-title-button") };
            editButton.OnPressed += _ => OnEditPressed(sponsor);
            al.AddChild(editButton);
        }

        _menu.SponsorsRanksList.RemoveAllChildren();
        foreach (var kv in s.SponsorRanks)
        {
            var rank = kv.Value;
            _menu.SponsorsRanksList.AddChild(new Label { Text = rank.Name, FontColorOverride = rank.Color });
            var editButton = new Button { Text = Loc.GetString("sponsors-eui-edit-sponsor-rank-button") };
            editButton.OnPressed += _ => OnEditRankPressed(kv);
            _menu.SponsorsRanksList.AddChild(editButton);
        }
    }

    private void OnEditRankPressed(KeyValuePair<int, SponsorsEuiState.SponsorRankData> rank)
    {
        OpenRankEditWindow(rank);
    }

    private sealed class Menu : DefaultWindow
    {
        private readonly SponsorsAdminEui _ui;
        public readonly GridContainer SponsorsList;
        public readonly GridContainer SponsorsRanksList;
        public readonly Button AddSponsorButton;
        public readonly Button AddSponsorRankButton;

        public Menu(SponsorsAdminEui ui)
        {
            _ui = ui;
            Title = Loc.GetString("sponsors-eui-menu-title");

            var tab = new TabContainer();

            AddSponsorButton = new Button
            {
                Text = Loc.GetString("sponsors-eui-menu-add-sponsor-button"),
                HorizontalAlignment = HAlignment.Right
            };

            AddSponsorRankButton = new Button
            {
                Text = Loc.GetString("sponsors-eui-menu-add-sponsor-rank-button"),
                HorizontalAlignment = HAlignment.Right
            };

            SponsorsList = new GridContainer { Columns = 3, VerticalExpand = true };
            var adminVBox = new BoxContainer
            {
                Orientation = LayoutOrientation.Vertical,
                Children = { new ScrollContainer() { VerticalExpand = true, Children = { SponsorsList } }, AddSponsorButton },
            };
            TabContainer.SetTabTitle(adminVBox, Loc.GetString("sponsors-eui-menu-sponsors-tab-title"));

            SponsorsRanksList = new GridContainer { Columns = 2, VerticalExpand = true };
            var rankVBox = new BoxContainer
            {
                Orientation = LayoutOrientation.Vertical,
                Children = { new ScrollContainer() { VerticalExpand = true, Children = { SponsorsRanksList } }, AddSponsorRankButton }
            };
            TabContainer.SetTabTitle(rankVBox, Loc.GetString("sponsors-eui-menu-sponsor-ranks-tab-title"));

            tab.AddChild(adminVBox);
            tab.AddChild(rankVBox);

            Contents.AddChild(tab);
        }

        protected override Vector2 ContentsMinimumSize => new Vector2(600, 400);
    }

    private sealed class EditSponsorWindow : DefaultWindow
    {
        public readonly SponsorsEuiState.SponsorData? SourceData;
        public readonly LineEdit? NameEdit;
        public readonly LineEdit TitleEdit;
        public readonly OptionButton RankButton;
        public readonly Button SaveButton;
        public readonly Button? RemoveButton;

        public EditSponsorWindow(SponsorsAdminEui ui, SponsorsEuiState.SponsorData? data)
        {
            MinSize = new Vector2(600, 400);
            SourceData = data;

            Control nameControl;

            if (data is { } dat)
            {
                var name = dat.UserName ?? dat.UserId.ToString();
                Title = Loc.GetString("sponsors-eui-edit-sponsor-window-edit-sponsor-label",
                                      ("sponsor", name));

                nameControl = new Label { Text = name };
            }
            else
            {
                Title = Loc.GetString("sponsors-eui-menu-add-sponsor-button");

                nameControl = NameEdit = new LineEdit { PlaceHolder = Loc.GetString("sponsors-eui-edit-sponsor-window-name-edit-placeholder") };
            }

            TitleEdit = new LineEdit { PlaceHolder = Loc.GetString("sponsors-eui-edit-sponsor-window-title-edit-placeholder") };
            RankButton = new OptionButton();
            SaveButton = new Button { Text = Loc.GetString("sponsors-eui-edit-sponsor-window-save-button"), HorizontalAlignment = HAlignment.Right };

            RankButton.AddItem(Loc.GetString("sponsors-eui-edit-sponsor-window-no-rank-button"), NoRank);
            foreach (var (rId, rank) in ui._ranks)
            {
                RankButton.AddItem(rank.Name, rId);
            }

            RankButton.SelectId(data?.RankId ?? NoRank);
            RankButton.OnItemSelected += RankSelected;

            var permGrid = new GridContainer
            {
                Columns = 4,
                HSeparationOverride = 0,
                VSeparationOverride = 0
            };

            var bottomButtons = new BoxContainer
            {
                Orientation = LayoutOrientation.Horizontal
            };
            if (data != null)
            {
                // show remove button.
                RemoveButton = new Button { Text = Loc.GetString("sponsors-eui-edit-sponsor-window-remove-flag-button") };
                bottomButtons.AddChild(RemoveButton);
            }

            bottomButtons.AddChild(SaveButton);

            Contents.AddChild(new BoxContainer
            {
                Orientation = LayoutOrientation.Vertical,
                Children =
                    {
                        new BoxContainer
                        {
                            Orientation = LayoutOrientation.Horizontal,
                            SeparationOverride = 2,
                            Children =
                            {
                                new BoxContainer
                                {
                                    Orientation = LayoutOrientation.Vertical,
                                    HorizontalExpand = true,
                                    Children =
                                    {
                                        nameControl,
                                        TitleEdit,
                                        RankButton,
                                    }
                                },
                                permGrid
                            },
                            VerticalExpand = true
                        },
                        bottomButtons
                    }
            });
        }

        private void RankSelected(OptionButton.ItemSelectedEventArgs obj)
        {
            RankButton.SelectId(obj.Id);
        }
    }

    private sealed class EditSponsorRankWindow : DefaultWindow
    {
        public readonly int? SourceId;
        public readonly LineEdit NameEdit;
        public readonly ColorSelectorSliders ColorEdit;
        public readonly Button SaveButton;
        public readonly Button? RemoveButton;
        public readonly Label Label;

        public EditSponsorRankWindow(SponsorsAdminEui ui, KeyValuePair<int, SponsorsEuiState.SponsorRankData>? data)
        {
            Title = Loc.GetString("sponsors-eui-edit-sponsor-rank-window-title");
            MinSize = new Vector2(600, 400);
            SourceId = data?.Key;

            NameEdit = new LineEdit
            {
                PlaceHolder = Loc.GetString("sponsors-eui-edit-sponsor-rank-window-name-edit-placeholder"),
            };

            if (data != null)
            {
                NameEdit.Text = data.Value.Value.Name;
            }

            Label = new Label
            {
                Text = $"{Loc.GetString("sponsors-eui-edit-sponsor-rank-window-color-label")}",
                HorizontalAlignment = HAlignment.Center,
                HorizontalExpand = true,
            };

            ColorEdit = new ColorSelectorSliders
            {
                Color = data?.Value.Color ?? Color.White,
                HorizontalExpand = true,
                SelectorType = ColorSelectorSliders.ColorSelectorType.Hsv
            };

            ColorEdit.OnColorChanged += col =>
            {
                Label.FontColorOverride = col;
            };


            SaveButton = new Button
            {
                Text = Loc.GetString("sponsors-eui-menu-save-sponsor-rank-button"),
                HorizontalAlignment = HAlignment.Right,
                HorizontalExpand = true,
            };

            var bottomButtons = new BoxContainer
            {
                Orientation = LayoutOrientation.Horizontal
            };
            if (data != null)
            {
                // show remove button.
                RemoveButton = new Button { Text = Loc.GetString("sponsors-eui-menu-remove-sponsor-rank-button") };
                bottomButtons.AddChild(RemoveButton);
            }

            bottomButtons.AddChild(SaveButton);

            Contents.AddChild(new BoxContainer
            {
                Orientation = LayoutOrientation.Vertical,
                Children =
                    {
                        NameEdit,
                        Label,
                        ColorEdit,
                        bottomButtons
                    }
            });
        }
    }
}
