export default function reducer(state = {
  types: [],
  fetching: false,
  fetched: false,
  error: null
}, action) {

  switch (action.type) {
    case "FETCH_TYPES":
      {
        return {
          ...state,
          fetching: true
        }
      }

    case "FETCH_TYPES_REJECTED":
      {
        return {
          ...state,
          fetching: false,
          error: action.payload
        }
      }

    case "FETCH_TYPES_FULFILLED":
      {
        return {
          ...state,
          fetching: false,
          fetched: true,
          types: action.payload
        }
      }

    case "SAVE_TYPE":
      {

        const type = action.payload
        const newTypes = [...state.types]
        const typeToUpdate = newTypes.findIndex(t => t.id === type.id)
        if (typeToUpdate > -1) {
          newTypes[typeToUpdate] = type;
          return {
            ...state,
            types: newTypes
          }
        } else {
          return {
            ...state,
            types: [...state.types, type]
          }
        }

      }

    case "DELETE_TYPE":
      {
        return {
          ...state,
          types: state
            .types
            .filter(t => t.id !== action.payload)
        }
      }
    
  }
  return state
}