import * as actionTypes from "../actions/actionTypes"

export default function reducer(state = {
  gyms: [],
  fetching: false,
  fetched: false,
  error: null
}, action) {

  switch (action.type) {
    case actionTypes.FETCH_GYMS:
      {
        return {
          ...state,
          fetching: true
        }
      }

    case actionTypes.FETCH_GYMS_REJECTED:
      {
        return {
          ...state,
          fetching: false,
          error: action.payload
        }
      }

    case actionTypes.FETCH_GYMS_FULFILLED:
      {
        return {
          ...state,
          fetching: false,
          fetched: true,
          gyms: action.payload
        }
      }

    case "SAVE_GYM":
      {

        const gym = action.payload
        const newGyms = [...state.gyms]
        const gymToUpdate = newGyms.findIndex(g => g.id === gym.id)
        if (gymToUpdate > -1) {
          newGyms[gymToUpdate] = gym;
          return {
            ...state,
            gyms: newGyms
          }
        } else {
          return {
            ...state,
            gyms: [...state.gyms, gym]
          }
        }

      }

    case "DELETE_GYM":
      {
        return {
          ...state,
          gyms: state
            .gyms
            .filter(g => g.id !== action.payload)
        }
      }
  }
  return state
}