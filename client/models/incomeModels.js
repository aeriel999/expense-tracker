// models/incomesModels.js
export function createIncomeCategory(data) {
  if (!data) return null;
  return {
    id: data.categoryId ?? data.id ?? null,
    name: data.categoryName ?? data.name ?? "",
    icon: data.iconName || null,
    amount: Number(data.amount ?? 0),
  };
}

export function createIncomeCategoriesList(payload) {
  const arr = Array.isArray(payload?.$values)
    ? payload.$values
    : Array.isArray(payload)
    ? payload
    : [];
  return arr.map(createIncomeCategory);
}

export function createIncome(data) {
  if (!data) return null;
  return {
    categoryId: data.categoryId ?? data.CategoryId ?? null,
    amount: Number(data.amount ?? data.Amount ?? 0),
  };
}
