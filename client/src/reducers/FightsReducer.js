import * as actionTypes from '../actions/actionTypes';

const fightReducerInitialState = {
    fetching: false,
    fetched: false,
    error: null,
    draws: [],
    contestCategoryFights: [],
    generating: false,
    tossingup: false
}
const fightReducer = (state = fightReducerInitialState, action) => {
    switch (action.type) {
        case actionTypes.FETCH_FIGHTS_DRAWS:
            return {
                ...state,
                fetching: true
            }
        case actionTypes.FETCH_FIGHTS_DRAWS_SUCCESS:
            return {
                ...state,
                fetching: false,
                fetched: true,
                draws: action.payload
            }
        case actionTypes.FETCH_FIGHTS_DRAWS_REJECTED:
            return {
                ...state,
                fetching: false,
                error: action.payload
            }
        case actionTypes.GENERATE_FIGHTS:
            return {
                ...state,
                generating: true
            }
        case actionTypes.GENERATE_FIGHTS_SUCCESS:
            return {
                ...state,
                generating: false,
                draws: action.payload
            }
        case actionTypes.GENERATE_FIGHTS_REJECTED:
            return {
                ...state,
                generating: false
            }
        case actionTypes.REGENERATE_FIGHTS:
            return {
                ...state,
                generating: true
            }
        case actionTypes.REGENERATE_FIGHTS_SUCCESS:
            return {
                ...state,
                generating: false,
                draws: action.payload
            }
        case actionTypes.REGENERATE_FIGHTS_REJECTED:
            return {
                ...state,
                generating: false
            }
        case actionTypes.TOSSUP_CONTEST_FIGHTS:
            return {
                ...state,
                tossingup: true
            }
        case actionTypes.TOSSUP_CONTEST_FIGHTS_SUCCESS:
            return {
                ...state,
                tossingup: false,
                draws: action.payload
            }
        case actionTypes.TOSSUP_CONTEST_FIGHTS_REJECTED:
            return {
                ...state,
                tossingup: false
            }
        case actionTypes.FETCH_CONTEST_CATEGORY_FIGHTS:
            return {
                ...state,
                fetching: true
            }
        case actionTypes.FETCH_CONTEST_CATEGORY_FIGHTS_SUCCESS:
            return {
                ...state,
                fetching: false,
                contestCategoryFights: action.payload
            }
        case actionTypes.FETCH_CONTEST_CATEGORY_FIGHTS_REJECTED:
            return {
                ...state,
                fetching: false
            }
        default:
            return state;

    }
}

export default fightReducer;