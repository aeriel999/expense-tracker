const categories = [
    {
        name: "Food",
        icon: "🍎",
        items: [
            "Meat",
            "Vegetables/Greens",
            "Grains",
            "Sauces",
            "Dairy",
            "Bread",
            "Sweets",
        ],
    },
    {
        name: "Entertainment",
        icon: "🎉",
        items: ["Alcohol", "Fast Food", "Cafe", "Cinema", "Events"],
    },
    { name: "Personal", icon: "🧍‍♀️", items: [] },
    { name: "Pet", icon: "🐶", items: ["Food", "Vet", "Toys", "Grooming"] },
    {
        name: "Medicine",
        icon: "🩺",
        items: ["Painkillers", "Vitamins", "Antibiotics"],
    },
    {
        name: "Hygiene",
        icon: "🧼",
        items: [
            "Shampoo",
            "Soap",
            "Laundry Powder",
            "Toothpaste",
            "Toilet Paper",
        ],
    },
    {
        name: "Household",
        icon: "🏠",
        items: ["Dish Soap", "Sponges", "Tableware", "Trash Bags", "Napkins"],
    },
    { name: "Credit Card", icon: "💳", items: ["Payment", "Interest", "Fees"] },
    {
        name: "Utilities",
        icon: "💧",
        items: ["Electricity", "Water", "Gas", "Heating"],
    },
    {
        name: "Communication",
        icon: "📞",
        items: ["Mobile", "Internet", "ChatGPT", "Subscriptions"],
    },
];

window.addEventListener("DOMContentLoaded", () => {
    const container = document.getElementById("categories");

    categories.forEach((category) => {
        const div = document.createElement("div");
        div.className = "category";

        // Заголовок: Сума ліворуч, назва праворуч
        const header = document.createElement("div");
        header.className = "category-header";

        const totalSpan = document.createElement("span");
        totalSpan.className = "category-total";
        totalSpan.textContent = "$0"; // Статична сума

        const titleSpan = document.createElement("span");
        titleSpan.className = "category-title";
        titleSpan.textContent = `${category.icon} ${category.name}`;

        header.appendChild(totalSpan);
        header.appendChild(titleSpan);

        // Autocomplete input
        const itemInput = document.createElement("input");
        itemInput.type = "text";
        itemInput.placeholder = "Enter item";
        itemInput.setAttribute("list", `datalist-${category.name}`);

        const datalist = document.createElement("datalist");
        datalist.id = `datalist-${category.name}`;
        category.items.forEach((item) => {
            const option = document.createElement("option");
            option.value = item;
            datalist.appendChild(option);
        });

        // Amount input
        const amountInput = document.createElement("input");
        amountInput.type = "number";
        amountInput.placeholder = "$";

        // Add button (без логіки)
        const button = document.createElement("button");
        button.textContent = "+";

        const inputWrapper = document.createElement("div");
        inputWrapper.appendChild(itemInput);
        inputWrapper.appendChild(datalist);
        inputWrapper.appendChild(amountInput);
        inputWrapper.appendChild(button);

        div.appendChild(header);
        div.appendChild(inputWrapper);
        container.appendChild(div);
    });
});
