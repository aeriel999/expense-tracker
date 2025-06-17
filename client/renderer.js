// renderer.js
const store = require('./store');
const { fetchCategories } = require('./categoriesSlice');

// Підписка на зміни в стейті
store.subscribe(() => {
  const state = store.getState();
  console.log('Updated State:', state.categories);
  // Тут можна оновити DOM, наприклад:
  if (state.categories.status === 'succeeded') {
    renderCategories(state.categories.items);
  }
});

// Виклик завантаження
store.dispatch(fetchCategories());

// Рендер категорій на сторінці
function renderCategories(categories) {
  const container = document.getElementById('category-list');
  container.innerHTML = '';
  categories.forEach(category => {
    const div = document.createElement('div');
    div.textContent = `${category.name} (${category.items?.join(', ')})`;
    container.appendChild(div);
  });
}
