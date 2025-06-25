// 1. Відправляємо запит на завантаження категорій
console.log("🔄 Викликано dispatchGetCategories()");
window.electronAPI.dispatch({
    type: "category/getCategories/pending",
    payload: null,
});

// 2. Після кожного оновлення store, рендеримо
window.electronAPI.onReduxUpdate((state) => {
    const categories = state.category?.items ?? [];
    console.log("📥 Нові категорії зі store:", state);
    renderCategories(categories);
});

// 3. Рендер функція
function renderCategories(categories) {
    const container = document.getElementById("category-list");
    container.innerHTML = "";

    if (!categories.length) {
        container.innerHTML = "<p>No categories found.</p>";
        return;
    }

    console.log("🖼️ Рендер категорій:", categories);

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
