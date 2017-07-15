import {host} from "../../global"
import axios from "axios";

export function saveType(range) {
    return {
        type: 'SAVE_RANGE',
        payload: range
    }
}

export function deleteRange(id) {
    return {
        type: 'DELETE_RANGE',
        payload: id
    }
}

export function fetchRange(id) {
    return function (dispatch){
        dispatch({
            type: "FETCH_RANGE"
        });
        axios
            .get(host + "api/contest/ranges/"+id)
            .then((response) => {
                dispatch({
                    type: "FETCH_RANGE_FULFILLED",
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: "FETCH_RANGE_REJECTED",
                    payload: err
                })
            })
}}