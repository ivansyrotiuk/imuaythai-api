import {host} from "../global"
import axios from "axios";

export function fetchFighters() {
    return function (dispatch) {
        dispatch({
            type: "FETCH_FIGTHERS"
        });
        axios
            .get(host + "api/users/fighters")
            .then((response) => {
                dispatch({
                    type: "FETCH_FIGTHERS_FULFILLED",
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: "FETCH_FIGTHERS_REJECTED",
                    payload: err
                })
            })
    }
}

export function saveFighter(fighter) {
    return {
        type: 'SAVE_FIGHTER',
        payload: fighter
    }
}

export function deleteFighter(id) {
    return {
        type: 'DELETE_FIGHTER',
        payload: id
    }
}