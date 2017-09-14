import * as actionType from "../actions/actionTypes";

const notificationsInitialState = {
    error: null,
    success: null
};

export default function(state = notificationsInitialState, action) {
    switch (action.type) {
        case actionType.SHOW_SUCCESS_MESSAGE:
            return {
                ...state,
                success: action.payload
            };
        case actionType.SHOW_ERROR:
            return {
                ...state,
                error: action.payload
            };
        case actionType.DISMISS_ERROR:
            return {
                ...state,
                error: null
            };
        case actionType.DISMISS_NOTIFICATIONS:
            return {
                ...state,
                error: null,
                success: null
            };
        default:
            return state;
    }
}
