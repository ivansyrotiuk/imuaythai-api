import * as actionTypes from '../actions/actionTypes'

const contestCategoriesInitialState = {
    categories: [],
    fetching: false,
    error: null
}
export default function (state = contestCategoriesInitialState, action) {
    switch (action.type) {
        case actionTypes.FETCH_CONTEST_CATEGORIES:
            return {
                ...state,
                fetching: true
            }
        case actionTypes.FETCH_CONTEST_CATEGORIES_FULFILLED:
            return {
                ...state,
                fetching: false,
                categories: action.payload
            }
        case actionTypes.FETCH_CONTEST_CATEGORIES_REJECTED:
            return {
                ...state,
                fetching: false,
                error: action.payload
            }
        default:
            return state
    }
}