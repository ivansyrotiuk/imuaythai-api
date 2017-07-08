export default function reducer(state = {
  type:null,
  fetching: false,
  fetched: false,
  error: null
}, action) {

  switch (action.type) {
      
    case "SAVE_STYPE":
      {

        const type = action.payload
          return {
            ...state,
            type: action.payload
          }
      }

      

    case "DELETE_STYPE":
      {
        return {
          ...state,
          type: null
        }
      }

    case "FETCH_STYPE":
      {
        return {
          ...state,
          fetching: true,
          fetched: false
        }
      }

      case "FETCH_STYPE_REJECTED":
      {
        return {
          ...state
        //   ,
        //   fetching: false,
        //   fetched :false,
        //   error: action.payload
        }
      }

    case "FETCH_STYPE_FULFILLED":
      {
        return {
          ...state,
          fetching: false,
          fetched: true,
          type: action.payload
        }
      }
  }
  return state
}