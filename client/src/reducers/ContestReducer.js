import * as actionTypes from "../actions/actionTypes";

const reducerInitialState = {
    contests: [],
    requests: [],
    candidates: [],
    judgeRequests: [],
    categories: [],
    fights: [],
    institutionRequests: [],
    singleContest: null,
    singleRequest: null,
    showRequestForm: false,
    contestSaved: false,
    error: null,
    fetched: false,
    fetching: false,
    allocating: false,
    tossingup: false,
    scheduling: false
};
const reducer = (state = reducerInitialState, action) => {
    switch (action.type) {
        case actionTypes.ADD_NEW_CONTEST:
            return {
                ...state,
                singleContest: action.payload
            };
        case actionTypes.FETCH_CONTESTS:
            return {
                ...state,
                fetching: true
            };
        case actionTypes.FETCH_CONTESTS_FULFILLED:
            return {
                ...state,
                fetching: false,
                fetched: true,
                contests: action.payload
            };
        case actionTypes.FETCH_CONTESTS:
            return {
                ...state,
                fetching: false,
                fetched: false,
                error: action.payload
            };
        case actionTypes.FETCH_SINGLE_CONTEST:
            return {
                ...state,
                fetching: true
            };
        case actionTypes.FETCH_SINGLE_CONTEST_FULFILLED:
            return {
                ...state,
                fetching: false,
                fetched: true,
                singleContest: action.payload
            };
        case actionTypes.FETCH_SINGLE_CONTEST_REJECTED:
            return {
                ...state,
                fetching: false,
                fetched: true,
                error: action.payload
            };
        case actionTypes.FETCH_CONTEST_CANDIDATES:
            return {
                ...state,
                fetching: true
            };
        case actionTypes.FETCH_CONTEST_CANDIDATES_FULFILLED:
            return {
                ...state,
                fetching: false,
                fetched: true,
                candidates: action.payload
            };
        case actionTypes.FETCH_CONTEST_CANDIDATES_REJECTED:
            return {
                ...state,
                fetching: false,
                fetched: true,
                error: action.payload
            };
        case actionTypes.FETCH_INSTITUTION_CONTEST_REQUESTS:
            return {
                ...state,
                fetching: true
            };
        case actionTypes.FETCH_INSTITUTION_CONTEST_REQUESTS_FULFILLED:
            return {
                ...state,
                fetching: false,
                institutionRequests: action.payload
            };
        case actionTypes.FETCH_INSTITUTION_CONTEST_REQUESTS_REJECTED:
            return {
                ...state,
                fetching: false,
                error: action.payload
            };
        case actionTypes.SAVE_CONTEST:
            return state;
        case actionTypes.SAVE_CONTEST_SUCCESS:
            return {
                ...state,
                contestSaved: true
            };
        case actionTypes.RESET_CONTEST:
            return {
                ...state,
                contestSaved: false,
                singleContest: null
            };
        case actionTypes.SAVE_CONTEST_REJECTED:
            return state;
        case actionTypes.ADD_CONTEST_REQUEST:
            return {
                ...state,
                showRequestForm: true,
                singleRequest: action.payload
            };
        case actionTypes.CANCEL_CONTEST_REQUEST:
            return {
                ...state,
                showRequestForm: false,
                singleRequest: null
            };
        case actionTypes.SAVE_CONTEST_REQUEST:
            return state;
        case actionTypes.SAVE_CONTEST_REQUEST_SUCCESS:
            return {
                ...state,
                showRequestForm: false,
                singleRequest: null,
                institutionRequests: [...state.institutionRequests, action.payload]
            };
        case actionTypes.SAVE_CONTEST_REQUEST_REJECTED:
            return {
                ...state,
                error: action.payload
            };
        case actionTypes.FETCH_CONTEST_REQUESTS:
            return {
                ...state,
                fetching: true
            };
        case actionTypes.FETCH_CONTEST_REQUESTS_FULFILLED:
            return {
                ...state,
                fetching: false,
                requests: action.payload
            };
        case actionTypes.FETCH_CONTEST_REQUESTS_REJECTED:
            return {
                ...state,
                fetching: false,
                error: action.payload
            };

        case actionTypes.FETCH_CONTEST_JUDGES:
            return {
                ...state,
                fetching: true
            };
        case actionTypes.FETCH_CONTEST_JUDGES_FULFILLED:
            return {
                ...state,
                fetching: false,
                judgeRequests: action.payload
            };
        case actionTypes.FETCH_CONTEST_JUDGES_REJECTED:
            return {
                ...state,
                fetching: false
            };
        case actionTypes.CONTEST_ALLOCATE_JUGDE:
            return {
                ...state,
                allocating: true
            };
        case actionTypes.CONTEST_ALLOCATE_JUGDE_SUCCESS:
            const judges = [...state.judgeRequests];
            let index = judges.findIndex(j => j.id == action.payload.id);
            if (index > -1) {
                judges[index] = action.payload;
            }
            return {
                ...state,
                allocating: false,
                judgeRequests: judges
            };
        case actionTypes.CONTEST_ALLOCATE_JUGDE_REJECTED:
            return {
                ...state,
                allocating: false
            };

        case actionTypes.ACCEPT_CONTEST_REQUEST:
            let requests = [...state.requests];
            index = requests.findIndex(r => r.id === action.payload.id);
            requests[index].accepting = true;
            return {
                ...state,
                requests: requests
            };
        case actionTypes.ACCEPT_CONTEST_REQUEST_SUCCESS:
            requests = [...state.requests];
            index = requests.findIndex(r => r.id === action.payload.id);
            requests[index].accepting = false;
            requests[index] = action.payload;
            return {
                ...state,
                requests: requests
            };
        case actionTypes.ACCEPT_CONTEST_REQUEST_REJECTED:
            requests = [...state.requests];
            index = requests.findIndex(r => r.id === action.payload.id);
            requests[index].accepting = false;
            return {
                ...state,
                requests: requests
            };
        case actionTypes.REJECT_CONTEST_REQUEST:
            requests = [...state.requests];
            index = requests.findIndex(r => r.id === action.payload.id);
            requests[index].rejecting = true;
            return {
                ...state,
                requests: requests
            };
        case actionTypes.REJECT_CONTEST_REQUEST_SUCCESS:
            requests = [...state.requests];
            index = requests.findIndex(r => r.id === action.payload.id);
            requests[index].rejecting = false;
            requests[index] = action.payload;
            return {
                ...state,
                requests: requests
            };
        case actionTypes.REJECT_CONTEST_REQUEST_REJECTED:
            requests = [...state.requests];
            index = requests.findIndex(r => r.id === action.payload.id);
            requests[index].rejecting = false;
            return {
                ...state,
                requests: requests
            };
        case actionTypes.REMOVE_CONTEST_REQUEST:
            let institutionRequests = [...state.institutionRequests];
            index = institutionRequests.findIndex(r => r.id === action.payload.id);
            institutionRequests[index].removing = true;
            return {
                ...state,
                institutionRequests: institutionRequests
            };
        case actionTypes.REMOVE_CONTEST_REQUEST_SUCCESS:
            institutionRequests = [...state.institutionRequests];
            index = institutionRequests.findIndex(r => r.id === action.payload.id);
            institutionRequests.splice(index, 1);
            return {
                ...state,
                institutionRequests: institutionRequests
            };
        case actionTypes.REMOVE_CONTEST_REQUEST_REJECTED:
            institutionRequests = [...state.institutionRequests];
            index = institutionRequests.findIndex(r => r.id === action.payload.id);
            institutionRequests[index].removing = false;
            return {
                ...state,
                institutionRequests: institutionRequests
            };
        case actionTypes.FETCH_CONTEST_CATEGORIES_WITH_FIGHTERS:
            return {
                ...state,
                fetching: true
            };
        case actionTypes.FETCH_CONTEST_CATEGORIES_WITH_FIGHTERS_SUCCESS:
            return {
                ...state,
                fetching: false,
                categories: action.payload
            };
        case actionTypes.FETCH_CONTEST_FIGHTS:
            return {
                ...state,
                fetching: true
            };
        case actionTypes.FETCH_CONTEST_FIGHTS_FULFILLED:
            return {
                ...state,
                fetching: false,
                fights: action.payload
            };
        case actionTypes.TOSSUP_JUDGES:
            return {
                ...state,
                tossingup: true
            };
        case actionTypes.TOSSUP_JUDGES_SUCCESS:
            return {
                ...state,
                tossingup: false,
                fights: action.payload
            };
        case actionTypes.TOSSUP_JUDGES_REJECTED:
            return {
                ...state,
                tossingup: false
            };
        case actionTypes.SCHEDULE_FIGHTS:
            return {
                ...state,
                scheduling: true
            };
        case actionTypes.SCHEDULE_FIGHTS_SUCCESS:
            return {
                ...state,
                scheduling: false,
                fights: action.payload
            };
        case actionTypes.SCHEDULE_FIGHTS_REJECTED:
            return {
                ...state,
                scheduling: false
            };
        case action.CONTEST_CANCEL_FETCHING:
            return {
                ...state,
                fetching: false
            };
        default:
            return state;
    }
};

export default reducer;
