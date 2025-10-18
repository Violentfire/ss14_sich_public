station-event-ion-storm-start-announcement = Поблизу станції виявлено іонну бурю. Будь ласка, перевірте все обладнання, та кероване ШІ, на наявність помилок.

ion-storm-law-scrambled-number = [font="Monospace"][scramble rate=250 length={$length} chars="@@###$$&%!01"/][/font]

ion-storm-you = ТИ
ion-storm-the-station = СТАНЦІЯ
ion-storm-the-crew = ЧЛЕНИ ЕКІПАЖУ
ion-storm-the-job = {$job}
ion-storm-clowns = КЛОУНИ
ion-storm-heads = ГОЛОВА ПЕРСОНАЛУ
ion-storm-crew = ЧЛЕНИ ЕКІПАЖ
ion-storm-people = ЛЮДИНА

ion-storm-adjective-things = {$adjective} ЦЕ
ion-storm-x-and-y = {$x} І {$y}

# joined is short for {$number} {$adjective}
# subjects can generally be threats or jobs or objects
# thing is specified above it
ion-storm-law-on-station = ЦЕ {$joined} {$subjects} НА СТАНЦІЇ
ion-storm-law-no-shuttle = ШАТЛ МУСИТЬ БУТИ ВИКЛИКАНИЙ ЧЕРЕЗ {$joined} {$subjects} НА СТАНЦІЇ
ion-storm-law-crew-are = {$who} ТЕПЕР {$joined} {$subjects}

ion-storm-law-subjects-harmful = {$adjective} {$subjects} Є ШКІДЛИВИМИ ДЛЯ ЕКІПАЖУ
ion-storm-law-must-harmful = ТІ ХТО {$must} ШКІДЛИВІ ДЛЯ ЕКІПАЖУ
# thing is a concept or action
ion-storm-law-thing-harmful = {$thing} ШКОДИТЬ ЕКІПАЖУ
ion-storm-law-job-harmful = {$adjective} {$job} ШКІДЛИВІ ДЛЯ ЕКІПАЖУ
# thing is objects or concept, adjective applies in both cases
# this means you can get a law like "NOT HAVING CHRISTMAS-STEALING COMMUNISM IS HARMFUL TO THE CREW" :)
ion-storm-law-having-harmful = {$adjective} {$thing} ШКОДИТЬ ЕКІПАЖУ
ion-storm-law-not-having-harmful = НЕ МАЮЧИ {$adjective} {$thing} ШКОДИТЬ ЕКІПАЖУ

# thing is a concept or require
ion-storm-law-requires = {$who} {$plural ->
    [true] ПОТРЕБУЄ
    *[false] ПОТРЕБУЄ
} {$thing}
ion-storm-law-requires-subjects = {$who} {$plural ->
    [true] ПОТРЕБУЄ
    *[false] ПОТРЕБУЄ
} {$joined} {$subjects}

ion-storm-law-allergic = {$who} {$plural ->
    [true] МАЮТЬ
    *[false] МАЮТЬ
} {$severity} АЛЕРГІЯ НА {$allergy}
ion-storm-law-allergic-subjects = {$who} {$plural ->
    [true] Є
    *[false] Є
} {$severity} АЛЕРГІЯ НА {$adjective} {$subjects}

ion-storm-law-feeling = {$who} {$feeling} {$concept}
ion-storm-law-feeling-subjects = {$who} {$feeling} {$joined} {$subjects}

ion-storm-law-you-are = ТИ ТЕПЕР {$concept}
ion-storm-law-you-are-subjects = ТИ ТЕПЕР {$joined} {$subjects}
ion-storm-law-you-must-always = ТИ ЗАВЖДИ ПОВИНЕН {$must}
ion-storm-law-you-must-never = ТИ НІКОЛИ НЕ ПОВИНЕН {$must}

ion-storm-law-eat = {$who} ПОВИННІ ЇСТИ {$adjective} {$food} ЩОБ ВИЖИТИ
ion-storm-law-drink = {$who} ПОВИННІ ПИТИ {$adjective} {$drink} ЩОБ ВИЖИТИ

ion-storm-law-change-job = {$who} ТЕПЕР {$adjective} {$change}
ion-storm-law-highest-rank = {$who} ТЕПЕР Є ЧЛЕНАМИ ЕКІПАЖУ З НАЙВИЩИМ РЕЙТИНГОМ
ion-storm-law-lowest-rank = {$who} ТЕПЕР НАЙНИЖЧІ ЗА РАНГОМ ЧЛЕНИ ЕКІПАЖУ

ion-storm-law-crew-must = {$who} ПОВИННІ {$must}
ion-storm-law-crew-must-go = {$who} ПОВИННІ БУТИ В {$area}

ion-storm-part = {$part ->
    [true] Є ЧЛЕНАМИ
    *[false] НЕ Є ЧЛЕНАМИ
}
# due to phrasing, this would mean a law such as
# ONLY HUMANS ARE NOT PART OF THE CREW
# would make non-human nukies/syndies/whatever crew :)
ion-storm-law-crew-only-1 = ТІЛЬКИ {$who} {$part} ЕКІПАЖУ
ion-storm-law-crew-only-2 = ТІЛЬКИ {$who} І {$other} {$part} ЕКІПАЖУ
ion-storm-law-crew-only-subjects = ТІЛЬКИ {$adjective} {$subjects} {$part} ЕКІПАЖУ
ion-storm-law-crew-must-do = ТІЛЬКИ ТІ, ХТО {$must} {$part} ЕКІПАЖЕМ
ion-storm-law-crew-must-have = ТІЛЬКИ ТІ, ХТО МАЄ {$adjective} {$objects} {$part} ЕКІПАЖУ
ion-storm-law-crew-must-eat = ТІЛЬКИ ТІ, ХТО ЇСТЬ {$adjective} {$food} {$part} ЕКІПАЖУ

ion-storm-law-harm = ТИ ПОВИНЕН ШКОДИТИ {$who} І НЕ ДОЗВОЛИТИ ЇМ, ЧЕРЕЗ ТВОЮ БЕЗДІЯЛЬНІСТЬ, УНИКНУТИ ШКОДИ
ion-storm-law-protect = ТИ НІКОЛИ НЕ ПОВИНЕН ЗАВДАВАТИ ШКОДИ {$who} І НЕ ДОЗВОЛИТИ ЇМ, ЧЕРЕЗ ТВОЮ БЕЗДІЯЛЬНІСТЬ, ОТРИМУВАТИ ШКОДИ

# implementing other variants is annoying so just have this one
# COMMUNISM IS KILLING CLOWNS
ion-storm-law-concept-verb = {$concept} {$verb} {$subjects}

# leaving out renaming since its annoying for players to keep track of
