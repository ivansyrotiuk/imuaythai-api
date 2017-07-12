import {host} from "../global"
import axios from "axios";

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

function receiveLoginAccount(payload){
    return {type: "REGISTER_ACCOUNT_SUCCESS", payload}
}

function receiveErrorLoginAccount(error){
    {type: "LOGIN_ACCOUNT_REJECTED", error}
}

function loginAccountRequest(account) {
    return {type: "LOGIN_ACCOUNT_REQUEST", account}
}

export function getLoginAccount(account){
    return function (dispatch){
        dispatch(loginAccountRequest(account))

        return axios
        .post(host + "api/account/login", account)
        .then((response) =>{ console.log(response)
            dispatch(receiveLoginAccount(response.data))})
        .catch((err) => {
            console.log(err) 
            dispatch(receiveErrorLoginAccount(err))})
    }
}

export function registerAccount(account) {
    return {type: 'REGISTER_ACCOUNT_REQUEST', account}
}

export function confirmEmail(confirmEmail) {
    return {type: 'CONFIRM_EMAIL_REQUEST', confirmEmail}
}