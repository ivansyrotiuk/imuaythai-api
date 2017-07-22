import {host} from "../global"
import axios from "axios";
import * as actionTypes from "./actionTypes"

export function fetchRolesRequests() {
    return function (dispatch) {
        dispatch({
            type: actionTypes.FETCH_ROLES_REQUESTS
        });
        axios
            .get(host + "api/users/roles/requests")
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_ROLES_REQUESTS_FULLFILED,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_ROLES_REQUESTS_REJECTED,
                    payload: err
                })
            })
    }
}