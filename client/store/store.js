const { createStore } = require("redux");
const rootReducer = require("./reducer");

// Створюємо Redux store
const store = createStore(rootReducer);

module.exports = store;
