using System.Text.RegularExpressions;
using Content.Server.Speech.Components;
using Content.Shared.Speech;

namespace Content.Server.Speech.EntitySystems;

public sealed class MothAccentSystem : EntitySystem
{
    private static readonly Regex RegexLowerBuzz = new Regex("[zзж]{1,3}");
    private static readonly Regex RegexUpperBuzz = new Regex("[ZЗЖ]{1,3}");

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<MothAccentComponent, AccentGetEvent>(OnAccent);
    }

    private void OnAccent(EntityUid uid, MothAccentComponent component, AccentGetEvent args)
    {
        var message = args.Message;

        // Triple lower-case "z", "з", "ж"
        message = RegexLowerBuzz.Replace(message, match => new string(match.Value[0], 3));

        // Triple upper-case "Z", "З", "Ж"
        message = RegexUpperBuzz.Replace(message, match => new string(match.Value[0], 3));

        args.Message = message;
    }
}
