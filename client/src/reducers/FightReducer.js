import * as actionTypes from '../actions/actionTypes';

const fightReducerInitialState = {
    fetching: false,
    fetched: false,
    error: null,
    games: []
}
const fightReducer = (state = fightReducerInitialState, action) => {
    switch (action.type) {
        case actionTypes.FETCH_FIGHTS_REQUEST:
            return {
                ...state,
                fetching: true
            }
        case actionTypes.FETCH_FIGHTS_SUCCESS:
            return {
                ...state,
                fetching: false,
                fetched: true,
                games: action.payload
            }
        case actionTypes.FETCH_FIGHTS_REJECTED:
        default:
            return {
                ...state,
                fetching: false,
                error: action.payload
            }
    }
}

export default fightReducer;