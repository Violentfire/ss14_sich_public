### UI

# Shown when a stack is examined in details range
comp-stack-examine-detail-count = {$count ->
    [one] Тут [color={$markupCountColor}]{$count}[/color] предмет
    *[other] Тут [color={$markupCountColor}]{$count}[/color] предметів
} у стопці.

# Stack status control
comp-stack-status = Кількість: [color=white]{$count}[/color]

### Interaction Messages

# Shown when attempting to add to a stack that is full
comp-stack-already-full = Стопка тепер заповнена.
    
# Shown when a stack becomes full
comp-stack-becomes-full = Стопка вже заповнена.

# Text related to splitting a stack
comp-stack-split = Ти розділив стопку.
comp-stack-split-halve = Навпіл
comp-stack-split-too-small = Стопка занадто мала для розділення
