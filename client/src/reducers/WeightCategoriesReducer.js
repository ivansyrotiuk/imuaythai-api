export default function reducer(state = {
    categories: [],
    fetching: false,
    fetched: false,
    error: null
  } , action) {

  switch (action.type) {
    case "FETCH_WEIGHT_CATEGORIES": {
      return {
        ...state,
        fetching: true
      }
    }
    case "FETCH_WEIGHT_CATEGORIES_REJECTED": {
      return {
        ...state,
        fetching: false,
        error: action.payload
      }
    }
    case "FETCH_WEIGHT_CATEGORIES_FULFILLED": {
      return {
        ...state,
        fetching: false,
        fetched: true,
        categories: action.payload
      }
    }
    case "SAVE_WEIGHT_CATEGORY": {

      const category = action.payload
      const newCategories = [...state.categories]
      const categoryToUpdate = newCategories.findIndex(t => t.id === category.id)
      if (categoryToUpdate > -1) {
        newCategories[categoryToUpdate] = category;
        return {
          ...state,
          categories: newCategories
        }
      } else {
        return {
          ...state,
          categories: [...state.categories, category]
        }
      }

    }
    case "DELETE_WEIGHT_CATEGORY": {
      return {
        ...state,
        categories: state
          .categories
          .filter(t => t.id !== action.payload)
      }
    }
  }
  return state
}