export default function reducer(state = {
  fighters: [],
  fetching: false,
  fetched: false,
  error: null
}, action) {

  switch (action.type) {
    case "FETCH_FIGTHERS":
      {
        return {
          ...state,
          fetching: true
        }
      }

    case "FETCH_FIGTHERS_REJECTED":
      {
        return {
          ...state,
          fetching: false,
          error: action.payload
        }
      }

    case "FETCH_FIGTHERS_FULFILLED":
      {
        return {
          ...state,
          fetching: false,
          fetched: true,
          fighters: action.payload
        }
      }

    case "SAVE_FIGTHER":
      {
        const fighter = action.payload
        const newFigthers = [...state.fighters]
        const figtherToUpdate = newFigthers.findIndex(g => g.id === fighter.id)
        if (figtherToUpdate > -1) {
          newFigthers[figtherToUpdate] = fighter;
          return {
            ...state,
            fighters: newFigthers
          }
        } else {
          return {
            ...state,
            fighters: [...state.fighters, fighter]
          }
        }

      }

    case "DELETE_FIGTHER":
      {
        return {
          ...state,
          fighters: state
            .fighters
            .filter(f => f.id !== action.payload)
        }
      }
  }
  return state
}