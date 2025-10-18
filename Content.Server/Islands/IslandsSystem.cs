// author: https://gitlab.com/Drakoriss
// license: MIT
using Content.Server.Gravity;
using Content.Server.Shuttles.Components;
using Content.Server.Shuttles.Systems;

namespace Content.Server.Islands;

public sealed class IslandsSystem : EntitySystem
{
    [Dependency] private readonly ShuttleSystem _shuttleSystem = default!;
    [Dependency] private readonly GravitySystem _gravitySystem = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<IslandComponent, MapInitEvent>(OnMapInit);
        SubscribeLocalEvent<IslandComponent, ComponentStartup>(OnCompStartup);
        SubscribeLocalEvent<IslandComponent, ComponentShutdown>(OnCompShutdown);
    }

    private void OnMapInit(Entity<IslandComponent> ent, ref MapInitEvent args)
    {
        if (ent.Comp.StartedUp)
            return;

        var transform = Transform(ent);
        var grid = transform.GridUid;

        if (!grid.HasValue)
            return;

        SetStatus(grid.Value, true);
    }

    private void OnCompStartup(EntityUid uid, IslandComponent comp, ComponentStartup args)
    {
        if (comp.StartedUp)
            return;

        SetStatus(uid, true);
    }

    private void OnCompShutdown(EntityUid uid, IslandComponent comp, ComponentShutdown args)
    {
        if (EntityManager.GetComponent<MetaDataComponent>(uid).EntityLifeStage >= EntityLifeStage.Terminating)
            return;

        SetStatus(uid, false);
    }

    private void SetStatus(EntityUid gridUid, bool enabled, ShuttleComponent? shuttleComponent = default)
    {
        if (!Resolve(gridUid, ref shuttleComponent))
            return;

        if (!TryComp(gridUid, out IslandComponent? islandComponent))
            return;

        if (enabled)
        {
            _shuttleSystem.Disable(gridUid);
            _gravitySystem.EnableGravity(gridUid);
        }
        else
        {
            _shuttleSystem.Enable(gridUid);
            _gravitySystem.RefreshGravity(gridUid);
        }

        shuttleComponent.Enabled = !enabled;
        islandComponent.StartedUp = enabled;
    }
}
