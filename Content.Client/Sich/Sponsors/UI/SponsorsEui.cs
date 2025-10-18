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
public sealed partial class SponsorsEui : BaseEui
{
    private const int NoRank = -1;

    private readonly Menu _menu;
    private readonly List<DefaultWindow> _subWindows = new();

    private Dictionary<int, SponsorsEuiState.SponsorRankData> _ranks =
        new();

    public SponsorsEui()
    {
        IoCManager.InjectDependencies(this);

        _menu = new Menu(this);
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

    public override void Opened()
    {
        _menu.OpenCentered();
    }

    public override void HandleState(EuiStateBase state)
    {
        var s = (SponsorsEuiState)state;

        if (s.IsLoading)
            return;

        _ranks = s.SponsorRanks;

        _menu.SponsorsList.RemoveAllChildren();

        // Групування спонсорів за RankId
        var groupedSponsors = s.Sponsors
            .GroupBy(sp => sp.RankId) // RankId може бути null
            .OrderBy(g =>
            {
                // Для null-рангу ставимо найнижчий пріоритет
                if (g.Key == null) return int.MaxValue;
                return g.Key.Value;
            });

        foreach (var group in groupedSponsors)
        {
            string groupName;
            Color groupColor;

            if (group.Key is { } rankId && s.SponsorRanks.TryGetValue(rankId, out var rank))
            {
                groupName = rank.Name;
                groupColor = rank.Color;
            }
            else
            {
                groupName = Loc.GetString("sponsors-eui-edit-no-rank-text").ToLowerInvariant();
                groupColor = Color.White;
            }

            // Додаємо заголовок групи
            var header = new Label
            {
                Text = groupName,
                FontColorOverride = groupColor,
                StyleClasses = { StyleBase.StyleClassLabelHeading }
            };
            _menu.SponsorsList.AddChild(header);

            // Відсортовані учасники групи
            foreach (var sponsor in group.OrderBy(sp => sp.UserName))
            {
                var name = sponsor.UserName ?? sponsor.UserId.ToString();
                var nameLabel = new Label { Text = name, FontColorOverride = groupColor };

                var rankLabel = new Label
                {
                    Text = groupName,
                    FontColorOverride = groupColor,
                    HorizontalAlignment = Control.HAlignment.Center,
                    HorizontalExpand = true
                };

                if (sponsor.RankId == null)
                    rankLabel.StyleClasses.Add(StyleBase.StyleClassItalic);

                _menu.SponsorsList.AddChild(nameLabel);
                //_menu.SponsorsList.AddChild(rankLabel);
            }
        }
    }

    private sealed class Menu : DefaultWindow
    {
        private readonly SponsorsEui _ui;
        public readonly GridContainer SponsorsList;

        public Menu(SponsorsEui ui)
        {
            _ui = ui;
            Title = Loc.GetString("sponsors-eui-menu-title");

            var tab = new TabContainer();

            SponsorsList = new GridContainer { Columns = 1, VerticalExpand = true };
            var adminVBox = new BoxContainer
            {
                Orientation = LayoutOrientation.Vertical,
                Children = { new ScrollContainer() { VerticalExpand = true, Children = { SponsorsList } } },
            };
            TabContainer.SetTabTitle(adminVBox, Loc.GetString("sponsors-eui-menu-sponsors-tab-title"));

            tab.AddChild(adminVBox);

            Contents.AddChild(tab);
        }

        protected override Vector2 ContentsMinimumSize => new Vector2(600, 400);
    }
}
