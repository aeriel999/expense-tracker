import { fetchCategories } from "./features/categories/categoriesService.js"; // ✅

window.electronAPI.getState().then((state) => {
    renderCategories(state);
});

window.electronAPI.onStateChange((state) => renderCategories(state));

fetchCategories().then((categories) =>
    window.electronAPI.dispatch({ type: "SET_CATEGORIES", payload: categories })
);

function renderCategories(state) {
    const c = document.getElementById("category-list");
    if (!c) return;
    c.innerHTML = "";
    const categories = state.categories?.$values || [];
categories.forEach((cat) => {
  const d = document.createElement("div");
  d.textContent = cat.name;
  c.appendChild(d);
});

}
