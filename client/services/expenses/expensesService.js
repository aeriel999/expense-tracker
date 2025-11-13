import { API_CONFIG } from "../../config/api.js";

export async function addExpense({ categoryItemId, amount }) {
    const BASE_URL = await window.electronAPI.getBaseUrl();

    if (!BASE_URL) throw new Error("API base URL not set");

    const url = `${BASE_URL}${API_CONFIG.EXPENSE.ADD_EXPENSE}`;

    const resp = await fetch(url, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ categoryItemId, amount }),
    });

    if (!resp.ok) {
        let msg = await resp.text().catch(() => "");
        try {
            msg = JSON.parse(msg)?.message || msg;
        } catch {}

        throw new Error(`HTTP ${resp.status} ${msg}`.trim());
    }

    return resp.json();
}
