// features/categories/categoriesSlice.js
const { createSlice, createAsyncThunk } = require('@reduxjs/toolkit');
const { fetchCategoriesFromApi } = require('./categoriesService');

const fetchCategories = createAsyncThunk('categories/fetch', async () => {
  const data = await fetchCategoriesFromApi();
  return data;
});

const categoriesSlice = createSlice({
  name: 'categories',
  initialState: {
    items: [],
    status: 'idle',
    error: null
  },
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchCategories.pending, (state) => {
        state.status = 'loading';
      })
      .addCase(fetchCategories.fulfilled, (state, action) => {
        state.status = 'succeeded';
        state.items = action.payload;
      })
      .addCase(fetchCategories.rejected, (state, action) => {
        state.status = 'failed';
        state.error = action.error.message;
      });
  }
});

module.exports = {
  categoriesReducer: categoriesSlice.reducer,
  fetchCategories
};
