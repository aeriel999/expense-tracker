export function reviveInput(input) {
    if (!input || !input.isConnected) return;

    // трюк: коротко зробити readonly, потім повернути
    const wasReadOnly = input.readOnly;
    const v = input.value;

    input.blur();
    input.readOnly = true;

    // два rAF — щоб дати DOM стабілізуватись
    requestAnimationFrame(() => {
        void input.offsetWidth; // форсуємо рефлоу
        requestAnimationFrame(() => {
            input.readOnly = wasReadOnly;
            try {
                input.value = v;
            } catch {}
            input.focus({ preventScroll: true });
        });
    });
}
