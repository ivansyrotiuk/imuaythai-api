import * as actionTypes from '../actions/actionTypes';

const reducerInitialState = {
    fetching: false,
    error: null,
    fetched: false,
    contests: []
}
export default reducer = (state = reducerInitialState, action) => {
    switch (action.type) {
        case actionTypes.SAVE_CONTEST_REQUEST:
        case actionTypes.FETCH_CONTESTS_REQUEST:
            return {
                ...state,
                fetching: true
            }
        case actionTypes.SAVE_CONTEST_SUCCESS:
            return {
                ...state,
                fetching: false,
                fetched: true
            }
        case actionTypes.SAVE_CONTEST_REJECTED:
            return {
                ...state,
                fetching: false,
                fetched: true,
                error: action.payload
            }
        default:
            return state
    }
}