import * as actionTypes from '../actions/actionTypes'

const contestCategoriesInitialState = {
    categories: [],
    fetching: false,
    fetched: false,
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
                fetched: true,
                categories: action.payload
            }
        case actionTypes.FETCH_CONTEST_CATEGORIES_REJECTED:
            return {
                ...state,
                fetching: false,
                error: action.payload
            }
        case actionTypes.DELETE_CONTEST_CATEGORY:
            return {
                ...state,
                points: state
                    .points
                    .filter(t => t.id !== action.payload)
            }
        default:
            return state
    }
}