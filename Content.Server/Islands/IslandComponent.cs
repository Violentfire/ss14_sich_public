// author: https://gitlab.com/Drakoriss
// license: MIT
namespace Content.Server.Islands;

[RegisterComponent]
[Access(typeof(IslandsSystem))]
public sealed partial class IslandComponent : Component
{
    [ViewVariables]
    public bool StartedUp { get; set; } = false;
}
