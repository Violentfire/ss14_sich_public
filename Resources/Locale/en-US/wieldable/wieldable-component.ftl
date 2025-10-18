### Locale for wielding items; i.e. two-handing them

wieldable-verb-text-wield = Схопити
wieldable-verb-text-unwield = Відпустити

wieldable-component-successful-wield = { CAPITALIZE($item) } у ваших руках.
wieldable-component-failed-wield = { CAPITALIZE($item) } не у ваших руках.
wieldable-component-successful-wield-other = { CAPITALIZE($user) } тримає у руках наступне: { $item }.
wieldable-component-failed-wield-other = { CAPITALIZE($user) } не тримає у руках наступне: { $item }.
wieldable-component-blocked-wield = { CAPITALIZE($blocker) } заважає вам взяти { $item } двома руками.

wieldable-component-no-hands = У вас недостатньо рук!
wieldable-component-not-enough-free-hands = {$number -> 
    [one] Вам потрібна вільна рука, щоб схопити цей предмет: { THE($item) }.
    *[other] Вам потрібно { $number } вільних руки, шоб схопити цей предмет: { THE($item) }.
}
wieldable-component-not-in-hands = { CAPITALIZE($item) } не у ваших руках!

gunwieldbonus-component-examine = Ця зброя має підвищену точність стрільби.

gunrequireswield-component-examine = З цієї зброї можна стріляти лише тоді, коли вона в обох руках.
