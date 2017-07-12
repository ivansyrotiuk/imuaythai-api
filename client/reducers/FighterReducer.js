export default function reducer(state = {
  fighter: null,
  fetching: false,
  fetched: false,
  error: null
}, action) {

  switch (action.type) {
    case "FETCH_FIGTHER":
    {
        const newState =  {
            ...state,
            fetching: true,
        };
        return newState;
    }

    case "FETCH_FIGTHER_REJECTED":
      {
        return {
          ...state,
          fetching: false,
          error: action.payload
        }
      }

    case "FETCH_FIGTHER_FULFILLED":
      {
        return {
          ...state,
          fetching: false,
          fetched: true,
          fighter: action.payload
        }
      }

    case "SAVE_FIGTHER":
      {
          return {
            ...state,
            fetching: false,
            fetched: false,
            fighter: action.payload
          }
      }
  }
  return state
}