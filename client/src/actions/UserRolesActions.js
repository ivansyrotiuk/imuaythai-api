import { host } from "../global"
import axios from "axios";
import * as actionTypes from "./actionTypes"

export function fetchUserRoles(id) {
    return function(dispatch) {
        dispatch({
            type: actionTypes.FETCH_USER_ROLES
        });
        axios
            .get(host + "api/users/roles/" + id)
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_USER_ROLES_FULFILLED,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_USER_ROLES_REJECTED,
                    payload: err
                })
            })
    }
}

export function fetchUserAvailableFederation(userId) {
    return function(dispatch) {
        dispatch({
            type: actionTypes.FETCH_AVAILABLE_FEDERATIONS
        });
        axios
            .get(host + "api/institutions/federations/useravailable?userId=" + userId)
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_AVAILABLE_FEDERATIONS_FULFILLED,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_AVAILABLE_FEDERATIONS_REJECTED,
                    payload: err
                })
            })
    }
}

export function saveUserRoleRequest(roleRequest) {
    return function(dispatch) {
        dispatch({
            type: actionTypes.SAVE_USER_ROLE
        });
        return axios
            .post(host + "api/users/roles/addrequest", roleRequest)
            .then((response) => {
                dispatch({
                    type: actionTypes.SAVE_USER_ROLE_SUCCESS,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.SAVE_USER_ROLE,
                    payload: err
                })
            })
    }
}

export function addUserRole() {
    return {
        type: actionTypes.ADD_USER_ROLE
    }
}

export function setRequestedRole(requestedRole) {
    return {
        type: actionTypes.SET_REQUESTED_ROLE,
        payload: requestedRole
    }
}

export function cancelAddingUserRole() {
    return {
        type: actionTypes.CANCEL_ADD_USER_ROLE
    }
}