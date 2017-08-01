import * as actionTypes from '../actions/actionTypes';

const reducerInitialState = {
    fetching: false,
    error: null,
    fetched: false,
    singleContest: null,
    contests: []
}
const reducer = (state = reducerInitialState, action) => {
    switch (action.type) {
        case actionTypes.ADD_NEW_CONTEST:
            return {
                ...state,
                singleContest: action.payload
            }
        case actionTypes.FETCH_CONTESTS:
            return {
                ...state,
                fetching: true
            }
        case actionTypes.FETCH_CONTESTS_FULFILLED:
            return {
                ...state,
                fetching: false,
                fetched: true,
                contests: action.payload
            }
        case actionTypes.FETCH_CONTESTS:
            return {
                ...state,
                fetching: false,
                fetched: false,
                error: action.payload
            }
        case actionTypes.FETCH_SINGLE_CONTEST:
            return {
                ...state,
                fetching: true
            }
        case actionTypes.FETCH_SINGLE_CONTEST_FULFILLED:
            return {
                ...state,
                fetching: false,
                fetched: true,
                singleContest: action.payload
            }
        case actionTypes.FETCH_SINGLE_CONTEST_REJECTED:
            return {
                ...state,
                fetching: false,
                fetched: true,
                error: action.payload
            }
        case actionTypes.SAVE_CONTEST_REQUEST:
            return state;
        case actionTypes.SAVE_CONTEST_SUCCESS:
            return {
                ...state,
                fetching: false,
                fetched: true
            }

        case actionTypes.SAVE_CONTEST_REJECTED:
            return state;

        default:
            return state
    }
}

export default reducer;