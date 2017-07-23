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
        case actionTypes.FETCH_ROLES_REQUESTS_FULLFILED:
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
            const arr_roleRequests = [...state.roleRequests];
            const arr_index = arr_roleRequests.findIndex(r => r.id === action.payload.id);
            arr_roleRequests[arr_index].accepting = true;

            return {
                ...state,
                roleRequests: arr_roleRequests
            }
        case actionTypes.ACCEPT_ROLE_REQUEST_SUCCESS:
            const arrs_roleRequests = [...state.roleRequests];
            const arrs_index = arrs_roleRequests.findIndex(r => r.id === action.payload.id);
            arrs_roleRequests[arrs_index].accepting = false;
            arrs_roleRequests.splice(arrs_index, 1);
            return {
                ...state,
                roleRequests: arrs_roleRequests
            }

        case actionTypes.ACCEPT_ROLE_REQUEST_REJECTED:
            const arrr_roleRequests = [...state.roleRequests];
            const arrr_index = arrr_roleRequests.findIndex(r => r.id === action.payload.id);
            arrr_roleRequests[arrr_index].accepting = false;
            return {
                ...state,
                roleRequests: arrr_roleRequests
            }
        case actionTypes.REJECT_ROLE_REQUEST:
            const rrr_roleRequests = [...state.roleRequests];
            const rrr_index = rrr_roleRequests.findIndex(r => r.id === action.payload.id);
            rrr_roleRequests[rrr_index].rejecting = true;

            return {
                ...state,
                roleRequests: rrr_roleRequests
            }
        case actionTypes.REJECT_ROLE_REQUEST_SUCCESS:
            const rrrs_roleRequests = [...state.roleRequests];
            const rrrs_index = rrrs_roleRequests.findIndex(r => r.id === action.payload.id);
            rrrs_roleRequests[rrrs_index].rejecting = false;
            rrrs_roleRequests.splice(rrrs_index, 1);
            
            return {
                ...state,
                roleRequests: rrrs_roleRequests
            }

        case actionTypes.REJECT_ROLE_REQUEST_REJECTED:
            const rrrr_roleRequests = [...state.roleRequests];
            const rrrr_index = rrrr_roleRequests.findIndex(r => r.id === action.payload.id);
            rrrr_roleRequests[rrrr_index].rejecting = false;
            return {
                ...state,
                roleRequests: rrrr_roleRequests
            }
        default:
            return state
    }
}
