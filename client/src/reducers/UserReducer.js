import * as actionTypes from "../actions/actionTypes"

const userInitialState = {
    user: null,
    fetching: false,
    fetched: false,
    saved: false,
    error: null,
}

export default function(state = userInitialState, action) {
    switch (action.type) {
        case actionTypes.FETCH_USER:
            return {
                ...state,
                fetching: true
            }
        case actionTypes.FETCH_USER_FULFILLED:
            return {
                ...state,
                user: action.payload,
                fetching: false,
                fetched: true
            }
        case actionTypes.FETCH_USER_REJECTED:
            return {
                ...state,
                error: action.payload,
                fetching: false,
                fetched: false
            }
        case actionTypes.SAVE_USER:
            return {
                ...state,
                saved: false
            }
        case actionTypes.SAVE_USER_SUCCESS:
            return {
                ...state,
                saved: true,
                user: action.payload
            }
        case actionTypes.SAVE_USER_REJECTED:
            return {
                ...state,
                saved: false,
                error: action.payload
            }
        default:
            return state
    }
}
