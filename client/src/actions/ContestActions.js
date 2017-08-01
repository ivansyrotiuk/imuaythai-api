import { host } from "../global"
import axios from "axios";
import * as actionTypes from './actionTypes';

const createAction = (type, payload) => {
    return {
        type,
        payload
    }
}

export const saveContest = (contest) => {
    return (dispatch) => {
        dispatch(createAction(actionTypes.SAVE_CONTEST_REQUEST, contest));

        return axios.post(host + "api/contests/save", contest)
            .then((response) => {
                dispatch(createAction(actionTypes.SAVE_CONTEST_SUCCESS, response.data))
            })
            .catch((err) => {
                dispatch(createAction(actionTypes.SAVE_CONTEST_REJECTED, err.response != null
                    ? err.response.data
                    : "Cannot connect to server"))
            })
    }
}

export function addContest(contest) {
    return {
        type: actionTypes.ADD_NEW_CONTEST,
        payload: contest
    }
}

export const fetchContest = (id) => {
    return (dispatch) => {
        dispatch({
            type: actionTypes.FETCH_SINGLE_CONTEST
        });

        return axios.get(host + "api/contests/" + id)
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_SINGLE_CONTEST_FULFILLED,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_SINGLE_CONTEST_REJECTED,
                    payload: err
                })
            })
    }
}

export const fetchConstests = () => {
    return (dispatch) => {
        dispatch({
            type: actionTypes.FETCH_CONTESTS
        })

        return axios.get(host + "api/contests/")
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_CONTESTS_FULFILLED,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_CONTESTS_REJECTED,
                    payload: err
                })
            })
    }
}