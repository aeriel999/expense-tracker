import { parseAmount } from "../utils/parseAmount.js";
import { UI_CONFIG } from "../config/ui.js";
import { ASSETS } from "../config/assets.js";


export function renderIncomeCategory(incomeCategory, onAdd) {
  const li = document.createElement("li");
  li.className = "income-row";
  li.dataset.categoryId = incomeCategory.id;

  // icon
  const icon = document.createElement("img");
  icon.className = "income-icon";
  icon.src =
        incomeCategory.icon === null
            ? ASSETS.DEFAULT_INCOME_ICON
            : IMAGE_URL + ASSETS.ICONS_BASE + incomeCategory.icon;
  icon.alt = incomeCategory.name;

  const left = document.createElement("div");
  left.className = "income-left";
  left.appendChild(icon);

  //income name
  const name = document.createElement("span");
  name.className = "income-name";
  name.textContent = incomeCategory.name;

  //income amount
  const amount = document.createElement("span");
  amount.className = "income-amount";
  const value = Number(incomeCategory.amount);
  amount.textContent = `${value.toFixed(2)} ${UI_CONFIG.DEFAULT_CURRENCY}`;

  left.appendChild(name);
  left.appendChild(amount);

  // input + btn
  const right = document.createElement("div");
  right.className = "income-right";

  const input = document.createElement("input");
  input.type = "text";
  input.inputMode = "numeric";
  input.placeholder = "Amount";
  input.className = "amount-input";
  input.maxLength = UI_CONFIG.AMOUNT_INPUT_MAX_LENGTH;

  input.addEventListener("input", (e) => {
    const el = e.target;
    const start = el.selectionStart;
    const before = el.value;
    const after = before.replace(/[^\d]/g, "");
    if (after !== before) {
      el.value = after;
      const delta = before.length - after.length;
      const pos = Math.max(0, (start ?? after.length) - delta);
      el.setSelectionRange(pos, pos);
    }
  });

  input.addEventListener("blur", (e) => {
    const n = parseAmount(e.target.value);
    e.target.value = Number.isFinite(n) && n > 0 ? String(n) : "";
  });

  input.addEventListener("keydown", (e) => {
    if (e.key === "Enter") {
      e.preventDefault();
      addBtn.click();
    }
  });

  // Enter -> натискає кнопку "+"
  input.addEventListener("keydown", (e) => {
      if (e.key === "Enter") {
          e.preventDefault();
          addButton.click();
      }
  });

  // Add income button
  const addButton = document.createElement("button");
  addButton.className = "add-income-btn";
  addButton.title = "Add income";

  // Plus icon
  const plusIcon = document.createElement("img");
  plusIcon.src = ASSETS.ADD_INCOME_ICON;   
  plusIcon.alt = "add value";

  addButton.appendChild(plusIcon);

  // click handler
  addButton.addEventListener("click", () => {
      const n = parseAmount(input.value);
      if (!Number.isFinite(n) || n <= 0) {
          input.focus();
          return;
      }
      onAdd?.({ categoryId: incomeCategory.id, amount: n, row: li, input });
  });

  right.appendChild(input);
  right.appendChild(addButton);


  li.appendChild(left);
  li.appendChild(right);
  return li;
}
