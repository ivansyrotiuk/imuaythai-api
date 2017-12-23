import { host } from '../global';
import axios from 'axios';
import * as actionTypes from './actionTypes';

export function fetchRolesRequests() {
    return function(dispatch) {
        dispatch({
            type: actionTypes.FETCH_ROLES_REQUESTS
        });
        axios
            .get(host + 'api/users/roles/requests')
            .then(response => {
                dispatch({
                    type: actionTypes.FETCH_ROLES_REQUESTS_FULFILLED,
                    payload: response.data
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.FETCH_ROLES_REQUESTS_REJECTED,
                    payload: err
                });
            });
    };
}

export function acceptRequest(request) {
    return function(dispatch) {
        dispatch({
            type: actionTypes.ACCEPT_ROLE_REQUEST,
            payload: request
        });
        axios
            .post(host + 'api/users/roles/acceptrequest', request)
            .then(response => {
                dispatch({
                    type: actionTypes.ACCEPT_ROLE_REQUEST_SUCCESS,
                    payload: response.data
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.ACCEPT_ROLE_REQUEST_REJECTED,
                    payload: err
                });
            });
    };
}

export function rejectRequest(request) {
    return function(dispatch) {
        dispatch({
            type: actionTypes.REJECT_ROLE_REQUEST,
            payload: request
        });
        axios
            .post(host + 'api/users/roles/rejectrequest', request)
            .then(response => {
                dispatch({
                    type: actionTypes.REJECT_ROLE_REQUEST_SUCCESS,
                    payload: response.data
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.REJECT_ROLE_REQUEST_REJECTED,
                    payload: err
                });
            });
    };
}
