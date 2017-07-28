import * as actionTypes from '../actions/actionTypes';

const singleInstitutionInitialState = {
    institution: null,
    fetching: false,
    error: null
}
export default function(state = singleInstitutionInitialState, action) {
    switch (action.type) {
        case actionTypes.FETCH_INSTITUTION:
            return {
                ...state,
                fetching: true
            }
        case actionTypes.FETCH_INSTITUTION_FULFILLED:
            return {
                ...state,
                fetching: false,
                institution: action.payload
            }
        case actionTypes.FETCH_INSTITUTION_REJECTED:
            return {
                ...state,
                fetching: false,
                error: action.payload
            }
        default:
            return state
    }
}