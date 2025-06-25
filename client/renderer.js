import { fetchCategories } from "./features/categories/categoriesService.js"; // ✅

window.electronAPI.getState().then((state) => {
    renderCategories(state);
});

window.electronAPI.onStateChange((state) => renderCategories(state));

fetchCategories().then((categories) =>
    window.electronAPI.dispatch({ type: "SET_CATEGORIES", payload: categories })
);

function renderCategories(state) {
    const c = document.getElementById("categories");
    if (!c) return;
    c.innerHTML = "";
    (state.categories || []).forEach((cat) => {
        const d = document.createElement("div");
        d.textContent = cat.name;
        c.appendChild(d);
    });
}
