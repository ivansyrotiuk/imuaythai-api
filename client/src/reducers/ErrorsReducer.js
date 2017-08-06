import * as actionType from '../actions/actionTypes'

const errorsInitialState = {
    error: null
}
export default function (state = errorsInitialState, action) {
    switch (action.type) {
        case actionType.SHOW_ERROR:
            return {
                ...state,
                error: action.payload
            }
        case actionType.RESET_ERROR:
            return {
                ...state,
                error: null
            }
        default:
            return state
    }
}