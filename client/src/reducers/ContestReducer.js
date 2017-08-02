import * as actionTypes from '../actions/actionTypes';

const reducerInitialState = {
    fetching: false,
    error: null,
    fetched: false,
    contests: [],
    singleContest: null,
    candidates: [],
    requests: [],
    showRequestForm: false,
    singleRequest: null
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
        case actionTypes.FETCH_CONTEST_CANDIDATES:
            return {
                ...state,
                fetching: true
            }
        case actionTypes.FETCH_CONTEST_CANDIDATES_FULFILLED:
            return {
                ...state,
                fetching: false,
                fetched: true,
                candidates: action.payload
            }
        case actionTypes.FETCH_CONTEST_CANDIDATES_REJECTED:
            return {
                ...state,
                fetching: false,
                fetched: true,
                error: action.payload
            }
        case actionTypes.SAVE_CONTEST:
            return state;
        case actionTypes.SAVE_CONTEST_SUCCESS:
            return {
                ...state,
                fetching: false,
                fetched: true
            }

        case actionTypes.SAVE_CONTEST_REJECTED:
            return state;
        case actionTypes.ADD_CONTEST_REQUEST:
            return {
                ...state,
                showRequestForm: true,
                singleRequest: action.payload
            }
        case actionTypes.CANCEL_CONTEST_REQUEST:
            return {
                ...state,
                showRequestForm: false,
                singleRequest: null
            }
        case actionTypes.SAVE_CONTEST_REQUEST:
            return state;
        case actionTypes.SAVE_CONTEST_REQUEST_SUCCESS:
            return {
                ...state,
                showRequestForm: false,
                singleRequest: null,
                requests: [...state.requests, action.payload]
            }
        case actionTypes.SAVE_CONTEST_REQUEST_REJECTED:
            return {
                ...state,
                error: action.payload
            }
        case actionTypes.FETCH_CONTEST_REQUESTS:
            return {
                ...state,
                fetching: true
            }
        case actionTypes.FETCH_CONTEST_REQUESTS_FULFILLED:
            return {
                ...state,
                fetching: false,
                requests: action.payload
            }
        case actionTypes.FETCH_CONTEST_REQUESTS_REJECTED:
            return {
                ...state,
                fetching: true,
                error: action.payload
            }
        default:
            return state
    }
}

export default reducer;