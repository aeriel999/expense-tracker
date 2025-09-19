// ---------------- State shape ----------------
// Тримаємо мінімум під поточний функціонал:
// - categories: список категорій, який ти підтягуєш із API та кладеш через SET_CATEGORIES
// - expenses:  список створених витрат (ми додаємо сюди після успішного POST)
// - count:     твій тестовий лічильник (залишаю, щоб нічого не ламати)
const initialState = {
    count: 0,
    categories: [],
    expenses: [],
    expensesAmount: 0,
    incomesAmount: 0,
    balance: 0,
};

// ---------------- Root reducer ----------------
// ВАЖЛИВО: завжди повертаємо НОВІ об'єкти/масиви (immutability),
// інакше onStateChange не спрацює.
function rootReducer(state = initialState, action) {
    switch (action.type) {
        case "SET_CATEGORIES_WITH_AMOUNTS": {
            const {
                categories = [],
                expensesAmount = 0,
                incomesAmount = 0,
                balance,
            } = action.payload || {};

            return {
                ...state,
                categories,
                expensesAmount,
                incomesAmount,
                balance: balance ?? incomesAmount - expensesAmount,
            };
        }

        // (залишаємо сумісність зі старою дією)
        case "SET_CATEGORIES": {
            const p = action.payload ?? [];
            const arr = Array.isArray(p) ? p : p?.$values || [];
            return { ...state, categories: arr };
        }

        case "ADD_EXPENSE_SUCCESS":
            return {
                ...state,
                expenses: [action.payload, ...(state.expenses || [])],
            };

        case "INCREMENT":
            return { ...state, count: state.count + 1 };

        case "DECREMENT":
            return { ...state, count: state.count - 1 };

        default:
            return state;
    }
}

module.exports = rootReducer;
