const { createAsyncThunk } = require("@reduxjs/toolkit");
const { apiClient } = require("../../utils/api/apiClient");

// Отримати список категорій
const getCategories = createAsyncThunk(
  "category/getCategories",
  async (_, thunkAPI) => {
    try {
      const response = await apiClient.get("/Category/get-list-of-categories-with-items-lists");
      сonsole.log("✅ API response:", response.data); 
      return response.data;
    } catch (error) {
        console.error("[getCategories] ERROR:", err);
        console.error("❌ Помилка при запиті категорій:", err);

      return thunkAPI.rejectWithValue("Cannot fetch categories");
    }
  }
);
 
module.exports = {
  getCategories,
  
};
