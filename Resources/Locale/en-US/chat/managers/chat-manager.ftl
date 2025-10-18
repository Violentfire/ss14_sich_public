### UI

chat-manager-max-message-length = Ваше повідомлення перевищує ліміт {$maxMessageLength} символів
chat-manager-ooc-chat-enabled-message = OOC чат було ввімкнено.
chat-manager-ooc-chat-disabled-message = OOC чат було вимкнено.
chat-manager-looc-chat-enabled-message = LOOC чат було ввімкнено.
chat-manager-looc-chat-disabled-message = LOOC чат було вимкнено.
chat-manager-dead-looc-chat-enabled-message = Мертві гравці тепер можуть використовувати LOOC чат.
chat-manager-dead-looc-chat-disabled-message = Мертві гравці більше не можуть використовувати LOOC чат.
chat-manager-crit-looc-chat-enabled-message = Гравці у критичному стані тепер можуть використовувати LOOC чат.
chat-manager-crit-looc-chat-disabled-message = Гравці у критичному стані більше не можуть використовувати LOOC чат.
chat-manager-admin-ooc-chat-enabled-message = Адмін OOC чат було ввімкнено.
chat-manager-admin-ooc-chat-disabled-message = Адмін OOC чат було вимкнено.

chat-manager-max-message-length-exceeded-message = Ваше повідомлення перевищує ліміт {$limit} символів
chat-manager-no-headset-on-message = У вас немає гарнітури!
chat-manager-no-radio-key = Не вказано радіо-ключ!
chat-manager-no-such-channel = Не існує каналу з ключем '{$key}'!
chat-manager-whisper-headset-on-message = Ви не можете говорити пошепки у радіо!

chat-manager-server-wrap-message = [bold]{$message}[/bold]
chat-manager-sender-announcement = Центральне командування
chat-manager-sender-announcement-wrap-message = [font size=14][bold]{$sender} Оголошення:[/font][font size=12]
                                                {$message}[/bold][/font]
chat-manager-entity-say-wrap-message = [BubbleHeader][bold][Name]{$entityName}[/Name][/bold][/BubbleHeader] {$verb}, [font={$fontType} size={$fontSize}]"[BubbleContent]{$message}[/BubbleContent]"[/font]
chat-manager-entity-say-bold-wrap-message = [BubbleHeader][bold][Name]{$entityName}[/Name][/bold][/BubbleHeader] {$verb}, [font={$fontType} size={$fontSize}]"[BubbleContent][bold]{$message}[/bold][/BubbleContent]"[/font]

chat-manager-entity-whisper-wrap-message = [font size=11][italic][BubbleHeader][Name]{$entityName}[/Name][/BubbleHeader] шепоче,"[BubbleContent]{$message}[/BubbleContent]"[/italic][/font]
chat-manager-entity-whisper-unknown-wrap-message = [font size=11][italic][BubbleHeader]Someone[/BubbleHeader] шепоче, "[BubbleContent]{$message}[/BubbleContent]"[/italic][/font]

# THE() is not used here because the entity and its name can technically be disconnected if a nameOverride is passed...
chat-manager-entity-me-wrap-message = [italic]{ PROPER($entity) ->
    *[false] {CAPITALIZE($entityName)} {$message}[/italic]
     [true] {CAPITALIZE($entityName)} {$message}[/italic]
    }

chat-manager-entity-looc-wrap-message = LOOC: [bold]{$entityName}:[/bold] {$message}
chat-manager-send-ooc-wrap-message = OOC: [bold]{$playerName}:[/bold] {$message}
chat-manager-send-ooc-patron-wrap-message = OOC: [bold][color={$patronColor}]{$playerName}[/color]:[/bold] {$message}

chat-manager-send-dead-chat-wrap-message = {$deadChannelName}: [bold][BubbleHeader]{$playerName}[/BubbleHeader]:[/bold] [BubbleContent]{$message}[/BubbleContent]
chat-manager-send-admin-dead-chat-wrap-message = {$adminChannelName}: [bold]([BubbleHeader]{$userName}[/BubbleHeader]):[/bold] [BubbleContent]{$message}[/BubbleContent]
chat-manager-send-admin-chat-wrap-message = {$adminChannelName}: [bold]{$playerName}:[/bold] {$message}
chat-manager-send-admin-announcement-wrap-message = [bold]{$adminChannelName}: {$message}[/bold]

chat-manager-send-hook-ooc-wrap-message = OOC: [bold](D){$senderName}:[/bold] {$message}
chat-manager-send-hook-admin-wrap-message = ADMIN: [bold](D){$senderName}:[/bold] {$message}

chat-manager-dead-channel-name = МЕРТВІ
chat-manager-admin-channel-name = АДМІН

chat-manager-rate-limited = You are sending messages too quickly!
chat-manager-rate-limit-admin-announcement = Rate limit warning: { $player }

## Speech verbs for chat

chat-speech-verb-suffix-exclamation = !
chat-speech-verb-suffix-exclamation-strong = !!
chat-speech-verb-suffix-question = ?
chat-speech-verb-suffix-stutter = -
chat-speech-verb-suffix-mumble = ..

chat-speech-verb-name-none = Жодного
chat-speech-verb-name-default = За замовчуванням
chat-speech-verb-default = каже
chat-speech-verb-name-exclamation = Вигукнути
chat-speech-verb-exclamation = вигукує
chat-speech-verb-name-exclamation-strong = Кричати
chat-speech-verb-exclamation-strong = кричить
chat-speech-verb-name-question = Запитати
chat-speech-verb-question = запитує
chat-speech-verb-name-stutter = Заїкатися
chat-speech-verb-stutter = говорить заїкаючись
chat-speech-verb-name-mumble = Бурмотіти
chat-speech-verb-mumble = бурмоче

chat-speech-verb-name-arachnid = Павукоподібний
chat-speech-verb-insect-1 = щебече
chat-speech-verb-insect-2 = цвірінькає
chat-speech-verb-insect-3 = цокає

chat-speech-verb-name-moth = Моль
chat-speech-verb-winged-1 = тріпоче
chat-speech-verb-winged-2 = лопоче
chat-speech-verb-winged-3 = дзижчить

chat-speech-verb-name-slime = Слиз
chat-speech-verb-slime-1 = хлюпає
chat-speech-verb-slime-2 = булькає
chat-speech-verb-slime-3 = сочиться

chat-speech-verb-name-plant = Діона
chat-speech-verb-plant-1 = шелестить
chat-speech-verb-plant-2 = хитається
chat-speech-verb-plant-3 = тріщить

chat-speech-verb-name-robotic = Роботизований
chat-speech-verb-robotic-1 = стверджує
chat-speech-verb-robotic-2 = гуде
chat-speech-verb-robotic-3 = бікає

chat-speech-verb-name-reptilian = Рептилія
chat-speech-verb-reptilian-1 = шипить
chat-speech-verb-reptilian-2 = фиркає
chat-speech-verb-reptilian-3 = сопе

chat-speech-verb-name-skeleton = Скелет
chat-speech-verb-skeleton-1 = брязкає
chat-speech-verb-skeleton-2 = клацає
chat-speech-verb-skeleton-3 = скрегоче

chat-speech-verb-name-vox = Вокс
chat-speech-verb-vox-1 = верещить
chat-speech-verb-vox-2 = кричить
chat-speech-verb-vox-3 = каркає

chat-speech-verb-name-canine = Собака
chat-speech-verb-canine-1 = гавкає
chat-speech-verb-canine-2 = виє
chat-speech-verb-canine-3 = завиває

chat-speech-verb-name-goat = Козел
chat-speech-verb-goat-1 = вищить
chat-speech-verb-goat-2 = бурчить
chat-speech-verb-goat-3 = кричить

chat-speech-verb-name-small-mob = Миша
chat-speech-verb-small-mob-1 = пищить
chat-speech-verb-small-mob-2 = попискує

chat-speech-verb-name-large-mob = Карп
chat-speech-verb-large-mob-1 = реве
chat-speech-verb-large-mob-2 = гарчить

chat-speech-verb-name-monkey = Мавпа
chat-speech-verb-monkey-1 = викрикує
chat-speech-verb-monkey-2 = кричить

chat-speech-verb-name-cluwne = Клоун
chat-speech-verb-cluwne-1 = хихикає
chat-speech-verb-cluwne-2 = регоче
chat-speech-verb-cluwne-3 = сміється

chat-speech-verb-name-parrot = Папуга
chat-speech-verb-parrot-1 = сковчить
chat-speech-verb-parrot-2 = цвірінькає
chat-speech-verb-parrot-3 = щебече

chat-speech-verb-name-ghost = Привид
chat-speech-verb-ghost-1 = жаліється
chat-speech-verb-ghost-2 = видихає
chat-speech-verb-ghost-3 = наспівує
chat-speech-verb-ghost-4 = бурмоче

chat-speech-verb-name-electricity = Електрика
chat-speech-verb-electricity-1 = тріщить
chat-speech-verb-electricity-2 = дзижчить
chat-speech-verb-electricity-3 = верещить

chat-speech-verb-vulpkanin-1 = гарчить
chat-speech-verb-vulpkanin-2 = гавкає
chat-speech-verb-vulpkanin-3 = ричить
chat-speech-verb-vulpkanin-4 = тявкає
chat-speech-verb-vulpkanin = Вульпканін

chat-speech-verb-name-wawa = Вава
chat-speech-verb-wawa-1 = інтонуючи говорить
chat-speech-verb-wawa-2 = стверджує
chat-speech-verb-wawa-3 = проголошує
chat-speech-verb-wawa-4 = розмірковує
