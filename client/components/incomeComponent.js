import { parseAmount } from "../utils/parseAmount.js";

export function renderIncomeCategory(category, onAdd) {
  const li = document.createElement("li");
  li.className = "income-row";
  li.dataset.categoryId = category.id;

  // 🔹 іконка
  const iconBase = window.electronAPI.iconsUrl?.() ?? "../assets/icons";
  const icon = document.createElement("img");
  icon.className = "income-icon";
  icon.src = category.icon
    ? `${iconBase}/${category.icon}`
    : "../assets/icons/default-icon.png";
  icon.alt = category.name;

  const left = document.createElement("div");
  left.className = "income-left";
  left.appendChild(icon);

  const name = document.createElement("span");
  name.className = "income-name";
  name.textContent = category.name;

  const amount = document.createElement("span");
  amount.className = "income-amount";
  amount.textContent = `${(Number(category.amount) || 0).toFixed(2)} UAH`;

  left.appendChild(name);
  left.appendChild(amount);

  // 🔹 праворуч — інпут + кнопка
  const right = document.createElement("div");
  right.className = "income-right";

  const input = document.createElement("input");
  input.type = "text";
  input.inputMode = "numeric";
  input.placeholder = "Amount";
  input.className = "amount-input";
  input.maxLength = 9;

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

  const addBtn = document.createElement("button");
  addBtn.className = "btn btn-icon";
  addBtn.title = "Add income";
  addBtn.innerHTML = `<img src="../assets/icons/add_value.png" alt="+">`;

  addBtn.addEventListener("click", () => {
    const n = parseAmount(input.value);
    if (!Number.isFinite(n) || n <= 0) {
      input.focus();
      return;
    }
    onAdd?.({ categoryId: category.id, amount: n, row: li, input });
  });

  right.appendChild(input);
  right.appendChild(addBtn);

  li.appendChild(left);
  li.appendChild(right);
  return li;
}
