import { fetchCategories } from "./features/categories/categoriesService.js"; // ✅
import { renderCategory } from "./components/categoryComponent.js";
import { createCategory } from "./models/categoryModels.js";

const IMAGE_URL = await window.electronAPI.getImageBaseUrl();

window.electronAPI.getState().then((state) => {
    renderCategories(state);
});

window.electronAPI.onStateChange((state) => renderCategories(state));

fetchCategories().then((categories) =>
    window.electronAPI.dispatch({ type: "SET_CATEGORIES", payload: categories })
);

async function renderCategories(state) {
    const container = document.getElementById("category-list");

    if (!container) return;
    container.innerHTML = "";

    const categories = (state.categories?.$values || []).map(createCategory);
    categories.forEach((cat) => {
        const el = renderCategory(cat, IMAGE_URL);
        container.appendChild(el);
    });
}
