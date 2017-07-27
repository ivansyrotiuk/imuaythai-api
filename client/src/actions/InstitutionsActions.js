import {host} from "../global"
import axios from "axios";
import * as actionTypes from "../actions/actionTypes"

export function fetchGyms() {
    return function (dispatch) {
        dispatch({
            type: actionTypes.FETCH_GYMS
        });
        axios
            .get(host + "api/gyms/")
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_GYMS_FULFILLED,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_GYMS_REJECTED,
                    payload: err
                })
            })
    }
}

export function saveGym(gym) {
    return {
        type: 'SAVE_GYM',
        payload: gym
    }
}

export function deleteGym(id) {
    return {
        type: 'DELETE_GYM',
        payload: id
    }
}