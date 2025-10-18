using Content.Client.Administration.UI.CustomControls;
using Content.Shared.CrewManifest;
using Content.Shared.Eui;
using Microsoft.CodeAnalysis;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.GameObjects;

namespace Content.Client.Sich.Sponsors.UI;

public sealed class SichSponsorInfoBanner : BoxContainer
{
    public SichSponsorInfoBanner()
    {
        var buttons = new BoxContainer
        {
            Orientation = LayoutOrientation.Horizontal
        };
        AddChild(buttons);

        var creditsButton = new CommandButton { Text = Loc.GetString("sponsors-open-panel") };
        creditsButton.Command = "sponsorwindow";
        buttons.AddChild(creditsButton);
    }
}

