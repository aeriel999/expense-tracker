const axios = require("axios");
require("dotenv").config(); // ⬅️ Підключаємо .env

const API_URL = `${process.env.API_URL}Category/get-list-of-categories-with-items-lists`; // ⬅️ Формуємо повну URL

async function fetchCategoriesFromApi() {
  const response = await axios.get(API_URL);
  return response.data;
}

module.exports = {
  fetchCategoriesFromApi,
};
