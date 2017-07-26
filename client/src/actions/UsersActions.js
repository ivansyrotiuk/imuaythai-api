import { host } from "../global"
import axios from "axios";
import * as actionTypes from "./actionTypes"

export function fetchFighters() {
    return function(dispatch) {
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

export function fetchUser(id) {
    return function(dispatch) {
        dispatch({
            type: actionTypes.FETCH_USER
        });
        axios.get(host + "api/users/" + id)
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_USER_FULLFILED,
                    payload: response.data
                });
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_USER_REJECTED,
                    payload: err
                });

            });
    }
}

export function saveUser(user) {
    return function(dispatch) {
        dispatch({
            type: actionTypes.SAVE_USER
        });
        return axios
            .post(host + 'api/users/save', user)
            .then(function(response) {
                dispatch({
                    type: actionTypes.SAVE_USER_SUCCESS,
                    payload: response.data
                });
            })
            .catch(function(error) {
                dispatch({
                    type: actionTypes.SAVE_USER_REJECTED,
                    payload: error
                });
            });
    }
}

export function deleteFighter(id) {
    return function(dispatch) {
        axios.post(host + 'api/users/remove', {
            Id: id
        })
            .then((response) => {
                dispatch({
                    type: 'DELETE_FIGHTER_SUCCESS',
                    payload: id
                })
            })
            .catch((err) => {
                dispatch({
                    type: "DELETE_FIGHTER_REJECTED",
                    payload: err
                })
            })
    }
}
