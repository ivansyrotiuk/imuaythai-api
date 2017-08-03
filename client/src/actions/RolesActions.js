import { host } from "../global"
import * as actionTypes from "./actionTypes"
import axios from "axios";

export function fetchRoles() {
    return function(dispatch) {
        dispatch({
            type: actionTypes.FETCH_ROLES
        });
        axios
            .get(host + "api/roles")
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_ROLES_FULFILLED,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_ROLES_REJECTED,
                    payload: err
                })
            })
    }
}

export function fetchPublicRoles() {
    return function(dispatch) {
        dispatch({
            type: actionTypes.FETCH_PUBLIC_ROLES
        });
        axios
            .get(host + "api/roles/public")
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_PUBLIC_ROLES_FULFILLED,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_PUBLIC_ROLES_REJECTED,
                    payload: err
                })
            })
    }
}

export function fetchContestRoles() {
    return function(dispatch) {
        dispatch({
            type: actionTypes.FETCH_CONTEST_ROLES
        });
        axios
            .get(host + "api/roles/contest")
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_CONTEST_ROLES_FULFILLED,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_CONTEST_ROLES_REJECTED,
                    payload: err
                })
            })
    }
}

