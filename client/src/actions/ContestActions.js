import { host } from "../global"
import axios from "axios";
import * as actionTypes from './actionTypes';

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
                    type: actionTypes.SHOW_ERROR,
                    payload: err.message
                })
            })
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

export function addContest(contest) {
    return {
        type: actionTypes.ADD_NEW_CONTEST,
        payload: contest
    }
}

export function resetContest() {
    return {
        type: actionTypes.RESET_CONTEST,
    }
}

export const saveContest = (contest) => {
    return (dispatch) => {
        dispatch({
            type: actionTypes.SAVE_CONTEST,
            payload: contest
        });

        return axios.post(host + "api/contests/save", contest)
            .then((response) => {
                dispatch({
                    type: actionTypes.SAVE_CONTEST_SUCCESS,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.SAVE_CONTEST_REJECTED,
                    payload: err.response != null
                        ? err.response.data
                        : "Cannot connect to server"
                })
            })
    }
}

export const fetchContestCandidates = () => {
    return (dispatch) => {
        dispatch({
            type: actionTypes.FETCH_CONTEST_CANDIDATES
        })

        return axios.get(host + "api/contests/candidates")
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_CONTEST_CANDIDATES_FULFILLED,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_CONTEST_CANDIDATES_REJECTED,
                    payload: err
                })
            })
    }
}

export const fetchContestRequests = (contestId) => {
    return (dispatch) => {
        dispatch({
            type: actionTypes.FETCH_CONTEST_REQUESTS
        })

        return axios.get("api/contests/requests?contestId=" + contestId)
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_CONTEST_REQUESTS_FULFILLED,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_CONTEST_REQUESTS_REJECTED,
                    payload: err
                })
            })
    }
}

export const fetchInstitutionContestRequests = (contestId) => {
    return (dispatch) => {
        dispatch({
            type: actionTypes.FETCH_INSTITUTION_CONTEST_REQUESTS
        })

        return axios.get("api/contests/requests/institution?contestId=" + contestId)
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_INSTITUTION_CONTEST_REQUESTS_FULFILLED,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_INSTITUTION_CONTEST_REQUESTS_REJECTED,
                    payload: err
                })
            })
    }
}

export function addContestRequest(request) {
    return {
        type: actionTypes.ADD_CONTEST_REQUEST,
        payload: request
    }
}

export function cancelContestRequest() {
    return {
        type: actionTypes.CANCEL_CONTEST_REQUEST
    }
}

export const saveContestRequest = (request) => {
    return (dispatch) => {
        dispatch({
            type: actionTypes.SAVE_CONTEST,
        });

        return axios.post(host + "api/contests/requests/save", request)
            .then((response) => {
                dispatch({
                    type: actionTypes.SAVE_CONTEST_REQUEST_SUCCESS,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.SAVE_CONTEST_REQUEST_REJECTED,
                    payload: err.response != null
                        ? err.response.data
                        : "Cannot connect to server"
                })

                dispatch({
                    type: actionTypes.SHOW_ERROR,
                    payload: err.response != null
                        ? err.response.data
                        : "Cannot connect to server"
                })
            })
    }
}

export const acceptContestRequest = (request) => {
    return (dispatch) => {
        dispatch({
            type: actionTypes.ACCEPT_CONTEST_REQUEST,
            payload: request
        });

        return axios.post(host + "api/contests/requests/accept", request)
            .then((response) => {
                dispatch({
                    type: actionTypes.ACCEPT_CONTEST_REQUEST_SUCCESS,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.ACCEPT_CONTEST_REQUEST_REJECTED,
                    payload: request
                })
            })
    }
}

export const rejectContestRequest = (request) => {
    return (dispatch) => {
        dispatch({
            type: actionTypes.REJECT_CONTEST_REQUEST,
            payload: request
        });

        return axios.post(host + "api/contests/requests/reject", request)
            .then((response) => {
                dispatch({
                    type: actionTypes.REJECT_CONTEST_REQUEST_SUCCESS,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.REJECT_CONTEST_REQUEST_REJECTED,
                    payload: request
                })
            })
    }
}

export const removeContestRequest = (request) => {
    return (dispatch) => {
        dispatch({
            type: actionTypes.REMOVE_CONTEST_REQUEST,
            payload: request
        });

        return axios.post(host + "api/contests/requests/remove", request)
            .then((response) => {
                dispatch({
                    type: actionTypes.REMOVE_CONTEST_REQUEST_SUCCESS,
                    payload: request
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.REMOVE_CONTEST_REQUEST_REJECTED,
                    payload: request
                })
            })
    }
}


