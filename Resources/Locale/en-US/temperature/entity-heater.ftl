-entity-heater-setting-name =
    { $setting ->
        [off] вимк
        [low] низький
        [medium] середній
        [high] високий
       *[other] невідомо
    }

entity-heater-examined = It is set to { $setting ->
    [off] [color=gray]{ -entity-heater-setting-name(setting: "off") }[/color]
    [low] [color=yellow]{ -entity-heater-setting-name(setting: "low") }[/color]
    [medium] [color=orange]{ -entity-heater-setting-name(setting: "medium") }[/color]
    [high] [color=red]{ -entity-heater-setting-name(setting: "high") }[/color]
   *[other] [color=purple]{ -entity-heater-setting-name(setting: "other") }[/color]
}.
entity-heater-switch-setting = Змінити на { -entity-heater-setting-name(setting: $setting) }
entity-heater-switched-setting = Змінено на { -entity-heater-setting-name(setting: $setting) }.
