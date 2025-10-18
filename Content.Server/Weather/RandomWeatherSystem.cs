// author: https://github.com/DrakorissVere
// license: MIT
using Content.Shared.Weather;
using Robust.Server.GameObjects;
using Robust.Shared.Map;
using Robust.Shared.Map.Components;
using Robust.Shared.Prototypes;
using Robust.Shared.Random;
using Robust.Shared.Timing;
using System.Linq;

namespace Content.Server.Weather;

/// <summary>
///     Allows weather effects randomly appear.
/// </summary>
public sealed class RandomWeatherSystem : EntitySystem
{
    [Dependency] protected readonly IGameTiming Timing = default!;
    [Dependency] private readonly IRobustRandom _random = default!;
    [Dependency] private readonly IPrototypeManager _protoMan = default!;
    [Dependency] private readonly ILogManager _logManager = default!;

    [Dependency] private readonly SharedWeatherSystem _weather = default!;
    [Dependency] private readonly MapSystem _mapSystem = default!;

    private ISawmill _sawmill = default!;

    public override void Initialize()
    {
        _sawmill = _logManager.GetSawmill("RandomWeatherSystem");
        SubscribeLocalEvent<RandomWeatherComponent, ComponentInit>(OnComponentInit);
    }

    private void OnComponentInit(EntityUid uid, RandomWeatherComponent comp, ComponentInit args)
    {
        var calmDuration = _random.Next(comp.MinCalmPeriodBetweenWeathers, comp.MaxCalmPeriodBetweenWeathers + 1);
        comp.NextWeatherStart = Timing.CurTime + TimeSpan.FromMinutes(calmDuration);
    }

    public override void Update(float frameTime)
    {
        var curTime = Timing.CurTime;
        var query = EntityQueryEnumerator<RandomWeatherComponent, MapComponent>();

        while (query.MoveNext(out var uid, out var weather, out var mapComp))
        {
            if (weather.NextWeatherStart < curTime)
            {
                var mapId = mapComp.MapId;

                if (!_mapSystem.MapExists(mapId))
                {
                    _sawmill.Warning($"Map with id '{mapId}' not found.");
                    weather.NextWeatherStart = curTime + TimeSpan.FromMinutes(5);
                    continue;
                }

                var chance = weather.AllowedWeather.Values.Sum() * _random.NextFloat();
                var duration = _random.Next(weather.MinWeatherDuration, weather.MaxWeatherDuration + 1);
                var endTime = TimeSpan.FromMinutes(duration) + curTime;
                var calmDuration = _random.Next(weather.MinCalmPeriodBetweenWeathers, weather.MaxCalmPeriodBetweenWeathers + 1);
                var nextCheckTime = endTime + TimeSpan.FromMinutes(calmDuration);

                // Weighted random
                foreach (var w in weather.AllowedWeather)
                {
                    if (chance < w.Value)
                    {
                        if (!_protoMan.TryIndex(w.Key, out var proto))
                        {
                            _sawmill.Warning($"Weather prototype '{w.Key}' not found.");
                            continue;
                        }

                        _weather.SetWeather(mapId, proto, endTime);
                        break;
                    }

                    chance -= w.Value;
                }

                weather.NextWeatherStart = nextCheckTime;
            }
        }
    }
}
