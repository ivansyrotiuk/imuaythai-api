export default function reducer(state = {
  range:null,
  fetching: false,
  fetched: false,
  error: null
}, action) {

  switch (action.type) {
      
    case "SAVE_TYPE":
      {

        const range = action.payload
          return {
            ...state,
            range: action.payload
          }
      }

      

    case "DELETE_TYPE":
      {
        return {
          ...state,
          range: null
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
          range: action.payload
        }
      }

      case "CLEAR_TYPE":
      {
        return {
          ...state,
          range:null,
          fetching: false,
          fetched: false,
          error: null
        }
      }
  }
  return state
}