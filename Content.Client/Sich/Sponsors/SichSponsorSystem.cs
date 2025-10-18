using Content.Shared.Sich.Sponsors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Client.Sich.Sponsors;
public sealed partial class SichSponsorSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();
    }

    public void RequestSponsorWindow()
    {
        RaiseNetworkEvent(new RequestSponsorWindowMessage());
    }
}
