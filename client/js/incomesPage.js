// js/incomesPage.js
import { fetchIncomeCategoriesWithAmount } from "../services/incomes/incomesService.js";
import { renderIncomeCategory } from "../components/incomeComponent.js";

const CACHE_KEY = "incomes.categories.v1";

function readCache() {
    try {
        return JSON.parse(localStorage.getItem(CACHE_KEY) || "null") || [];
    } catch {
        return [];
    }
}
function writeCache(items) {
    try {
        localStorage.setItem(CACHE_KEY, JSON.stringify(items));
    } catch {}
}

const listEl = document.getElementById("income-list");
const totalEl = document.getElementById("total-income");
const dateEl = document.getElementById("current-date");

// якщо кнопка є в html — блокуємо (крок 3 зробимо пізніше)
const addCatBtn = document.getElementById("add-income-category");
if (addCatBtn) {
    addCatBtn.disabled = true;
    addCatBtn.title = "Will be added in step 3";
}

function renderCurrentMonth() {
    const now = new Date();
    dateEl.textContent = now.toLocaleString(undefined, {
        month: "long",
        year: "numeric",
    });
}

function updateTotalFromDOM() {
    const nums = Array.from(document.querySelectorAll(".income-amount")).map(
        (x) => Number(x.textContent.replace(/[^\d.]/g, "")) || 0
    );
    totalEl.textContent = `${nums.reduce((a, b) => a + b, 0).toFixed(2)} UAH`;
}

// 🔹 УНІВЕРСАЛЬНИЙ рендер масиву категорій у DOM
function renderFrom(items) {
    listEl.innerHTML = "";
    if (!items.length) {
        listEl.innerHTML = `<li class="empty">No income categories</li>`;
        totalEl.textContent = "0.00 UAH";
        return;
    }

    items.forEach((cat) => {
        const row = renderIncomeCategory(cat, ({ amount, row, input }) => {
            // локальне оновлення суми в рядку + перерахунок тоталу
            const amtEl = row.querySelector(".income-amount");
            const current =
                Number(amtEl.textContent.replace(/[^\d.]/g, "")) || 0;
            amtEl.textContent = `${(current + amount).toFixed(2)} UAH`;
            input.value = "";
            updateTotalFromDOM();
        });
        listEl.appendChild(row);
    });

    updateTotalFromDOM();
}

// 🔹 Завантаження з сервера + запис у кеш + рендер
async function loadAndRender() {
    listEl.innerHTML = `<li class="loading">Loading…</li>`;
    const items = await fetchIncomeCategoriesWithAmount().catch(() => []);
    writeCache(items);
    renderFrom(items);
}

function init() {
    renderCurrentMonth();

    // 1) миттєво показуємо кеш (якщо є)
    const cached = readCache();
    if (cached.length) renderFrom(cached);

    // 2) оновлюємо з бекенду
    loadAndRender();
}

document.readyState === "loading"
    ? document.addEventListener("DOMContentLoaded", init)
    : init();
