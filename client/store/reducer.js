// ---------------- State shape ----------------
// Тримаємо мінімум під поточний функціонал:
// - categories: список категорій, який ти підтягуєш із API та кладеш через SET_CATEGORIES
// - expenses:  список створених витрат (ми додаємо сюди після успішного POST)
// - count:     твій тестовий лічильник (залишаю, щоб нічого не ламати)
const initialState = {
  count: 0,
  categories: [],
  expenses: []
};

// ---------------- Root reducer ----------------
// ВАЖЛИВО: завжди повертаємо НОВІ об'єкти/масиви (immutability),
// інакше onStateChange не спрацює.
function rootReducer(state = initialState, action) {
  switch (action.type) {
    // Демонстраційні екшени лічильника
    case "INCREMENT":
      return { ...state, count: state.count + 1 };

    case "DECREMENT":
      return { ...state, count: state.count - 1 };

    // Категорії приходять із бекенду один раз на старті
    // payload: те, що повернув сервіс fetchCategories()
    case "SET_CATEGORIES":
      return { ...state, categories: action.payload };

    // ✅ Успішне створення витрати (після POST /api/expenses)
    // payload: об'єкт витрати (уже нормалізований createExpense(...) — за бажанням)
    case "ADD_EXPENSE_SUCCESS":
      return {
        ...state,
        // нову витрату кладемо на початок масиву
        expenses: [action.payload, ...(state.expenses || [])]
      };

    // За замовчуванням – без змін
    default:
      return state;
  }
}

module.exports = rootReducer;
