import { parseAmount } from "../utils/parseAmount.js";

export function renderCategory(category, IMAGE_URL) {
    //container
    const wrapper = document.createElement("div");
    wrapper.className = "category";

    //icon
    const icon = document.createElement("img");
    icon.src =
        category.icon === null
            ? "assets/icons/default-icon.png"
            : IMAGE_URL + "icons/" + category.icon;
    icon.alt = category.icon === null ? "icon" : category.icon;
    const iconWrapper = document.createElement("div");
    iconWrapper.className = "category-icon";
    iconWrapper.appendChild(icon);

    //category name
    const name = document.createElement("h3");
    name.textContent = category.name;
    const nameWrapper = document.createElement("div");
    nameWrapper.className = "category-name";
    nameWrapper.appendChild(name);

    //category value
    const value = document.createElement("p");
    value.textContent = category.amount + " UAH";
    const valueWrapper = document.createElement("div");
    valueWrapper.className = "category-value";
    valueWrapper.appendChild(value);

    // category items list
    const dropdown = document.createElement("select");
    dropdown.className = "category-items";

    // додати перший пустий option з підказкою
    const placeholderOption = document.createElement("option");
    placeholderOption.textContent = "Choose from list";
    placeholderOption.value = "";
    placeholderOption.disabled = true;
    placeholderOption.selected = true;
    dropdown.appendChild(placeholderOption);

    // додати інші підкатегорії
    category.items.forEach((item) => {
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
    amountInput.disabled = true; // активний після вибору підкатегорії

    const amountWrap = document.createElement("div");
    amountWrap.className = "amount-wrap";
    amountWrap.appendChild(amountInput);

    dropdown.addEventListener("change", () => {
        const hasItem = dropdown.value !== "" && dropdown.value != null; // '0' теж вважається валідним
        amountInput.toggleAttribute("disabled", !hasItem);

        const row = dropdown.closest(".category");
        // прибрати inline-помилку, якщо була
        row?.querySelector(".row-error")?.classList.remove("visible");

        if (hasItem) {
            amountInput.focus({ preventScroll: true });
        } else {
            amountInput.value = "";
        }
    });

    // лише цифри + збереження каретки
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

    // на blur — прибрати лідируючі нулі; 0/порожнє -> ''
    amountInput.addEventListener(
        "blur",
        (e) => {
            const el = e.target;
            const n = parseAmount(el.value);
            el.value = Number.isFinite(n) && n > 0 ? String(n) : "";
        },
        true
    );

    // Enter у полі — натискає кнопку "+"
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

    // додаємо іконку в кнопку
    const plusIcon = document.createElement("img");
    plusIcon.src = "assets/icons/add_value.png"; // або "IMAGE_URL + 'plus-icon.png'" — залежно від того, де зберігаєш
    plusIcon.alt = "add value";
    addButton.appendChild(plusIcon);

    //wrapper.appendChild(icon);
    wrapper.appendChild(iconWrapper);
    wrapper.appendChild(nameWrapper);
    wrapper.appendChild(valueWrapper);

    // wrapper.appendChild(name);
    // wrapper.appendChild(value);
    wrapper.appendChild(dropdown);
    wrapper.appendChild(amountWrap);
    wrapper.appendChild(addButton);

    return wrapper;
}

//"default-icon.png"
