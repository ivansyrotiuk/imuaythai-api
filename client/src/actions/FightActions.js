import { host } from "../global"
import axios from "axios";
import * as actionTypes from './actionTypes';

const createAction = (type, payload) => {
    return {
        type,
        payload
    }
}

export const fetchFights = () => {
    return (dispatch) => {
        dispatch(createAction(actionTypes.FETCH_FIGHTS_REQUEST));

        return axios.get(host + "api/fight?count=17")
            .then((response) => {
                dispatch(createAction(actionTypes.FETCH_FIGHTS_SUCCESS, response.data))
            })
            .catch((err) => {
                dispatch(createAction(actionTypes.FETCH_FIGHTS_REJECTED, err.response != null
                    ? err.response.data
                    : "Cannot connect to server"))
            })
    }
}