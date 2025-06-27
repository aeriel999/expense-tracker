export function renderCategory(category, IMAGE_URL) {
    const wrapper = document.createElement("div");
    wrapper.className = "category";

    const icon = document.createElement("img");
    // icon.src = `assets/icons/${category.icon}`;
    icon.src =
        category.icon === null
            ? "assets/icons/default-icon.png"
            : IMAGE_URL + category.icon;
    icon.alt = category.icon === null ? "icon" : category.icon;

    const name = document.createElement("h3");
    name.textContent = category.name;

    const dropdown = document.createElement("select");
    dropdown.className = "category-items";

    category.items.forEach((item) => {
        const option = document.createElement("option");
        option.value = item.id;
        option.textContent = `${item.name} - $${item.amount}`;
        dropdown.appendChild(option);
    });

    wrapper.appendChild(icon);
    wrapper.appendChild(name);
    wrapper.appendChild(dropdown);

    return wrapper;
}

//"default-icon.png"
