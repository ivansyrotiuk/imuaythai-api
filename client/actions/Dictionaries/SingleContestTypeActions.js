import {host} from "../../global"
import axios from "axios";

export function saveType(type) {
    return {
        type: 'SAVE_STYPE',
        payload: type
    }
}

export function deleteType(id) {
    return {
        type: 'DELETE_STYPE',
        payload: id
    }
}

export function fetchType(id) {
    return function (dispatch){
        dispatch({
            type: "FETCH_STYPE"
        });
        axios
            .get(host + "api/contest/types/"+id)
            .then((response) => {
                dispatch({
                    type: "FETCH_STYPE_FULFILLED",
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: "FETCH_STYPE_REJECTED",
                    payload: err
                })
            })
}}