// import { formatCurrency } from "../utils/formatCurrency.js";

// window.addEventListener("DOMContentLoaded", () => {
//     translateDOM();

//     const dateEl = document.querySelector('[data-role="date-heading"]');
//     if (dateEl) {
//         const df = new Intl.DateTimeFormat("en-US", { dateStyle: "long" });
//         dateEl.textContent = df.format(new Date()); // "October 7, 2025"
//     }
// });

// document.addEventListener("DOMContentLoaded", async () => {
//     const list = document.getElementById("income-list");
//     const totalEl = document.getElementById("total-income");
//     const monthEl = document.getElementById("month");
//     const backBtn = document.getElementById("back-btn");

//     // Повернення на головну

//     if (backBtn) {
//         backBtn.addEventListener("click", () => {
//             window.location.href = "../index.html"; // шлях відносно pages/incomes.html
//         });
//     }

//     // Додатково: Esc або Alt+←
//     document.addEventListener("keydown", (e) => {
//         if (e.key === "Escape" || (e.key === "ArrowLeft" && e.altKey)) {
//             window.location.href = "../index.html";
//         }
//     });

//     // Встановлюємо поточний місяць
//     const now = new Date();
//     const monthName = now.toLocaleString("en-US", {
//         month: "long",
//         year: "numeric",
//     });
//     monthEl.textContent = monthName;

//     // Завантаження інкамсів
//     const incomes = await fetchIncomesByMonth(now);

//     if (!incomes.length) {
//         list.innerHTML = "<li>No incomes for this month</li>";
//         return;
//     }

//     let total = 0;
//     incomes.forEach((i) => {
//         total += i.amount;
//         const li = document.createElement("li");
//         li.classList.add("income-item");
//         li.innerHTML = `
//       <div class="income-row">
//         <span class="category">${i.categoryName}</span>
//         <span class="title">${i.title}</span>
//         <span class="amount">${formatCurrency(i.amount)} UAH</span>
//         <span class="date">${i.date}</span>
//       </div>
//     `;
//         list.appendChild(li);
//     });

//     totalEl.textContent = formatCurrency(total) + " UAH";
// });
