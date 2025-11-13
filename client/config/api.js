export const API_CONFIG = {
    VERSION: "v1",
    TIMEOUT: 8000,

    CATEGORY: {
        GET_LIST_WITH_ITEMS:
            "api/Category/get-list-of-categories-with-items-lists",
    },

    INCOME: {
        ADD_CATEGORY: "api/Income/add-incomeCategory",
        GET_CATEGORIES_LIST: "api/Income/get-category-incomes-list",
        ADD_INCOME: "api/Income/add-income",
        GET_CATEGORIES_WITH_AMOUNT:
            "api/Income/get-category-incomes-list-with-amount",
    },

    EXPENSE: {
        ADD_EXPENSE: "api/Expense/add-expense",
    },
};
