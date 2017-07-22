export default function reducer(state = {
  points: [],
  fetching: false,
  fetched: false,
  error: null
}, action) {

  switch (action.type) {
    case "FETCH_POINTS":
      {
        return {
          ...state,
          fetching: true
        }
      }

    case "FETCH_POINTS_REJECTED":
      {
        return {
          ...state,
          fetching: false,
          error: action.payload
        }
      }

    case "FETCH_POINTS_FULFILLED":
      {
        return {
          ...state,
          fetching: false,
          fetched: true,
          points: action.payload
        }
      }

    case "SAVE_POINT":
      {

        const point = action.payload
        const newTypes = [...state.points]
        const pointToUpdate = newTypes.findIndex(t => t.id === point.id)
        if (pointToUpdate > -1) {
          newTypes[pointToUpdate] = point;
          return {
            ...state,
            points: newTypes
          }
        } else {
          return {
            ...state,
            points: [...state.points, point]
          }
        }

      }

    case "DELETE_POINT":
      {
        return {
          ...state,
          points: state
            .points
            .filter(t => t.id !== action.payload)
        }
      }
    
  }
  return state
}