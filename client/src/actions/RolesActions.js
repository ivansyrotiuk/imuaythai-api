import {host} from "../global"
import * as actionTypes from "./actionTypes"
import axios from "axios";

export function fetchRoles() {
    return function (dispatch) {
        dispatch({type: actionTypes.FETCH_ROLES});
        axios
            .get(host + "api/roles")
            .then((response) => {
                dispatch({type: actionTypes.FETCH_ROLES_FULLFILED, payload: response.data})
            })
            .catch((err) => {
                dispatch({type: actionTypes.FETCH_ROLES_REJECTED, payload: err})
            })
    }
}