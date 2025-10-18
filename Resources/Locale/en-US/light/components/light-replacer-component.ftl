
### Interaction Messages

# Shown when player tries to replace light, but there is no lights left
comp-light-replacer-missing-light = Не залишилося жодної лампочки в {$light-replacer}.

# Shown when player inserts light bulb inside light replacer
comp-light-replacer-insert-light = Ти вставляєш {$bulb} в {$light-replacer}.

# Shown when player tries to insert in light replacer brolen light bulb
comp-light-replacer-insert-broken-light = Не можна вставляти розбиті лампочки!

# Shown when player refill light from light box
comp-light-replacer-refill-from-storage = Ти наповнюєш {$light-replacer}.

### Examine 

comp-light-replacer-no-lights = Він порожній.
comp-light-replacer-has-lights = Він містить наступне:
comp-light-replacer-light-listing = {$amount ->
    [one] [color=yellow]{$amount}[/color] [color=gray]{$name}[/color]
    *[other] [color=yellow]{$amount}[/color] [color=gray]{$name}[/color]
}