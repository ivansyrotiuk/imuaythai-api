import { host } from "../../global"
import axios from "axios";

export function fetchRounds() {
    return function(dispatch) {
        dispatch({
            type: "FETCH_ROUNDS"
        });
        axios
            .get(host + "api/dictionaries/rounds/")
            .then((response) => {
                dispatch({
                    type: "FETCH_ROUNDS_FULFILLED",
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: "FETCH_ROUNDS_REJECTED",
                    payload: err
                })
            })
    }
}

export function saveRound(category) {
    return {
        type: 'SAVE_ROUND',
        payload: category
    }
}

export function deleteRound(id) {
    return {
        type: 'DELETE_ROUND',
        payload: id
    }
}
