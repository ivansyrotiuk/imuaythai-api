export default function reduer(state = {
    authToken: '',
    fetching: false,
    isRegistered: false,
    isConfirmed: false,
    rememberMe: false,
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
                authToken: action.payload.authToken,
                rememberMe: action.payload.rememberMe
            }
        case "REGISTER_ACCOUNT_SUCCESS":
            return {
                ...state,
                fetching: false,
                isRegi: true,
                error: null
            }
        case "CONFIRM_EMAIL_SUCCESS":
            return {
                ...state,
                fetching: false,
                isConfirmed: true,
                error: null
            }

        default:
            return state;
    }
};