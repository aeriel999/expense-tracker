// ⬇️ Імпорти модулів (працює лише якщо <script type="module"> у index.html)
import { fetchMainState } from "./services/categories/categoriesService.js"; // ✅ отримання категорій з API
import { renderCategory } from "./components/categoryComponent.js"; // ✅ будує DOM для одного рядка категорії
import { createExpenseCategory } from "./models/expenseModels.js"; // ✅ адаптер: сирі API-дані -> модель для UI
import { addExpense } from "./services/expenses/expensesService.js"; // API: створення витрати
import { parseAmount } from "./utils/parseAmount.js";
import { reviveInput } from "./utils/reviveInput.js";
import { showRowError } from "./components/rowError.js";
// CLIENT/renderer.js
import { t, translateDOM } from "./js/i18n.js";

// Автопереклад елементів із data-i18n (необов'язково, безпечний виклик)
window.addEventListener("DOMContentLoaded", () => {
    translateDOM();

    const dateEl = document.querySelector('[data-role="date-heading"]');
    if (dateEl) {
        const df = new Intl.DateTimeFormat("en-US", { dateStyle: "long" });
        dateEl.textContent = df.format(new Date()); // "October 7, 2025"
    }
});

// ⬇️ Базовий URL для іконок/зображень із preload (через contextBridge)
const BASE_URL = await window.electronAPI.getBaseUrl();

// --------- Redux інтеграція: початковий рендер і підписка на зміни ---------

// 1) Стартове читання стейту з main-процесу і перший рендер
window.electronAPI.getState().then((state) => {
    renderSummary(state); // додали
    renderCategories(state); // як і було
});

// 2) Будь-яка зміна Redux-стану → повторний рендер списку категорій
window.electronAPI.onStateChange((state) => {
    renderSummary(state); // додали
    renderCategories(state); // як і було
});

// 3) Завантажуємо main state і розкладаємо у стор (категорії + суми)
fetchMainState().then((dto) => {
    const categories = (
        dto?.categoryResultsList?.$values ??
        dto?.categoryResultsList ??
        []
    ).map(createExpenseCategory); // ← createExpenseCategory мапить ТІЛЬКИ items

    window.electronAPI.dispatch({
        type: "SET_CATEGORIES_WITH_AMOUNTS",
        payload: {
            categories, // ← вже звичайний масив МОДЕЛЕЙ
            expensesAmount: Number(
                dto?.expensesAmount ?? dto?.ExpensesAmount ?? 0
            ),
            incomesAmount: Number(
                dto?.incomesAmount ?? dto?.IncomesAmount ?? 0
            ),
            balance: Number(
                dto?.balance ??
                    (dto?.incomesAmount ?? dto?.IncomesAmount ?? 0) -
                        (dto?.expensesAmount ?? dto?.ExpensesAmount ?? 0)
            ),
        },
    });
});

// ---- Рендер карток сум (Income / Expense / Balance) ----
const money = (x) =>
    `$${Number(x ?? 0).toLocaleString("en-US", { maximumFractionDigits: 2 })}`;

function renderSummary(state) {
    const incomesEl = document.querySelector('[data-summary="incomes"]');
    const expensesEl = document.querySelector('[data-summary="expenses"]');
    const balanceEl = document.querySelector('[data-summary="balance"]');

    if (incomesEl) incomesEl.textContent = money(state.incomesAmount);
    if (expensesEl) expensesEl.textContent = money(state.expensesAmount);
    if (balanceEl)
        balanceEl.textContent = money(
            state.balance ?? state.incomesAmount - state.expensesAmount
        );
}

// --------- Рендер списку категорій ---------

/**
 * Перемальовує список категорій у контейнері #category-list.
 * @param {object} state — поточний Redux-стан з preload/main.
 */
function renderCategories(state) {
    const container = document.getElementById("category-list");
    if (!container) return;
    container.innerHTML = "";

    const categories = state.categories; // ← масив уже готових моделей
    categories.forEach((cat) => {
        const el = renderCategory(cat, BASE_URL);
        container.appendChild(el);
    });
}

// --------- Додавання витрати (клік на «+») ---------

// /**
//  * Парсинг суми з урахуванням коми або крапки як десяткового роздільника.
//  * Повертає число або NaN.
//  */
// function parseAmount(raw) {
//   if (!raw) return NaN;
//   const s = String(raw).replace(/[^\d]/g, "");
//   if (!s) return NaN;
//   return parseInt(s, 10);
// }

// Делегований обробник на весь документ:
// відпрацьовує тільки для кліків по кнопці з класом .add-expense
document.addEventListener("click", async (e) => {
    const btn = e.target.closest(".add-expense");
    if (!btn) return;

    const row = btn.closest(".category");
    if (!row) return;

    const select = row.querySelector(".category-items");
    const amountInput = row.querySelector(".amount-input");

    const categoryItemId = select?.value?.trim();
    const amount = parseAmount(amountInput?.value);

    // ——— валідація без alert() ———
    if (!categoryItemId) {
        showRowError(row, t("errors.selectSubcategory"));
        reviveInput(amountInput);
        return;
    }
    if (!Number.isFinite(amount) || amount <= 0) {
        showRowError(row, t("errors.invalidAmount"));
        reviveInput(amountInput);
        return;
    }

    btn.disabled = true;
    try {
        const raw = await addExpense({ categoryItemId, amount });

        window.electronAPI.dispatch({
            type: "ADD_EXPENSE_SUCCESS",
            payload: { categoryId: raw.expenseCategoryId, amount },
        });

        amountInput.value = "";
        amountInput.focus({ preventScroll: true }); // одразу готів до наступного вводу
    } catch (err) {
        console.error(err);
        showRowError(row, t("errors.addExpenseFailed"));
        reviveInput(amountInput);
    } finally {
        btn.disabled = false;
    }
});
