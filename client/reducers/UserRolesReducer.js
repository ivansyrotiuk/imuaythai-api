import * as actionTypes from "../actions/actionTypes"

const userRolesInitialState = {
    roles: [],
    fetching: false,
    fetched: false,
    adding: false,
    saving: false,
    saved: false,
    error: null
}

const userRoles = (state = userRolesInitialState, action) => {
    switch (action.type) {
        case actionTypes.ADD_USER_ROLES:
            return {
                ...state,
                adding: true
            }
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
                saving: false,
                fetched: false
            }
        case actionTypes.SAVE_USER_ROLE:
            return {
                ...state,
                saving: true,
            }
        case actionTypes.SAVE_USER_ROLE_SUCCESS:
            return {
                ...state,
                roles: [...state.roles, action.payload],
                saving: false,
                saved: true,
                adding: false
            }
        case actionTypes.SAVE_USER_ROLE_REJECTED:
            return {
                ...state,
               error: action.payload,
                saving: false,
                saved: false
            }
        default:
            return state
    }
}

export default userRoles;