import * as actionTypes from '../actions/actionTypes';

export default function reducer(state = {
        roles: [],
        publicRoles: [],
        contestRoles: [],
        fetching: false,
        fetched: false,
        error: null
    } , action) {
    switch (action.type) {
        case actionTypes.FETCH_ROLES: {
            return {
                ...state,
                fetching: true
            }
        }
        ;
        case actionTypes.FETCH_ROLES_FULFILLED: {
            return {
                ...state,
                roles: action.payload,
                fetching: false,
                fetched: true
            }
        }
        case actionTypes.FETCH_ROLES_REJECTED: {
            return {
                ...state,
                fetching: false,
                fetched: false,
                error: action.payload
            }
        }
        case actionTypes.FETCH_PUBLIC_ROLES: {
            return {
                ...state,
                fetching: true
            }
        }
        case actionTypes.FETCH_PUBLIC_ROLES_FULFILLED: {
            return {
                ...state,
                publicRoles: action.payload,
                fetching: false,
                fetched: true
            }
        }
        case actionTypes.FETCH_PUBLIC_ROLES_REJECTED: {
            return {
                ...state,
                fetching: false,
                fetched: false,
                error: action.payload
            }
        }
        case actionTypes.FETCH_CONTEST_ROLES: {
            return {
                ...state,
                fetching: true
            }
        }
        case actionTypes.FETCH_CONTEST_ROLES_FULFILLED: {
            return {
                ...state,
                contestRoles: action.payload,
                fetching: false,
                fetched: true
            }
        }
        case actionTypes.FETCH_CONTEST_ROLES_REJECTED: {
            return {
                ...state,
                fetching: false,
                fetched: false,
                error: action.payload
            }
        }
        default:
            return state;
    }
}
;