/**
 * Завантажує список категорій доходів з бекенду.
 * Повертає сирі дані з API (далі обробляються в рендері).
 */
export async function fetchIncomeCategoriesWithAmount() {
  try {
    // 1️⃣ Отримуємо базовий URL через preload (IPC)
    const BASE_URL = await window.electronAPI.getBaseUrl();
    console.log("[fetchIncomes] BASE_URL:", BASE_URL);

    // 2️⃣ Перевірка, щоб не зробити fetch(undefined)
    if (!BASE_URL) throw new Error("API base URL not set");

    // 3️⃣ Формуємо повний шлях до ендпоїнта
    const url = `${BASE_URL}api/Income/get-category-incomes-list-with-amount`;
    console.log("[fetchIncomes] URL:", url);

    // 4️⃣ Виконуємо запит
    const resp = await fetch(url);
    console.log("[fetchIncomes] HTTP status:", resp.status);

    // 5️⃣ Якщо код не 2xx — кидаємо помилку
    if (!resp.ok) throw new Error(`HTTP ${resp.status}`);

    // 6️⃣ Парсимо JSON-тіло
    const data = await resp.json();
    console.log("[fetchIncomes] DATA:", data);

    // 7️⃣ Обробляємо масив або { $values: [...] }
    const values = Array.isArray(data?.$values)
      ? data.$values
      : Array.isArray(data)
      ? data
      : [];

    // 8️⃣ Повертаємо підготовлений масив для UI
    return values.map(v => ({
      id: v.categoryId,
      name: v.categoryName,
      amount: Number(v.amount) || 0,
    }));
  } catch (e) {
    console.error("[fetchIncomes] ERROR:", e);
    return [];
  }
}
