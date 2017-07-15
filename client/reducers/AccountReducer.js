export default function reduer(state = {
    authToken: '',
    fetching: false,
    fetched: false,
    rememberMe: false,
    error: null
}, action) {
    switch (action.type) {
        case "LOGIN_ACCOUNT_REQUEST":
        case "REGISTER_ACCOUNT_REQUEST":
        case "CONFIRM_EMAIL_REQUEST":
        case "FORGOT_PASSWORD_REQEST":
            return {
                ...state,
                fetching: true
            }

        case "LOGIN_ACCOUNT_REJECTED":
        case "CONFIRM_EMAIL_REJECTED":
        case "REGISTER_ACCOUNT_REJECTED":
        case "FORGOT_PASSWORD_REJECTED":
            return {
                ...state,
                fetching: false,
                error: action.error
            }

        case "LOGIN_ACCOUNT_SUCCESS":
            return {
                ...state,
                fetching: false,
                fetched: true,
                error: null,
                authToken: action.payload.authToken,
                rememberMe: action.payload.rememberMe
            }
        case "REGISTER_ACCOUNT_SUCCESS":
        case "CONFIRM_EMAIL_SUCCESS":
        case "FORGOT_PASSWORD_SUCCESS":
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