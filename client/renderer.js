const store = require("./store/store");
const { getCategories } = require("./store/categories/category.actions");

// 1. Завантажуємо категорії при старті
store.dispatch(getCategories());

// 2. Підписуємось на оновлення store
store.subscribe(() => {
    const state = store.getState();
    const categories = state.category.items;

    renderCategories(categories);
});

// 3. Функція рендера
function renderCategories(categories) {
    const container = document.getElementById("category-list");
    container.innerHTML = ""; // очищаємо перед новим рендером

    if (!categories || categories.length === 0) {
        container.innerHTML = "<p>No categories found.</p>";
        return;
    }

    categories.forEach((cat) => {
        const div = document.createElement("div");
        div.classList.add("category-item");
        div.innerHTML = `
      <h3>${cat.name}</h3>
      <ul>
        ${(cat.items || [])
            .map((item) => `<li>${item.name} — $${item.amount}</li>`)
            .join("")}
      </ul>
    `;
        container.appendChild(div);
    });
}
