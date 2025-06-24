const { configureStore } = require("@reduxjs/toolkit");
const categoryReducer = require("./categories/category.slice");

const store = configureStore({
    reducer: {
        category: categoryReducer,
    },
});

module.exports = store;
