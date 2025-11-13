import { API_CONFIG } from "../../config/api.js";

export async function fetchIncomeCategoriesWithAmount() {
    try {
        const BASE_URL = await window.electronAPI.getBaseUrl();
        if (!BASE_URL) throw new Error("API base URL not set");

    const url = `${BASE_URL}${API_CONFIG.INCOME.GET_CATEGORIES_WITH_AMOUNT}`;
        

        const resp = await fetch(url, {
            headers: { Accept: "application/json" },
            cache: "no-store",
        });
        if (!resp.ok) throw new Error(`HTTP ${resp.status}`);

        const data = await resp.json();
        const values = Array.isArray(data?.$values)
            ? data.$values
            : Array.isArray(data)
            ? data
            : [];

        return values.map((v) => ({
            id: v.categoryId ?? v.id ?? null,
            name: v.categoryName ?? v.name ?? "",
            icon: v.iconName || null,  
            amount: Number(v.amount ?? 0),
        }));
    } catch (e) {
        console.error("[fetchIncomes] ERROR:", e);
        return [];
    }
}
