import jwtDecode from 'jwt-decode';
import * as actionTypes from '../actions/actionTypes';

export default function reduer(state = {
        authToken: '',
        user: null,
        fetching: false,
        fetchingUser: false,
        fetchedUser: false,
        isRegistered: false,
        isLoggedIn: false,
        isResseted: false,
        isConfimed: false,
        fetched: false,
        rememberMe: false,
        error: null,
        loggedUser: null,
        qrcode: ''
    } , action) {

    switch (action.type) {
        case actionTypes.LOGIN_ACCOUNT_REQUEST:
        case actionTypes.REGISTER_ACCOUNT_REQUEST:
        case actionTypes.CONFIRM_EMAIL_REQUEST:
        case actionTypes.FORGOT_PASSWORD_REQUEST:
        case actionTypes.RESET_PASSWORD_REQUEST:
            return {
                ...state,
                fetching: true,
                isRegistered: false,
                isLoggedIn: false,
                isResseted: false,
                isConfimed: false,
                fetched: false,
                error: null
            }

        case actionTypes.FETCH_LOGGED_USER_REQUEST:
        case actionTypes.SAVE_LOGGED_USER_REQUEST:
            return {
                ...state,
                fetchingUser: true,
                fetchedUser: false
            }

        case actionTypes.LOGIN_ACCOUNT_REJECTED:
        case actionTypes.REGISTER_ACCOUNT_REJECTED:
        case actionTypes.CONFIRM_EMAIL_REJECTED:
        case actionTypes.FORGOT_PASSWORD_REJECTED:
        case actionTypes.RESET_PASSWORD_REJECTED:
        case actionTypes.ERROR_OCCCURED:
            return {
                ...state,
                fetching: false,
                error: action.payload
            }

        case actionTypes.FETCH_LOGGED_USER_REJECTED:
        case actionTypes.SAVE_LOGGED_USER_REJECTED:
            return {
                ...state,
                fetchingUser: false,
                error: action.payload
            }

        case actionTypes.LOGIN_ACCOUNT_SUCCESS:
            return {
                ...state,
                fetching: false,
                isLoggedIn: true,
                error: null,
                authToken: action.payload.authToken,
                qrcode: action.payload.qrcode,
                rememberMe: action.payload.rememberMe,
                user: jwtDecode(action.payload.authToken)
            }
        case actionTypes.REGISTER_ACCOUNT_SUCCESS:
            return {
                ...state,
                fetching: false,
                isRegistered: true,
                error: null
            }
        case actionTypes.CONFIRM_EMAIL_SUCCESS:
            return {
                ...state,
                fetching: false,
                isConfimed: true,
                error: null
            }
        case actionTypes.FORGOT_PASSWORD_SUCCESS:
            return {
                ...state,
                fetching: false,
                fetched: true,
                error: null
            }
        case actionTypes.RESET_PASSWORD_SUCCESS:
            return {
                ...state,
                fetching: false,
                isResseted: true,
                error: null
            }
        case actionTypes.RESET_ERRORS:
            return {
                ...state,
                error: null,
                isRegistered: false,
                isLoggedIn: false,
                isResseted: false,
                isConfimed: false,
                fetched: false,
            }
        case actionTypes.FINISH_REGISTRATION_SUCCESS:
            return {
                ...state,
                authToken: action.payload,
                user: jwtDecode(action.payload)
            }
        case actionTypes.FINISH_REGISTRATION_REJECTED:
            return {
                ...state,
                error: action.payload,
            }
        case actionTypes.ACCOUNT_LOGOUT:
            return {
                ...state,
                authToken: '',
                loggedUser: null,
                user: null,
                qrcode: ''
            }
        case actionTypes.FETCH_LOGGED_USER_SUCCESS:
            return {
                ...state,
                loggedUser: action.payload,
                fetchingUser: false
            }
        case actionTypes.SAVE_LOGGED_USER_SUCCESS:
            return {
                ...state,
                loggedUser: action.payload,
                fetchingUser: false,
                fetchedUser: true

            }
        default:
            return state;
    }
}
;