export function renderCategory(category) {
    const wrapper = document.createElement("div");
    wrapper.className = "category";

    const icon = document.createElement("img");
    icon.src = `assets/icons/${category.icon}`;
    icon.alt = "icon";

    const name = document.createElement("h3");
    name.textContent = category.name;

    const dropdown = document.createElement("select");
    dropdown.className = "category-items";

    category.items.forEach(item => {
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
