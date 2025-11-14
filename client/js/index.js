import { ROUTES } from "../config/routes.js";

document.addEventListener("DOMContentLoaded", () => {
    const dateElement = document.getElementById("current-date");
    const now = new Date();

    const options = { year: "numeric", month: "long", day: "numeric" };
    dateElement.textContent = now.toLocaleDateString("en-US", options);

    // 🟢 Додаємо перехід на сторінку incomes
    const incomeCard = document.getElementById("total-income-card");
    if (incomeCard) {
        incomeCard.addEventListener("click", () => {
            window.location.href = ROUTES.INCOMES;
        });
    }
});
