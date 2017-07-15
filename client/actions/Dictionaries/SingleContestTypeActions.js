import {host} from "../../global"
import axios from "axios";

export function saveType(type) {
    return {
        type: 'SAVE_TYPE',
        payload: type
    }
}

export function deleteType(id) {
    return {
        type: 'DELETE_TYPE',
        payload: id
    }
}

export function fetchType(id) {
    return function (dispatch){
        dispatch({
            type: "FETCH_TYPE"
        });
        axios
            .get(host + "api/contest/types/"+id)
            .then((response) => {
                dispatch({
                    type: "FETCH_TYPE_FULFILLED",
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: "FETCH_TYPE_REJECTED",
                    payload: err
                })
            })
}}