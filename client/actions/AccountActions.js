import {host} from "../global"
import axios from "axios";
import * as actionTypes from './actionTypes';

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
        dispatch(requestAction(actionTypes.LOGIN_ACCOUNT_REQUEST, account))

        return axios
            .post(host + "api/account/login", account)
            .then((response) => {
                dispatch(receiveAction(actionTypes.LOGIN_ACCOUNT_SUCCESS, response.data))
            })
            .catch((err) => {
                dispatch(receiveErrorAction(actionTypes.LOGIN_ACCOUNT_REJECTED, err.response != null
                    ? err.response.data
                    : "No internet connection"))
            })
    }
}

export function getRegisterAccount(account) {
    return function (dispatch) {
        dispatch(requestAction(actionTypes.REGISTER_ACCOUNT_REQUEST, account))

        return axios
            .post(host + "api/account/register", account)
            .then((response) => {
                dispatch(receiveAction(actionTypes.REGISTER_ACCOUNT_SUCCESS, response.data))
            })
            .catch((err) => {
                dispatch(receiveErrorAction(actionTypes.LOGIN_ACCOUNT_REJECTED, err))
            })
    }
}

export function getConfirmAccount(confirmEmail) {
    return function (dispatch) {
        dispatch(requestAction(actionTypes.CONFIRM_EMAIL_REQUEST, confirmEmail))

        return axios
            .get(host + "api/account/confirmemail", {
            params: {
                userId: confirmEmail.userid,
                code: confirmEmail.code
            }
        })
            .then((response) => {
                dispatch(receiveAction(actionTypes.CONFIRM_EMAIL_SUCCESS, response.data))
            })
            .catch((err) => {
                dispatch(receiveErrorAction(actionTypes.CONFIRM_EMAIL_REJECTED, err))
            })
    }
}

export function getForgotPassword(forgotPassword) {
    return function (dispatch) {
        dispatch(requestAction(actionTypes.FORGOT_PASSWORD_REQUEST, forgotPassword))

        return axios
            .post(host + "api/account/forgotpassword", forgotPassword)
            .then((response) => {
                dispatch(receiveAction(actionTypes.FORGOT_PASSWORD_SUCCESS, response.data))
            })
            .catch((err) => {
                dispatch(receiveErrorAction(actionTypes.FORGOT_PASSWORD_REJECTED, err))
            })
    }
}

export function getResetPassword(resetPassword) {
    return function (dispatch) {
        dispatch(requestAction(actionTypes.RESET_PASSWORD_REQUEST, resetPassword))

        return axios
            .post(host + "api/account/resetpassword", resetPassword)
            .then((response) => {
                dispatch(receiveAction(actionTypes.RESET_PASSWORD_SUCCESS, response.data))
            })
            .catch((err) => {
                dispatch(receiveErrorAction(actionTypes.REGISTER_ACCOUNT_REJECTED, err))
            })
    }
}