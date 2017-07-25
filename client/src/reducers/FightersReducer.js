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
  }
  return state
}