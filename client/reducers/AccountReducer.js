import jwtDecode from 'jwt-decode';
import * as actionTypes from '../actions/actionTypes';

export default function reduer(state = {
    authToken: '',
    fetching: false,
    fetched: false,
    rememberMe: false,
    error: null
}, action) {
    switch (action.type) {
        case actionTypes.LOGIN_ACCOUNT_REQUEST:
        case actionTypes.REGISTER_ACCOUNT_REQUEST:
        case actionTypes.CONFIRM_EMAIL_REQUEST:
        case actionTypes.FORGOT_PASSWORD_REQUEST:
        case actionTypes.RESET_PASSWORD_REQUEST:
            return {
                ...state,
                fetching: true,
                fetched: false
            }

        case actionTypes.LOGIN_ACCOUNT_REJECTED:
        case actionTypes.REGISTER_ACCOUNT_REJECTED:
        case actionTypes.CONFIRM_EMAIL_REJECTED:
        case actionTypes.FORGOT_PASSWORD_REJECTED:
        case actionTypes.RESET_PASSWORD_REJECTED:
            return {
                ...state,
                fetching: false,
                error: action.error
            }

        case actionTypes.LOGIN_ACCOUNT_SUCCESS:
            return {
                ...state,
                fetching: false,
                fetched: true,
                error: null,
                authToken: action.payload.authToken,
                rememberMe: action.payload.rememberMe,
                user : jwtDecode(action.payload.authToken)
            }
        case actionTypes.REGISTER_ACCOUNT_SUCCESS:
        case actionTypes.CONFIRM_EMAIL_SUCCESS:
        case actionTypes.FORGOT_PASSWORD_SUCCESS:
        case actionTypes.RESET_PASSWORD_SUCCESS:
            return {
                ...state,
                fetching: false,
                fetched: true,
                error: null
            }

        default:
            return state;
    }
};