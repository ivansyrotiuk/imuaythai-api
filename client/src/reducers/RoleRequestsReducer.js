import * as actionTypes from "../actions/actionTypes"

const roleRequestsInitialState = {
    roleRequests: [],
    fetching: false,
    fetched: false
}
export default function reducer(state = roleRequestsInitialState, action) {
    switch (action.type) {
        case actionTypes.FETCH_ROLES_REQUESTS:
            return {
                ...state,
                fetching: true
            }
        case actionTypes.FETCH_ROLES_REQUESTS_FULFILLED:
            return {
                ...state,
                roleRequests: action.payload,
                fetching: false,
                fetched: true
            }
        case actionTypes.FETCH_ROLES_REQUESTS_REJECTED:
            return {
                ...state,
                err: action.payload,
                fetching: false,
                fetched: false
            }
        case actionTypes.ACCEPT_ROLE_REQUEST:
            let requests = [...state.roleRequests];
            let index = requests.findIndex(r => r.id == action.payload.id);
            if (index > -1) {
                requests[index].accepting = true;
            }

            return {
                ...state,
                roleRequests: requests
            }
        case actionTypes.ACCEPT_ROLE_REQUEST_SUCCESS:
            requests = [...state.roleRequests];
            index = requests.findIndex(r => r.id == action.payload.id);
            if (index > -1) {
                requests[index].accepting = false;
                requests.splice(index, 1);
            }

            return {
                ...state,
                roleRequests: requests
            }

        case actionTypes.ACCEPT_ROLE_REQUEST_REJECTED:
            requests = [...state.roleRequests];
            index = requests.findIndex(r => r.id == action.payload.id);
            if (index > -1)
                requests[index].accepting = false;
            return {
                ...state,
                roleRequests: requests
            }
        case actionTypes.REJECT_ROLE_REQUEST:
            requests = [...state.roleRequests];
            index = requests.findIndex(r => r.id == action.payload.id);
            if (index > -1)
                requests[index].rejecting = true;

            return {
                ...state,
                roleRequests: requests
            }
        case actionTypes.REJECT_ROLE_REQUEST_SUCCESS:
            requests = [...state.roleRequests];
            index = requests.findIndex(r => r.id === action.payload.id);
            if (index > -1) {
                requests[index].rejecting = false;
                requests.splice(index, 1);
            }

            return {
                ...state,
                roleRequests: requests
            }

        case actionTypes.REJECT_ROLE_REQUEST_REJECTED:
            requests = [...state.roleRequests];
            index = requests.findIndex(r => r.id === action.payload.id);
            if (index > -1) {
                requests[index].rejecting = false;
                requests.splice(index, 1);
            }

            return {
                ...state,
                roleRequests: requests
            }
        default:
            return state
    }
}
