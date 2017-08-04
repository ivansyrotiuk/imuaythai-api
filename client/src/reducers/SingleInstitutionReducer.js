import * as actionTypes from '../actions/actionTypes';

const singleInstitutionInitialState = {
    institution: null,
    fetching: false,
    error: null,
    saved: false,
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
        case actionTypes.ADD_INSTITUTION:
            return {
                ...state,
                institution: action.payload
            }
        case actionTypes.RESET_INSTITUTION:
            return {
                ...state,
                institution: null,
                saved: false
            }
        case actionTypes.SAVE_INSTITUTION_SUCCESS:
            return {
                ...state,
                saved: true
            }
        default:
            return state
    }
}