import {combineReducers} from 'redux'

function accountLoginReducer(state = {
    authToken: '',
    userId: null,
    fetching: false,
    error: null
}, action) {
    switch (action.type) {
        case "LOGIN_ACCOUNT_REQUEST":
            return {
                ...state,
                fetching: true
            }

        case "LOGIN_ACCOUNT_REJECTED":
            return {
                ...state,
                fetching: false,
                error: action.payload
            }

        case "LOGIN_ACCOUNT_SUCCESS":
            return {
                ...state,
                fetching: false,
                userId: action.payload.userId,
                authToken: action.payload.authToken
            }
        default:
            return state;
    }
};

function accountRegisterReducer(state = {
    fetching: false,
    error: null
}, action) {
    switch (action.type) {
        case "REGISTER_ACCOUNT_REQUEST":
        case "CONFIRM_EMAIL_REQUEST":
            return {
                ...state,
                fetching: true
            }

        case "REGISTER_ACCOUNT_SUCCESS":
        case "CONFIRM_EMAIL_SUCCESS":
            return {
                ...state,
                fetching: false
            }

        case "CONFIRM_EMAIL_REJECTED":
        case "REGISTER_ACCOUNT_REJECTED":
            return {
                ...state,
                fetching: false,
                error: action.payload
            }
        default:
            return state;
    }
}

const reducer = combineReducers({loginAccount: accountLoginReducer, registerAccount: accountRegisterReducer});

export default reducer;