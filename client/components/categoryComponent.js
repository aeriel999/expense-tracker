export function renderCategory(category, IMAGE_URL) {
    //container
    const wrapper = document.createElement("div");
    wrapper.className = "category";

    //icon
    const icon = document.createElement("img");
    icon.src =
        category.icon === null
            ? "assets/icons/default-icon.png"
            : IMAGE_URL + category.icon;
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
    amountInput.type = "number";
    amountInput.className = "amount-input";
    amountInput.placeholder = "Enter amount";
    amountInput.min = "0";
    amountInput.max = "10000";
    amountInput.step = "0.01";
    amountInput.disabled = true; // буде активне лише після вибору підкатегорії

    dropdown.addEventListener("change", () => {
        amountInput.disabled = !dropdown.value;
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
    wrapper.appendChild(amountInput);
    wrapper.appendChild(addButton);

    return wrapper;
}

//"default-icon.png"
