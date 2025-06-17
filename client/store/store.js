const { configureStore } = require('@reduxjs/toolkit');
const { categoriesReducer } = require('../features/categories/categoriesSlice');

const store = configureStore({
  reducer: {
    categories: categoriesReducer
  }
});

module.exports = store;
