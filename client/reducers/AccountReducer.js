import {combineReducers} from 'redux'

export default function reduer(state = {
    authToken: '',
    userId: null,
    fetching: false,
    error: null
}, action) {
    switch (action.type) {
        case "LOGIN_ACCOUNT_REQUEST":
        case "REGISTER_ACCOUNT_REQUEST":
        case "CONFIRM_EMAIL_REQUEST":
            return {
                ...state,
                fetching: true
            }

        case "LOGIN_ACCOUNT_REJECTED":
        case "CONFIRM_EMAIL_REJECTED":
        case "REGISTER_ACCOUNT_REJECTED":
            return {
                ...state,
                fetching: false,
                error: action.error
            }

        case "LOGIN_ACCOUNT_SUCCESS":
            return {
                ...state,
                fetching: false,
                error: null,
                userId: action.payload.userId,
                authToken: action.payload.authToken
            }
        case "REGISTER_ACCOUNT_SUCCESS":
        case "CONFIRM_EMAIL_SUCCESS":
            return {
                ...state,
                fetching: false
            }

        default:
            return state;
    }
};