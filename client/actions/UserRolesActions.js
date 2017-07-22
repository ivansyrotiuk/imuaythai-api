import {host} from "../global"
import axios from "axios";
import * as actionTypes from "./actionTypes"

export function fetchUserRoles(id) {
    return function (dispatch) {
        dispatch({
            type: actionTypes.FETCH_USER_ROLES
        });
        axios
            .get(host + "api/users/roles/" + id)
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_USER_ROLES_FULLFILED,
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

export function saveUserRoleRequest(roleRequest) {
    return function (dispatch) {
        dispatch({
            type: actionTypes.SAVE_USER_ROLE
        });
        axios
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
        type: actionTypes.ADD_USER_ROLES
    }
}