import { createCategory } from "./categoryModels.js";

function asArray(x) {
  if (!x) return [];
  if (Array.isArray(x)) return x;
  return x.$values ?? [];
}
function num(x, d = 0) {
  const v = x ?? d;
  return typeof v === "number" ? v : Number(v);
}

export function createStateData(dto) {
  if (!dto) return null;

  // 1) категорії
  const rawList = asArray(dto.categoryResultsList ?? dto.CategoryResultsList);
  const categories = rawList.map(createCategory);

  // 2) суми
  const expensesAmount = num(dto.expensesAmount ?? dto.ExpensesAmount, 0);
  const incomesAmount  = num(dto.incomesAmount  ?? dto.IncomesAmount,  0);
  const balance        = num(dto.balance        ?? dto.Balance,
                             incomesAmount - expensesAmount);

  // 3) shape стора (під твій поточний reducer)
  return {
    categories,
    expensesAmount,
    incomesAmount,
    balance,
  };
}
