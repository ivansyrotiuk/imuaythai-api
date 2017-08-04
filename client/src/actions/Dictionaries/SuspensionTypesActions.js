import { host } from "../../global"
import axios from "axios";

export function fetchTypes() {
    return function(dispatch) {
        dispatch({
            type: "FETCH_SUSPENSION_TYPES"
        });
        axios
            .get(host + "api/dictionaries/suspensions/")
            .then((response) => {
                dispatch({
                    type: "FETCH_SUSPENSION_TYPES_FULFILLED",
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: "FETCH_SUSPENSION_TYPES_REJECTED",
                    payload: err
                })
            })
    }
}

export function saveType(type) {
    return {
        type: 'SAVE_SUSPENSION_TYPE',
        payload: type
    }
}

export function deleteType(id) {
    return {
        type: 'DELETE_SUSPENSION_TYPE',
        payload: id
    }
}
