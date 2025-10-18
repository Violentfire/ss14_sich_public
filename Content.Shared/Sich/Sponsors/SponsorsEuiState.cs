using Content.Shared.Administration;
using Content.Shared.Eui;
using Robust.Shared.Network;
using Robust.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Shared.Sich.Sponsors;

[Serializable, NetSerializable]
public sealed class SponsorsEuiState : EuiStateBase
{
    public bool IsLoading;

    public SponsorData[] Sponsors = Array.Empty<SponsorData>();
    public Dictionary<int, SponsorRankData> SponsorRanks = new();

    [Serializable, NetSerializable]
    public struct SponsorData
    {
        public NetUserId UserId;
        public string? UserName;
        public int? RankId;
    }

    [Serializable, NetSerializable]
    public struct SponsorRankData
    {
        public string Name;
        public Color Color;
    }
}

public static class SponsorsEuiMsg
{
    [Serializable, NetSerializable]
    public sealed class AddSponsor : EuiMessageBase
    {
        public string UserNameOrId = string.Empty;
        public int? RankId;
    }

    [Serializable, NetSerializable]
    public sealed class RemoveSponsor : EuiMessageBase
    {
        public NetUserId UserId;
    }

    [Serializable, NetSerializable]
    public sealed class UpdateSponsor : EuiMessageBase
    {
        public NetUserId UserId;
        public int? RankId;
    }


    [Serializable, NetSerializable]
    public sealed class AddSponsorRank : EuiMessageBase
    {
        public string Name = string.Empty;
        public Color Color = Color.White;
    }

    [Serializable, NetSerializable]
    public sealed class RemoveSponsorRank : EuiMessageBase
    {
        public int Id;
    }

    [Serializable, NetSerializable]
    public sealed class UpdateSponsorRank : EuiMessageBase
    {
        public int Id;

        public string Name = string.Empty;
        public Color Color = Color.White;
    }
}

public sealed class RequestSponsorWindowMessage : EntityEventArgs
{
}
