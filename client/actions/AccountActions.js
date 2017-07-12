import {host} from "../global"
import axios from "axios";

const loginAccountRequest = (account) => {
    axios
        .post(host + "api/account/login", account)
        .then((response) => {
            return {type: "LOGIN_ACCOUNT_SUCCESS", payload: response.data}
        })
        .catch((err) => {
            return {type: "LOGIN_ACCOUNT_REJECTED", payload: err}
        })
}

const registerAccountRequest = (account) => {
    axios
        .post(host + "api/account/register", account)
        .then((response) => {
            return {type: "REGISTER_ACCOUNT_SUCCESS", payload: response.data}
        })
        .catch((err) => {
            return {type: "REGISTER_ACCOUNT_REJECTED", payload: err}
        })
}

const confirmEmailRequest = (confirmEmail) => {
    axios
        .get(host + "api/account/confirmemail", {
        params: {
            userId: confirmEmail.userid,
            code: confirmEmail.code
        }
    })
        .then((response) => {
            return {type: "CONFIRM_EMAIL_SUCCESS", payload: response.data}
        })
        .catch((err) => {
            return {type: "CONFIRM_EMAIL_REJECTED", payload: err}
        })
}

export default function loginAccount(account) {
    return {type: "LOGIN_ACCOUNT_REQUEST", loginAccountRequest(account)}
}

export default function registerAccount(account) {
    return {type: 'REGISTER_ACCOUNT_REQUEST', registerAccountRequest(account)}
}

export default function confirmEmail(confirmEmail) {
    return {type: 'CONFIRM_EMAIL_REQUEST', confirmEmailRequest(confirmEmail)}
}