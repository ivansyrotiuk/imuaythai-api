export default function reducer(state = {
  type:null,
  fetching: false,
  fetched: false,
  error: null
}, action) {

  switch (action.type) {
      
    case "SAVE_TYPE":
      {

        const type = action.payload
          return {
            ...state,
            type: action.payload
          }
      }

      

    case "DELETE_TYPE":
      {
        return {
          ...state,
          type: null
        }
      }

    case "FETCH_TYPE":
      {
        return {
          ...state,
          fetching: true,
          fetched: false
        }
      }

      case "FETCH_TYPE_REJECTED":
      {
        return {
          ...state,
          fetching: false,
          fetched :false,
          error: action.payload
        }
      }

    case "FETCH_TYPE_FULFILLED":
      {
        return {
          ...state,
          fetching: false,
          fetched: true,
          type: action.payload
        }
      }

      case "CLEAR_TYPE":
      {
        return {
          ...state,
          type:null,
          fetching: false,
          fetched: false,
          error: null
        }
      }
  }
  return state
}