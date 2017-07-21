import * as actionTypes from "../actions/actionTypes"

const userRolesInitialState = {
    roles: [],
    fetching: false,
    fetched: false,
    saving: false,
    saved: false,
    error: null
}

const userRoles = (state = userRolesInitialState, action) => {
    switch (action.type) {
        case actionTypes.FETCH_USER_ROLES:
            return {
                ...state,
                fetching: true
            }
        case actionTypes.FETCH_USER_ROLES_FULLFILED:
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
                fetching: false,
                fetched: false
            }
        case actionTypes.SAVE_USER_ROLE_SUCCESS:
            return {
                ...state,
                roles: [state.roles, action.payload],
                fetching: false,
                fetched: true
            }
        default:
            return state
    }
}

export default userRoles;