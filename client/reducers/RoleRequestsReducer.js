import * as actionTypes from "../actions/actionTypes"

const roleRequestsInitialState = {
    roleRequests: [],
    fetching: false,
    fetched: false
}
export default function reducer (state = roleRequestsInitialState, action) {
    switch (action.type) {
        case actionTypes.FETCH_ROLES_REQUESTS:
            return {
                ...state,
                fetching: true
            }
        case actionTypes.FETCH_ROLES_REQUESTS_FULLFILED:
            return {
                ...state,
                roleRequests: action.payload,
                fetching: false,
                fetched: true
            }
        case actionTypes.FETCH_ROLES_REQUESTS_REJECTED:
            return {
                ...state,
                err: action.payload,
                fetching: false,
                fetched: false
            }
        default:
            return state
    }
}