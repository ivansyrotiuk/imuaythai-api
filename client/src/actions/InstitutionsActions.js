import { host } from "../global"
import axios from "axios";
import * as actionTypes from "../actions/actionTypes"

export function fetchGyms() {
    return function(dispatch) {
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

export function deleteInstitution(id) {
    return function(dispatch) {
        dispatch({
            type: actionTypes.DELETE_INSTITUTION,
            payload: id
        })
        return axios.post(host + 'api/gyms/remove', {
            Id: id
        })
            .then(function(response) {
                dispatch({
                    type: actionTypes.DELETE_INSTITUTION_SUCCESS,
                    payload: response.data
                });
            })
            .catch(function(error) {
                dispatch({
                    type: actionTypes.DELETE_INSTITUTION_REJECTED,
                    payload: error
                });
            });
    }
}