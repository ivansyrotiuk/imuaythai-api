import * as actionTypes from '../actions/actionTypes';

export default function reducer(state = {
    roles: [],
    fetching: false,
    fetched: false,
    error: null
}, action) {
    switch (action.type) {
        case actionTypes.FETCH_ROLES:
            {
                return {
                    ...state,
                    fetching: true
                }
            };
        case actionTypes.FETCH_ROLES_FULLFILED:
            {
                return {
                    ...state,
                    roles: action.payload,
                    fetching: false,
                    fetched: true
                }
            }
            case actionTypes.FETCH_ROLES_REJECTED:{
                return {
                    ...state,
                    fetching : false,
                    fetched : false,
                    error : action.payload
                }
            }
        default:
            return state;
    }
};