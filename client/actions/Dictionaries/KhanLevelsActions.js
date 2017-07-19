import {host} from "../../global"
import axios from "axios";

export function fetchLevels() {
    return function (dispatch) {
        dispatch({
            type: "FETCH_LEVELS"
        });
        axios
            .get(host + "api/dictionaries/levels/")
            .then((response) => {
                dispatch({
                    type: "FETCH_LEVELS_FULFILLED",
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: "FETCH_LEVELS_REJECTED",
                    payload: err
                })
            })
    }
}

export function saveLevel(type) {
    return {
        type: 'SAVE_LEVEL',
        payload: type
    }
}

export function deleteLevel(id) {
    return {
        type: 'DELETE_LEVEL',
        payload: id
    }
}
