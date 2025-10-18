contraband-examine-text-Minor =
    { $type ->
        *[item] [color=yellow]Цей предмет вважається дрібною контрабандою.[/color]
        [reagent] [color=yellow]Цей реагент вважається дрібною контрабандою.[/color]
    }

contraband-examine-text-Restricted =
    { $type ->
        *[item] [color=yellow]Цей предмет з обмеженим доступом.[/color]
        [reagent] [color=yellow]Цей реагент з обмеженим доступом.[/color]
    }

contraband-examine-text-Restricted-department =
    { $type ->
        *[item] [color=yellow]Цей предмет обмежений для {$departments}, і може вважатися контрабандою.[/color]
        [reagent] [color=yellow]Цей реагент обмежений для {$departments}, і може вважатися контрабандою.[/color]
    }

contraband-examine-text-Major =
    { $type ->
        *[item] [color=red]Цей предмет вважається великою контрабандою.[/color]
        [reagent] [color=red]Цей реагент вважається великою контрабандою.[/color]
    }

contraband-examine-text-GrandTheft =
    { $type ->
        *[item] [color=red]Цей предмет є дуже цінною мішенню для агентів Синдикату![/color]
        [reagent] [color=red]Цей реагент є дуже цінною мішенню для агентів Синдикату![/color]
    }

contraband-examine-text-Highly-Illegal =
    { $type ->
        *[item] [color=crimson]Цей предмет є надзвичайно незаконною контрабандою![/color]
        [reagent] [color=crimson]Цей реагент є надзвичайно незаконною контрабандою![/color]
    }

contraband-examine-text-Syndicate =
    { $type ->
        *[item] [color=crimson]Цей предмет є надзвичайно незаконною контрабандою Синдикату![/color]
        [reagent] [color=crimson]Цей реагент є надзвичайно незаконною контрабандою Синдикату![/color]
    }

contraband-examine-text-Magical =
    { $type ->
        *[item] [color=#b337b3]Цей предмет є надзвичайно незаконною магічною контрабандою![/color]
        [reagent] [color=#b337b3]Цей реагент є надзвичайно незаконною магічною контрабандою![/color]
    }

contraband-examine-text-avoid-carrying-around = [color=red][italic]Ви, напевно, хочете уникати видимого носіння цього без вагомої причини.[/italic][/color]
contraband-examine-text-in-the-clear = [color=green][italic]Ви можете вільно носити його з собою.[/italic][/color]

contraband-examinable-verb-text = Законність
contraband-examinable-verb-message = Перевірити законність цього предмета.

contraband-department-plural = {$department}
contraband-job-plural = {MAKEPLURAL($job)}
