// Мінімальний хелпер під 1 мову (EN), без перемикача
import errors from "../locales/en/errors.js";
import common from "../locales/en/common.js";

const messages = { ...common, ...errors };

function interpolate(str, vars = {}) {
    return String(str).replace(/\{\{\s*(\w+)\s*\}\}/g, (_, k) =>
        Object.prototype.hasOwnProperty.call(vars, k) ? vars[k] : `{{${k}}}`
    );
}

export function t(key, vars) {
    const v = messages[key];
    return v ? interpolate(v, vars) : key;
}

// Опціонально: автопереклад елементів із data-i18n
export function translateDOM(root = document) {
    root.querySelectorAll("[data-i18n]").forEach((el) => {
        const key = el.getAttribute("data-i18n");
        el.textContent = t(key);
    });
}
