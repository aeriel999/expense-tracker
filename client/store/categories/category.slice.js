const { createSlice } = require("@reduxjs/toolkit");
const { getCategories } = require("./category.actions");

const initialState = {
    items: [],
    status: "idle",
    error: null,
};

const categorySlice = createSlice({
    name: "category",
    initialState,
    reducers: {
        clearCategories(state) {
            state.items = [];
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(getCategories.pending, (state) => {
                state.status = "loading";
                console.log("loading");
            })
            .addCase(getCategories.fulfilled, (state, action) => {
                state.status = "succeeded";
                state.items = action.payload;
                console.log("succeeded", action.payload);
            })
            .addCase(getCategories.rejected, (state, action) => {
                state.status = "failed";
                state.error = action.payload;
                console.log("failed", state.error);
            });
    },
});

module.exports = {
    categoryReducer: categorySlice.reducer,
    clearCategories: categorySlice.actions.clearCategories,
};
