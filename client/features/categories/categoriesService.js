export async function fetchCategories() {
    try {
        const BASE_URL = await window.electronAPI.getApiBaseUrl();
        console.log("[fetchCategories] BASE_URL:", BASE_URL); // ✅ перевіримо URL

        if (!BASE_URL) throw new Error("API base URL not set");

        const url = `${BASE_URL}/Category/get-list-of-categories-with-items-lists`;
        console.log("[fetchCategories] URL:", url); // ✅ перевіримо повну URL-адресу

        const resp = await fetch(url);
        console.log("[fetchCategories] HTTP status:", resp.status); // ✅ статус відповіді

        if (!resp.ok) throw new Error(`HTTP ${resp.status}`);

        const data = await resp.json();
        console.log("[fetchCategories] DATA:", data); // ✅ ось тут прийде список категорій

        return data;
    } catch (e) {
        console.error("[fetchCategories] ERROR:", e);
        return [];
    }
}
