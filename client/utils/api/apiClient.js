const axios = require("axios");

const apiClient = axios.create({
    baseURL: "https://localhost:7250/api", // ← змінюй при потребі
    headers: {
        "Content-Type": "application/json",
    },
});

module.exports = {
    apiClient,
};
 