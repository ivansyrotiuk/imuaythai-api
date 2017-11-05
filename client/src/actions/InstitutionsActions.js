import { host } from "../global"
import axios from "axios";
import * as actionTypes from "../actions/actionTypes"

export function fetchGyms() {
    return function(dispatch) {
        dispatch({
            type: actionTypes.FETCH_GYMS
        });
        axios
            .get(host + "api/gyms")
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

export function fetchCountryGyms(countryId) {
    return function(dispatch) {
        dispatch({
            type: actionTypes.FETCH_COUNTRY_GYMS
        });
        axios
            .get(host + "api/gyms/country?id=" + countryId)
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_COUNTRY_GYMS_FULFILLED,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_COUNTRY_GYMS_REJECTED,
                    payload: err
                })
            })
    }
}

export function fetchNationalFederations() {
    return function(dispatch) {
        dispatch({
            type: actionTypes.FETCH_NATIONAL_FEDERATIONS
        });
        axios
            .get(host + "api/federations/national")
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_NATIONAL_FEDERATIONS_FULFILLED,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_NATIONAL_FEDERATIONS_REJECTED,
                    payload: err
                })
            })
    }
}

export function fetchContinentalFederations() {
    return function(dispatch) {
        dispatch({
            type: actionTypes.FETCH_CONTINENTAL_FEDERATIONS
        });
        axios
            .get(host + "api/federations/continental")
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_CONTINENTAL_FEDERATIONS_FULFILLED,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_CONTINENTAL_FEDERATIONS_REJECTED,
                    payload: err
                })
            })
    }
}

export function fetchWorldFederations() {
    return function(dispatch) {
        dispatch({
            type: actionTypes.FETCH_WORLD_FEDERATIONS
        });
        axios
            .get(host + "api/federations/world")
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_WORLD_FEDERATIONS_FULFILLED,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_WORLD_FEDERATIONS_REJECTED,
                    payload: err
                })
            })
    }
}

export function fetchInstitution(id) {
    return function(dispatch) {
        dispatch({
            type: actionTypes.FETCH_INSTITUTION
        });
        axios
            .get(host + "api/institutions/" + id)
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_INSTITUTION_FULFILLED,
                    payload: response.data
                });
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_INSTITUTION_REJECTED,
                    payload: err
                });
            });
    }
}

export function addInstitution(institutionType) {
    return function(dispatch) {
        dispatch({
            type: actionTypes.ADD_INSTITUTION,
            payload: {
                id: 0,
                institutionType: institutionType,
            }
        });
    }
}

export function resetInstitution(institutionType) {
    return function(dispatch) {
        dispatch({
            type: actionTypes.RESET_INSTITUTION,
        });
    }
}

export function saveInstitution(institution) {
    return function(dispatch) {
        dispatch({
            type: actionTypes.SAVE_INSTITUTION
        });
        return axios
            .post(host + 'api/institutions/save', institution)
            .then(function(response) {
                dispatch({
                    type: actionTypes.SAVE_INSTITUTION_SUCCESS,
                    payload: response.data
                });
            })
            .catch(function(error) {
                dispatch({
                    type: actionTypes.SAVE_INSTITUTION_REJECTED,
                    payload: error
                });
            });
    }
}

export function deleteInstitution(id) {
    return function(dispatch) {
        dispatch({
            type: actionTypes.DELETE_INSTITUTION,
            payload: id
        })
        return axios.post(host + 'api/institutions/remove', {
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

export function fetchInstitutionMembers(institutionId) {
    return function (dispatch) {
        dispatch({
            type: actionTypes.FETCH_INSTITUTION_MEMBERS
        });
        return axios.get('/api/institutions/members?institutionId=' + institutionId)
            .then((response)=>{
                dispatch({
                    type: actionTypes.FETCH_INSTITUTION_MEMBERS_FULFILLED,
                    payload: response.data
                })
            })
            .catch((error)=>{
                dispatch({
                    type: actionTypes.FETCH_INSTITUTION_MEMBERS_REJECTED,
                    payload: error
                })
            });
    }
}