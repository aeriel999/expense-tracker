/**
 * Завантажує список категорій з бекенду.
 * Повертає "сирі" дані з API (далі ти вже робиш .map(createCategory) у рендері).
 */
export async function fetchCategories() {
  try {
    // 1) Дістаємо базовий URL бекенду з preload (через IPC до main)
    const BASE_URL = await window.electronAPI.getApiBaseUrl();
    console.log("[fetchCategories] BASE_URL:", BASE_URL); // ✅ дебаг

    // 2) Мінімальна перевірка конфігурації (щоб не зробити fetch(undefined))
    if (!BASE_URL) throw new Error("API base URL not set");

    // 3) Формуємо повний шлях до ендпоінта
    //    (за потреби можна додати .replace(/\/+$/,'') для зрізання зайвих слешів)
    const url = `${BASE_URL}/Category/get-list-of-categories-with-items-lists`;
    console.log("[fetchCategories] URL:", url); // ✅ дебаг

    // 4) Власне запит
    const resp = await fetch(url);
    console.log("[fetchCategories] HTTP status:", resp.status); // ✅ дебаг

    // 5) Якщо бек повернув не 2xx → кидаємо помилку з кодом
    if (!resp.ok) throw new Error(`HTTP ${resp.status}`);

    // 6) Парсимо JSON-тіло відповіді
    const data = await resp.json();
    console.log("[fetchCategories] DATA:", data); // ✅ тут очікуємо масив або { $values: [...] } від .NET

    // 7) Повертаємо як є (нормалізацію робиш у рендері)
    return data;
  } catch (e) {
    // 8) Логуємо, але не валимо застосунок — повертаємо порожній масив
    console.error("[fetchCategories] ERROR:", e);
    return [];
  }
}
