import { API_CONFIG } from "../../config/api.js";

export async function fetchMainState() {
    try {
        const BASE_URL = await window.electronAPI.getBaseUrl();

        if (!BASE_URL) throw new Error("API base URL not set");

        const url = `${BASE_URL}${API_CONFIG.CATEGORY.GET_LIST_WITH_ITEMS}`;

        const resp = await fetch(url);

        if (!resp.ok) throw new Error(`HTTP ${resp.status}`);

        const data = await resp.json();

        return data;
    } catch (e) {
        console.error("[fetchCategories] ERROR:", e);
        return [];
    }
}
