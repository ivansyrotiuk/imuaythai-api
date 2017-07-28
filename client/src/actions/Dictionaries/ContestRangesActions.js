import {host} from "../../global"
import axios from "axios";

export function fetchRanges() {
    return function (dispatch) {
        dispatch({
            type: "FETCH_RANGES"
        });
        axios
            .get(host + "api/dictionaries/ranges/")
            .then((response) => {
                dispatch({
                    type: "FETCH_RANGES_FULFILLED",
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: "FETCH_RANGES_REJECTED",
                    payload: err
                })
            })
    }
}

export function saveRange(range) {
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
