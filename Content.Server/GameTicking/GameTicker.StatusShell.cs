using Content.Shared.CCVar;
using Content.Shared.GameTicking;
using Robust.Server.ServerStatus;
using Robust.Shared.Configuration;
using System;
using System.Globalization;
using System.Linq;
using System.Text.Json.Nodes;

namespace Content.Server.GameTicking
{
    public sealed partial class GameTicker
    {
        /// <summary>
        ///     Used for thread safety, given <see cref="IStatusHost.OnStatusRequest"/> is called from another thread.
        /// </summary>
        private readonly object _statusShellLock = new();

        /// <summary>
        ///     Round start time in UTC, for status shell purposes.
        /// </summary>
        [ViewVariables]
        private DateTime _roundStartDateTime;

        /// <summary>
        ///     For access to CVars in status responses.
        /// </summary>
        [Dependency] private readonly IConfigurationManager _cfg = default!;
        /// <summary>
        ///     For access to the round ID in status responses.
        /// </summary>
        [Dependency] private readonly SharedGameTicker _gameTicker = default!;


        private static readonly string[] ClockEmojis = new string[]
        {
            "🕛", // 0 хв
            "🕧", // 2,5 хв
            "🕐", // 5 хв
            "🕜", // 7,5 хв
            "🕑", // 10 хв
            "🕝", // 12,5 хв
            "🕒", // 15 хв
            "🕞", // 17,5 хв
            "🕓", // 20 хв
            "🕟", // 22,5 хв
            "🕔", // 25 хв
            "🕠", // 27,5 хв
            "🕕", // 30 хв
            "🕡", // 32,5 хв
            "🕖", // 35 хв
            "🕢", // 37,5 хв
            "🕗", // 40 хв
            "🕣", // 42,5 хв
            "🕘", // 45 хв
            "🕤", // 47,5 хв
            "🕙", // 50 хв
            "🕥", // 52,5 хв
            "🕚", // 55 хв
            "🕦"  // 57,5 хв
        };

        private void InitializeStatusShell()
        {
            IoCManager.Resolve<IStatusHost>().OnStatusRequest += GetStatusResponse;
        }

        private void GetStatusResponse(JsonNode jObject)
        {
            var preset = CurrentPreset ?? Preset;

            // This method is raised from another thread, so this better be thread safe!
            lock (_statusShellLock)
            {
                jObject["name"] = GetServerName();
                jObject["map"] = _gameMapManager.GetSelectedMap()?.MapName;
                jObject["round_id"] = _gameTicker.RoundId;
                jObject["players"] = _cfg.GetCVar(CCVars.AdminsCountInReportedPlayerCount)
                    ? GetFakePlayers()
                    : GetFakePlayers() - _adminManager.ActiveAdmins.Count();
                jObject["soft_max_players"] = _cfg.GetCVar(CCVars.SoftMaxPlayers);
                jObject["panic_bunker"] = _cfg.GetCVar(CCVars.PanicBunkerEnabled);
                jObject["run_level"] = (int)_runLevel;
                if (preset != null)
                    jObject["preset"] = (Decoy == null) ? Loc.GetString(preset.ModeTitle) : Loc.GetString(Decoy.ModeTitle);
                if (_runLevel >= GameRunLevel.InRound)
                {
                    jObject["round_start_time"] = _roundStartDateTime.ToString("o");
                }
            }

            string GetServerName()
            {

                var newServerName = $"{_baseServer.ServerName}";
                var map = _gameMapManager.GetSelectedMap();
                if (map != null)
                    newServerName += $" | 🗺️ {map.MapName}";

                var preset = CurrentPreset ?? Preset;
                if (preset != null)
                    newServerName += $" | 🎲 {Loc.GetString(preset.ModeTitle)}";

                newServerName += $" | раунд №{_gameTicker.RoundId}";

                return newServerName;
            }
        }

        private int GetFakePlayers()
        {
            int result = 0;
            var playerFakeMaxCount = _cfg.GetCVar(CCVars.MaxFakePlayerCount);
            float coefFakePlayers = Math.Max(1, _cfg.GetCVar(CCVars.FakePlayerCoef));
            var playerFakeLimiter = Math.Min((int)(_playerManager.PlayerCount * coefFakePlayers), playerFakeMaxCount);
            result = Math.Max(playerFakeLimiter, _playerManager.PlayerCount);
            return result;
        }
        private static string GetClockEmojiTime(DateTime start)
        {
            TimeSpan diff = DateTime.UtcNow - start;
            if (diff < TimeSpan.Zero)
            {
                diff = TimeSpan.Zero;
            }
            int hours = (int)diff.TotalHours;
            int minutes = diff.Minutes;
            int seconds = diff.Seconds;
            double fractionalMinutes = diff.TotalMinutes % 60.0;
            int emojiIndex = (int)Math.Floor(fractionalMinutes / 2.5);

            string clockEmoji = ClockEmojis[emojiIndex];

            string result = $"{clockEmoji} {hours:D2}:{minutes:D2}:{seconds:D2}";

            return result;
        }
    }
}
