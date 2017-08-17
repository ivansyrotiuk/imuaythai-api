import { host } from "../../global"
import axios from "axios";

export function fetchPoints() {
    return function(dispatch) {
        dispatch({
            type: "FETCH_POINTS"
        });
        axios
            .get(host + "api/dictionaries/points/")
            .then((response) => {
                dispatch({
                    type: "FETCH_POINTS_FULFILLED",
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: "FETCH_POINTS_REJECTED",
                    payload: err
                })
            })
    }
}

export function savePoint(point) {
    return {
        type: 'SAVE_POINT',
        payload: point
    }
}

export function deletePoint(id) {
    return {
        type: 'DELETE_POINT',
        payload: id
    }
}
