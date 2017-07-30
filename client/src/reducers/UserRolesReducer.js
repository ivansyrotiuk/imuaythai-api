import * as actionTypes from "../actions/actionTypes"

const userRolesInitialState = {
    roles: [],
    availableFederations: [],
    requestedRole: null,
    fetching: false,
    fetched: false,
    adding: false,
    error: null
}

const userRoles = (state = userRolesInitialState, action) => {
    switch (action.type) {
        case actionTypes.ADD_USER_ROLE:
            return {
                ...state,
                adding: true
            }
        case actionTypes.CANCEL_ADD_USER_ROLE:
            return {
                ...state,
                adding: false
            }
        case actionTypes.FETCH_USER_ROLES:
            return {
                ...state,
                fetching: true
            }
        case actionTypes.FETCH_USER_ROLES_FULFILLED:
            return {
                ...state,
                roles: action.payload,
                fetching: false,
                fetched: true
            }
        case actionTypes.FETCH_USER_ROLES_REJECTED:
            return {
                ...state,
                error: action.payload,
                fetched: false
            }
        case actionTypes.FETCH_AVAILABLE_FEDERATIONS:
            return {
                ...state,
                fetching: true
            }
        case actionTypes.FETCH_AVAILABLE_FEDERATIONS_FULFILLED:
            return {
                ...state,
                availableFederations: action.payload,
                fetching: false,
                fetched: true
            }
        case actionTypes.FETCH_AVAILABLE_FEDERATIONS_REJECTED:
            return {
                ...state,
                error: action.payload,
                fetched: false
            }
        case actionTypes.SAVE_USER_ROLE:
            return state;
        case actionTypes.SAVE_USER_ROLE_SUCCESS:
            return {
                ...state,
                roles: [...state.roles, action.payload],
                adding: false
            }
        case actionTypes.SAVE_USER_ROLE_REJECTED:
            return {
                ...state,
                error: action.payload,
            }
        case actionTypes.SET_REQUESTED_ROLE:
            return {
                ...state,
                requestedRole: action.payload,
            }
        default:
            return state
    }
}

export default userRoles;