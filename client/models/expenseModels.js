// Мінімальна модель для відповіді на "додати витрату"
export function createExpense(data) {
  if (!data) return null;

  return {
    categoryItemId: data.categoryItemId ?? data.CategoryItemId ?? null,
    amount: Number(data.amount ?? data.Amount ?? 0), // гарантуємо number
  };
}
