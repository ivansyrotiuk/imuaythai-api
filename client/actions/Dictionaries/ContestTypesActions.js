import {host} from "../../global"
import axios from "axios";

export function fetchTypes() {
    return function (dispatch) {
        dispatch({
            type: "FETCH_TYPES"
        });
        axios
            .get(host + "api/dictionaries/types/")
            .then((response) => {
                dispatch({
                    type: "FETCH_TYPES_FULFILLED",
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: "FETCH_TYPES_REJECTED",
                    payload: err
                })
            })
    }
}

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
