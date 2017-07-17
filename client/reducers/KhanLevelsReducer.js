export default function reducer(state = {
  levels: [],
  fetching: false,
  fetched: false,
  error: null
}, action) {

  switch (action.type) {
    case "FETCH_LEVELS":
      {
        return {
          ...state,
          fetching: true
        }
      }

    case "FETCH_LEVELS_REJECTED":
      {
        return {
          ...state,
          fetching: false,
          error: action.payload
        }
      }

    case "FETCH_LEVELS_FULFILLED":
      {
        return {
          ...state,
          fetching: false,
          fetched: true,
          levels: action.payload
        }
      }

    case "SAVE_LEVEL":
      {

        const level = action.payload
        const newLevels = [...state.levels]
        const levelToUpdate = newLevels.findIndex(t => t.id === level.id)
        if (levelToUpdate > -1) {
          newLevels[levelToUpdate] = level;
          return {
            ...state,
            levels: newLevels
          }
        } else {
          return {
            ...state,
            levels: [...state.levels, level]
          }
        }

      }

    case "DELETE_LEVEL":
      {
        return {
          ...state,
          levels: state
            .levels
            .filter(t => t.id !== action.payload)
        }
      }
    
  }
  return state
}