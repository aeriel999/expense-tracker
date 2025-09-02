// client/js/features/expenses/expensesService.js

/**
 * Надсилає витрату на бекенд (створення expense).
 *
 * @param {Object} payload
 * @param {string} payload.categoryItemId - GUID підкатегорії (CategoryItem)
 * @param {number} payload.amount         - сума витрати (> 0). Парс/валідація робиться в рендері.
 *
 * @returns {Promise<Object>} Об’єкт, який повертає бек:
 *   очікувано { id, categoryItemId, amount, ... }.
 *   (Якщо бек також повертає оновлені totals/categoryTotals — отримаєш їх тут же.)
 *
 * Використання у рендері:
 *   const created = await addExpense({ categoryItemId, amount });
 *   window.electronAPI.dispatch({ type: "ADD_EXPENSE_SUCCESS", payload: created });
 */
export async function addExpense({ categoryItemId, amount }) {
  // 1) Отримуємо базовий URL API з preload (через IPC до main)
  const BASE_URL = await window.electronAPI.getApiBaseUrl();

  if (!BASE_URL) throw new Error("API base URL not set");

  // 2) Формуємо повний маршрут до ендпоінта (за потреби заміни на свій)
  const url = `${BASE_URL}/api/Expense/add-expense`; // змінити, якщо інший шлях на контролері

  // 3) HTTP POST із JSON-тілом. ASP.NET Core case-insensitive до назв полів (camelCase ок).
  const resp = await fetch(url, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ categoryItemId, amount })
  });

  // 4) Обробка неуспішних статусів (4xx/5xx): спробуємо витягти повідомлення помилки з тіла
  if (!resp.ok) {
    let msg = await resp.text().catch(() => "");   // fallback: просто текст
    try { msg = JSON.parse(msg)?.message || msg; } // якщо це JSON із { message }
    catch { /* ігноруємо парсинг */ }

    // Кидаємо помилку в рендер: там ти показуєш toast/alert і розблоковуєш кнопку
    throw new Error(`HTTP ${resp.status} ${msg}`.trim());
  }

  // 5) Повертаємо JSON-відповідь сервера — це і є “створена витрата”
  return resp.json(); // очікуємо { id, categoryItemId, amount, ... } (+optional totals)
}
