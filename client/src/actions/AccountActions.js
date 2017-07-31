import { host } from "../global"
import axios from "axios";
import * as actionTypes from './actionTypes';

function receiveAction(type, payload) {
    return {
        type,
        payload
    }
}

function receiveErrorAction(type, error) {
    return {
        type,
        error
    }
}

function requestAction(type, payload) {
    return {
        type,
        payload
    }
}

export function getLoginAccount(account) {
    return function(dispatch) {
        dispatch(requestAction(actionTypes.LOGIN_ACCOUNT_REQUEST, account))

        return axios
            .post(host + "api/account/login", account)
            .then((response) => {
                dispatch(receiveAction(actionTypes.LOGIN_ACCOUNT_SUCCESS, response.data))
            })
            .catch((err) => {
                dispatch(receiveErrorAction(actionTypes.LOGIN_ACCOUNT_REJECTED, err.response != null
                    ? err.response.data
                    : "Cannot connect to server"))
            })
    }
}

export function getRegisterAccount(account) {
    return function(dispatch) {
        dispatch(requestAction(actionTypes.REGISTER_ACCOUNT_REQUEST, account))

        return axios
            .post(host + "api/account/register", account)
            .then((response) => {
                dispatch(receiveAction(actionTypes.REGISTER_ACCOUNT_SUCCESS, response.data))
            })
            .catch((err) => {
                dispatch(receiveErrorAction(actionTypes.LOGIN_ACCOUNT_REJECTED, err.response.data))
            })
    }
}

export function getConfirmAccount(confirmEmail) {
    return function(dispatch) {
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
                dispatch(receiveErrorAction(actionTypes.CONFIRM_EMAIL_REJECTED, err.response.data))
            })
    }
}

export function getForgotPassword(forgotPassword) {
    return function(dispatch) {
        dispatch(requestAction(actionTypes.FORGOT_PASSWORD_REQUEST, forgotPassword))

        return axios
            .post(host + "api/account/forgotpassword", forgotPassword)
            .then((response) => {
                dispatch(receiveAction(actionTypes.FORGOT_PASSWORD_SUCCESS, response.data))
            })
            .catch((err) => {
                dispatch(receiveErrorAction(actionTypes.FORGOT_PASSWORD_REJECTED, err.response.data))
            })
    }
}

export function getResetPassword(resetPassword) {
    return function(dispatch) {
        dispatch(requestAction(actionTypes.RESET_PASSWORD_REQUEST, resetPassword))

        return axios
            .post(host + "api/account/resetpassword", resetPassword)
            .then((response) => {
                dispatch(receiveAction(actionTypes.RESET_PASSWORD_SUCCESS, response.data))
            })
            .catch((err) => {
                dispatch(receiveErrorAction(actionTypes.REGISTER_ACCOUNT_REJECTED, err.response.data))
            })
    }
}

export function errorAction(errorMessage) {
    return function(dispatch) {
        dispatch(receiveErrorAction(actionTypes.ERROR_OCCCURED, errorMessage));
    }
}

export function resetErrorAction() {
    return function(dispatch) {
        dispatch(requestAction(actionTypes.RESET_ERRORS))
    }
}

export function finishRegister(finishData) {
    return function(dispatch) {
        return axios
            .post(host + "api/account/register/finish", finishData)
            .then((response) => {
                dispatch({
                    type: actionTypes.FINISH_REGISTRATION_SUCCESS,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FINISH_REGISTRATION_REJECTED,
                    payload: err
                })
            })
    }
}