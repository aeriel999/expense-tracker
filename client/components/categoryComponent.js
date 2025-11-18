import { parseAmount } from "../utils/parseAmount.js";
import { ASSETS } from "../config/assets.js";
import { UI_CONFIG } from "../config/ui.js";

export function renderCategory(expenseCategory, IMAGE_URL) {
    //container
    const wrapper = document.createElement("div");
    wrapper.className = "category";

    //icon
    const icon = document.createElement("img");
    icon.src =
        expenseCategory.icon === null
            ? ASSETS.DEFAULT_CATEGORY_ICON
            : IMAGE_URL + ASSETS.ICONS_BASE + expenseCategory.icon;
    icon.alt = expenseCategory.icon === null ? "icon" : expenseCategory.icon;
    const iconWrapper = document.createElement("div");
    iconWrapper.className = "category-icon";
    iconWrapper.appendChild(icon);

    //category name
    const name = document.createElement("h3");
    name.textContent = expenseCategory.name;
    const nameWrapper = document.createElement("div");
    nameWrapper.className = "category-name";
    nameWrapper.appendChild(name);

    //category value
    const value = document.createElement("p");
    value.textContent = expenseCategory.amount + " " + UI_CONFIG.DEFAULT_CURRENCY;
    const valueWrapper = document.createElement("div");
    valueWrapper.className = "category-value";
    valueWrapper.appendChild(value);

    // category items list
    const dropdown = document.createElement("select");
    dropdown.className = "category-items";

    // option
    const placeholderOption = document.createElement("option");
    placeholderOption.textContent = "Choose from list";
    placeholderOption.value = "";
    placeholderOption.disabled = true;
    placeholderOption.selected = true;
    dropdown.appendChild(placeholderOption);

    // category items
    expenseCategory.items.forEach((item) => {
        const option = document.createElement("option");
        option.value = item.id;
        option.textContent = `${item.name}`;
        dropdown.appendChild(option);
    });

    // input field for expense amount
    const amountInput = document.createElement("input");
    amountInput.type = "text";
    amountInput.inputMode = "numeric";
    amountInput.autocomplete = "off";
    amountInput.className = "amount-input";
    amountInput.placeholder = "Enter amount";
    amountInput.setAttribute("pattern", "^\\d+$");
    amountInput.setAttribute("maxlength", "9");
    amountInput.disabled = true;  

    //amount
    const amountWrap = document.createElement("div");
    amountWrap.className = "amount-wrap";
    amountWrap.appendChild(amountInput);

    dropdown.addEventListener("change", () => {
        const hasItem = dropdown.value !== "" && dropdown.value != null;  
        amountInput.toggleAttribute("disabled", !hasItem);

        const row = dropdown.closest(".category");
         
        row?.querySelector(".row-error")?.classList.remove("visible");

        if (hasItem) {
            amountInput.focus({ preventScroll: true });
        } else {
            amountInput.value = "";
        }
    });

    //amount input
    amountInput.addEventListener("input", (e) => {
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

    amountInput.addEventListener(
        "blur",
        (e) => {
            const el = e.target;
            const n = parseAmount(el.value);
            el.value = Number.isFinite(n) && n > 0 ? String(n) : "";
        },
        true
    );

    // Enter -> ptress +BTN
    amountInput.addEventListener("keydown", (e) => {
        if (e.key === "Enter") {
            e.preventDefault();
            e.target
                .closest(".category")
                ?.querySelector(".add-expense")
                ?.click();
        }
    });

    // add button
    const addButton = document.createElement("button");
    addButton.className = "add-expense";
    addButton.title = "Add expense";

    // icon in BTN
    const plusIcon = document.createElement("img");
    plusIcon.src = ASSETS.ADD_EXPENSE_ICON; 
    plusIcon.alt = "add value";

    addButton.appendChild(plusIcon);
    wrapper.appendChild(iconWrapper);
    wrapper.appendChild(nameWrapper);
    wrapper.appendChild(valueWrapper);
    wrapper.appendChild(dropdown);
    wrapper.appendChild(amountWrap);
    wrapper.appendChild(addButton);

    return wrapper;
}
