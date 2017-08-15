import { host } from "../global"
import axios from "axios";
import * as actionTypes from './actionTypes';
import { removeState } from '../localStorage'

function createAction(type, payload) {
    return {
        type,
        payload
    }
}

export function getLoginAccount(account) {
    return function(dispatch) {
        dispatch(createAction(actionTypes.LOGIN_ACCOUNT_REQUEST, account))

        return axios
            .post(host + "api/account/login", account)
            .then((response) => {
                dispatch(createAction(actionTypes.LOGIN_ACCOUNT_SUCCESS, response.data))
            })
            .catch((err) => {
                dispatch(createAction(actionTypes.LOGIN_ACCOUNT_REJECTED, err.response != null
                    ? err.response.data
                    : "Cannot connect to server"))
            })
    }
}

export function getRegisterAccount(account) {
    return function(dispatch) {
        dispatch(createAction(actionTypes.REGISTER_ACCOUNT_REQUEST, account))

        return axios
            .post(host + "api/account/register", account)
            .then((response) => {
                dispatch(createAction(actionTypes.REGISTER_ACCOUNT_SUCCESS, response.data))
            })
            .catch((err) => {
                dispatch(createAction(actionTypes.LOGIN_ACCOUNT_REJECTED, err.response.data))
            })
    }
}

export function getConfirmAccount(confirmEmail) {
    return function(dispatch) {
        dispatch(createAction(actionTypes.CONFIRM_EMAIL_REQUEST, confirmEmail))

        return axios
            .get(host + "api/account/confirmemail", {
                params: {
                    userId: confirmEmail.userid,
                    code: confirmEmail.code
                }
            })
            .then((response) => {
                dispatch(createAction(actionTypes.CONFIRM_EMAIL_SUCCESS, response.data))
            })
            .catch((err) => {
                dispatch(createAction(actionTypes.CONFIRM_EMAIL_REJECTED, err.response.data))
            })
    }
}

export function getForgotPassword(forgotPassword) {
    return function(dispatch) {
        dispatch(createAction(actionTypes.FORGOT_PASSWORD_REQUEST, forgotPassword))

        return axios
            .post(host + "api/account/forgotpassword", forgotPassword)
            .then((response) => {
                dispatch(createAction(actionTypes.FORGOT_PASSWORD_SUCCESS, response.data))
            })
            .catch((err) => {
                dispatch(createAction(actionTypes.FORGOT_PASSWORD_REJECTED, err.response.data))
            })
    }
}

export function getResetPassword(resetPassword) {
    return function(dispatch) {
        dispatch(createAction(actionTypes.RESET_PASSWORD_REQUEST, resetPassword))

        return axios
            .post(host + "api/account/resetpassword", resetPassword)
            .then((response) => {
                dispatch(createAction(actionTypes.RESET_PASSWORD_SUCCESS, response.data))
            })
            .catch((err) => {
                dispatch(createAction(actionTypes.REGISTER_ACCOUNT_REJECTED, err.response.data))
            })
    }
}

export function errorAction(errorMessage) {
    return function(dispatch) {
        dispatch(createAction(actionTypes.ERROR_OCCCURED, errorMessage));
    }
}

export function resetErrorAction() {
    return function(dispatch) {
        dispatch(createAction(actionTypes.RESET_ERRORS))
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

export function logout() {
    return function(dispatch) {
        removeState('authAccount')
        dispatch(createAction(actionTypes.ACCOUNT_LOGOUT))
    }
}

export function fetchUser(id) {
    return function(dispatch) {
        dispatch(createAction(actionTypes.FETCH_LOGGED_USER_REQUEST));
        axios.get(host + "api/users/" + id)
            .then((response) => {
                dispatch(createAction(actionTypes.FETCH_LOGGED_USER_SUCCESS, response.data))
            })
            .catch((err) => {
                dispatch(createAction(actionTypes.FETCH_LOGGED_USER_REJECTED, err))
            });
    }
}

export function saveUser(user) {
    return function(dispatch) {
        dispatch(createAction(actionTypes.SAVE_LOGGED_USER_REQUEST));
        return axios
            .post(host + 'api/users/save', user)
            .then(function(response) {
                dispatch(createAction(actionTypes.SAVE_LOGGED_USER_SUCCESS, response.data))
            })
            .catch(function(error) {
                dispatch(createAction(actionTypes.SAVE_LOGGED_USER_REJECTED, error))
            });
    }
}