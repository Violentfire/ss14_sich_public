lathe-menu-title = Меню верстата
lathe-menu-queue = Черга
lathe-menu-server-list = Список серверів
lathe-menu-sync = Синх
lathe-menu-search-designs = Пошук креслень
lathe-menu-category-all = Всі
lathe-menu-search-filter = Фільтри:
lathe-menu-amount = Кількість:
lathe-menu-recipe-count = { $count ->
    [1] {$count} рецепт
    *[other] рецептів: {$count} шт.
}
lathe-menu-reagent-slot-examine = Збоку є гніздо для мензурки.
lathe-reagent-dispense-no-container = Рідина виливається з {THE($name)} на підлогу!
lathe-menu-result-reagent-display = {$reagent} ({$amount}u)
lathe-menu-material-display = {$material} ({$amount})
lathe-menu-tooltip-display = {$amount} {$material}
lathe-menu-description-display = [italic]{$description}[/italic]
lathe-menu-material-amount = { $amount ->
    [1] {NATURALFIXED($amount, 2)} {$unit}
    *[other] {NATURALFIXED($amount, 2)} {MAKEPLURAL($unit)}
}
lathe-menu-material-amount-missing = { $amount ->
    [1] {NATURALFIXED($amount, 2)} {$unit} {$material} ([color=red]{NATURALFIXED($missingAmount, 2)} {$unit} відсутні[/color])
    *[other] {NATURALFIXED($amount, 2)} {MAKEPLURAL($unit)} {$material} ([color=red]{NATURALFIXED($missingAmount, 2)} {MAKEPLURAL($unit)} відсутні[/color])
}
lathe-menu-no-materials-message = Матеріали не завантажені.
lathe-menu-silo-linked-message = Силос підключено
lathe-menu-fabricating-message = Виготовляється...
lathe-menu-materials-title = Матеріали
lathe-menu-queue-title = Черга виготовлення
lathe-menu-delete-fabricating-tooltip = Скасувати друк поточного предмета.
lathe-menu-delete-item-tooltip = Скасувати друк цієї партії.
lathe-menu-move-up-tooltip = Перемістити цю партію вперед у черзі.
lathe-menu-move-down-tooltip = Перемістити цю партію назад у черзі.
lathe-menu-item-single = {$index}. {$name}
lathe-menu-item-batch = {$index}. {$name} ({$printed}/{$total})
