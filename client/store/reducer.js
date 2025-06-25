// Початковий стан
const initialState = {
  count: 0,
  categories: []
};

// Ред'юсер — обробка змін стану
function rootReducer(state = initialState, action) {
  switch (action.type) {
    case "INCREMENT":
      return { ...state, count: state.count + 1 };

    case "DECREMENT":
      return { ...state, count: state.count - 1 };

    case "SET_CATEGORIES":
      return { ...state, categories: action.payload };

    default:
      return state;
  }
}

module.exports = rootReducer;
