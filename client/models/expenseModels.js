export function createExpenseCategory(data) {
    if (!data) return null;
    return {
        id: data.id,
        name: data.name,
        icon: data.iconPath || null,
        amount: data.amount,
        items: (data.categoryItems?.$values || []).map(createExpenseCategoryItem),
    };
}

export function createExpenseCategoryItem(data) {
    if (!data) return null;
    return {
        id: data.id,
        name: data.name,
        total: data.total,
    };
}

// Мінімальна модель для відповіді на "додати витрату"
export function createExpense(data) {
    if (!data) return null;

    return {
        categoryItemId: data.categoryItemId ?? data.CategoryItemId ?? null,
        amount: Number(data.amount ?? data.Amount ?? 0), // гарантуємо number
    };
}
