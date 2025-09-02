// ⬇️ Імпорти модулів (працює лише якщо <script type="module"> у index.html)
import { fetchCategories } from "./features/categories/categoriesService.js"; // ✅ отримання категорій з API
import { renderCategory } from "./components/categoryComponent.js";           // ✅ будує DOM для одного рядка категорії
import { createCategory } from "./models/categoryModels.js";                  // ✅ адаптер: сирі API-дані -> модель для UI
import { addExpense } from "./features/expenses/expensesService.js";         // API: створення витрати
import { createExpense } from "./models/expenseModels.js";                  // Модель витрати: приводить відповідь POST /api/expenses до єдиного формату

// ⬇️ Базовий URL для іконок/зображень із preload (через contextBridge)
const IMAGE_URL = await window.electronAPI.getImageBaseUrl();

// --------- Redux інтеграція: початковий рендер і підписка на зміни ---------

// 1) Стартове читання стейту з main-процесу і перший рендер
window.electronAPI.getState().then((state) => {
  renderCategories(state);
});

// 2) Будь-яка зміна Redux-стану → повторний рендер списку категорій
window.electronAPI.onStateChange((state) => renderCategories(state));

// 3) Після завантаження категорій з API кладемо їх у Redux (SET_CATEGORIES)
fetchCategories().then((categories) =>
  window.electronAPI.dispatch({ type: "SET_CATEGORIES", payload: categories })
);

// --------- Рендер списку категорій ---------

/**
 * Перемальовує список категорій у контейнері #category-list.
 * @param {object} state — поточний Redux-стан з preload/main.
 */
async function renderCategories(state) {
  const container = document.getElementById("category-list");
  if (!container) return;

  // очищаємо попередній вміст перед повним перерендером
  container.innerHTML = "";

  // БЕК .NET інколи повертає масиви у вигляді { $values: [...] } → дістаємо їх безпечно
  const categories = (state.categories?.$values || []).map(createCategory);

  // для кожної категорії будуємо DOM-елемент і додаємо у контейнер
  categories.forEach((cat) => {
    const el = renderCategory(cat, IMAGE_URL); // renderCategory має створити .category-row з усіма елементами
    container.appendChild(el);
  });
}

// --------- Додавання витрати (клік на «+») ---------

/**
 * Парсинг суми з урахуванням коми або крапки як десяткового роздільника.
 * Повертає число або NaN.
 */
function parseAmount(v) {
  const n = Number(String(v ?? "").trim().replace(",", "."));
  return Number.isFinite(n) ? n : NaN;
}

// Делегований обробник на весь документ:
// відпрацьовує тільки для кліків по кнопці з класом .add-expense
document.addEventListener("click", async (e) => {
  const btn = e.target.closest(".add-expense");
  if (!btn) return;

  const row = btn.closest(".category");                 // 👈 виправили
  if (!row) { console.warn("[add-expense] row null"); return; }

  const select = row.querySelector(".category-items");  // <select> з підкатегоріями
  const amountInput = row.querySelector(".amount-input");

  const categoryItemId = select?.value?.trim();
  const amount = parseAmount(amountInput?.value);

  if (!categoryItemId) { alert("Виберіть підкатегорію"); return; }
  if (!Number.isFinite(amount) || amount <= 0) { alert("Некоректна сума"); return; }

  btn.disabled = true;
  try {
    const raw = await addExpense({ categoryItemId, amount }); // сервіс
    console.log("raw", raw)

    const expense = createExpense(raw);                       // мінімальна модель
    window.electronAPI.dispatch({ type: "ADD_EXPENSE_SUCCESS", payload: expense });
    amountInput.value = "";
  } catch (err) {
    console.error(err);
    alert("Не вдалося додати витрату.");
  } finally {
    btn.disabled = false;
  }
});

