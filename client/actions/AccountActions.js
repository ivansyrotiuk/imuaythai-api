import {host} from "../global"
import axios from "axios";

function receiveAction(type, payload) {
    return {type, payload}
}

function receiveErrorAction(type, error) {
    return {type, error}
}

function requestAction(type, payload) {
    return {type, payload}
}

export function getLoginAccount(account) {
    return function (dispatch) {
        dispatch(requestAction("LOGIN_ACCOUNT_REQUEST", account))

        return axios
            .post(host + "api/account/login", account)
            .then((response) => {
                dispatch(receiveAction("LOGIN_ACCOUNT_SUCCESS", response.data))
            })
            .catch((err) => {
                dispatch(receiveErrorAction("LOGIN_ACCOUNT_REJECTED", err))
            })
    }
}

export function getRegisterAccount(account) {
    return function (dispatch) {
        dispatch(requestAction("REGISTER_ACCOUNT_REQEST", account))

        return axios
            .post(host + "api/account/register", account)
            .then((response) => {
                dispatch(receiveAction("REGISTER_ACCOUNT_SUCCESS", response.data))
            })
            .catch((err) => {
                dispatch(receiveErrorAction("REGISTER_ACCOUNT_REJECTED", err))
            })
    }
}

export function getConfirmAccount(confirmEmail) {
    return function (dispatch) {
        dispatch(requestAction("CONFIRM_EMAIL_REQUEST", confirmEmail))

        return axios
            .get(host + "api/account/confirmemail", {
            params: {
                userId: confirmEmail.userid,
                code: confirmEmail.code
            }
        })
            .then((response) => {
                dispatch(receiveAction("CONFIRM_EMAIL_SUCCESS", response.data))
            })
            .catch((err) => {
                dispatch(receiveErrorAction("CONFIRM_EMAIL_REJECTED", err))
            })
    }
}

export function getForgotPassword(forgotPassword) {
    return function (dispatch) {
        dispatch(requestAction("FORGOT_PASSWORD_REQUEST", forgotPassword))

        return axios
            .post(host + "api/account/forgotpassword", forgotPassword)
            .then((response) => {
                dispatch(receiveAction("FORGOT_PASSWORD_SUCCESS", response.data))
            })
            .catch((err) => {
                dispatch(receiveErrorAction("FORGOT_PASSWORD_REJECTED", err))
            })
    }
}