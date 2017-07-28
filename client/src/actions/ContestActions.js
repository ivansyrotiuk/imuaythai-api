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

        return axios.post(host + "api/contest/save", contest)
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

export const fetchContest = (filter) => {
    return (dispatch) => {
        dispatch(createAction(actionTypes.FETCH_CONTESTS_REQUEST, filter));

        return axios.post(host + "api/contest/get", filter)
            .then((response) => {
                dispatch(createAction(actionTypes.FETCH_CONTESTS_SUCCESS, response.data))
            })
            .catch((err) => {
                dispatch(createAction(actionTypes.FETCH_CONTESTS_REJECTED, err.response != null
                    ? err.response.data
                    : "Cannot connect to server"))
            })
    }
}