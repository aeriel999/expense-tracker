// models/incomesModels.js
export function createIncomeCategory(data) {
  if (!data) return null;
  return {
    id: data.categoryId ?? null,
    name: data.categoryName ?? "",
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

 