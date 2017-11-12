import * as actionTypes from './actionTypes';

export function dismissError() {
    return {
        type: actionTypes.DISMISS_ERROR
    }
}

export function dismiss() {
    return{
        type: actionTypes.DISMISS_NOTIFICATIONS
    }
}