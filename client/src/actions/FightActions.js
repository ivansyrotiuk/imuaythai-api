import { host } from '../global';
import axios from 'axios';
import * as actionTypes from './actionTypes';

const createAction = (type, payload) => {
    return {
        type,
        payload
    };
};

export const fetchContestDraws = (contestId, categoryId) => {
    return dispatch => {
        dispatch(createAction(actionTypes.FETCH_FIGHTS_DRAWS));

        return axios
            .get(host + 'api/fights/draws?contestId=' + contestId + '&categoryId=' + categoryId, {
                contestId: contestId,
                categoryId: categoryId
            })
            .then(response => {
                dispatch(createAction(actionTypes.FETCH_FIGHTS_DRAWS_SUCCESS, response.data));
            })
            .catch(err => {
                dispatch(
                    createAction(
                        actionTypes.FETCH_FIGHTS_DRAWS_REJECTED,
                        err.response != null ? err.response.data : 'Cannot connect to server'
                    )
                );
            });
    };
};

export const fetchContestFights = (contestId, categoryId) => {
    return dispatch => {
        dispatch(createAction(actionTypes.FETCH_CONTEST_CATEGORY_FIGHTS));

        return axios
            .get(host + 'api/fights/get?contestId=' + contestId + '&categoryId=' + categoryId, {
                contestId: contestId,
                categoryId: categoryId
            })
            .then(response => {
                dispatch(createAction(actionTypes.FETCH_CONTEST_CATEGORY_FIGHTS_SUCCESS, response.data));
            })
            .catch(err => {
                dispatch(createAction(actionTypes.FETCH_CONTEST_CATEGORY_FIGHTS_REJECTED, err.response));
                dispatch(
                    createAction(
                        actionTypes.SHOW_ERROR,
                        err.response != null ? err.response.data : 'Cannot connect to server'
                    )
                );
            });
    };
};

export const fetchFight = fightId => {
    return dispatch => {
        dispatch(createAction(actionTypes.FETCH_FIGHT));

        return axios
            .get(host + 'api/fights/' + fightId)
            .then(response => {
                dispatch(createAction(actionTypes.FETCH_FIGHT_SUCCESS, response.data));
            })
            .catch(err => {
                dispatch(createAction(actionTypes.FETCH_FIGHT_REJECTED, err.response));
                dispatch(
                    createAction(
                        actionTypes.SHOW_ERROR,
                        err.response != null ? err.response.data : 'Cannot connect to server'
                    )
                );
            });
    };
};

export const generateContestDraws = (contestId, categoryId) => {
    return dispatch => {
        dispatch(createAction(actionTypes.GENERATE_FIGHTS));

        return axios
            .get(host + 'api/fights/draws/generate?contestId=' + contestId + '&categoryId=' + categoryId, {
                contestId: contestId,
                categoryId: categoryId
            })
            .then(response => {
                dispatch(createAction(actionTypes.GENERATE_FIGHTS_SUCCESS, response.data));
            })
            .catch(err => {
                dispatch(createAction(actionTypes.GENERATE_FIGHTS_REJECTED));
                dispatch(
                    createAction(
                        actionTypes.SHOW_ERROR,
                        err.response != null ? err.response.data : 'Cannot connect to server'
                    )
                );
            });
    };
};

export const regenerateContestDraws = (contestId, categoryId) => {
    return dispatch => {
        dispatch(createAction(actionTypes.REGENERATE_FIGHTS));

        return axios
            .get(host + 'api/fights/draws/regenerate?contestId=' + contestId + '&categoryId=' + categoryId, {
                contestId: contestId,
                categoryId: categoryId
            })
            .then(response => {
                dispatch(createAction(actionTypes.REGENERATE_FIGHTS_SUCCESS, response.data));
            })
            .catch(err => {
                dispatch(createAction(actionTypes.REGENERATE_FIGHTS_REJECTED));
                dispatch(
                    createAction(
                        actionTypes.SHOW_ERROR,
                        err.response != null ? err.response.data : 'Cannot connect to server'
                    )
                );
            });
    };
};

export const tossupContestDraws = (contestId, categoryId) => {
    return dispatch => {
        dispatch(createAction(actionTypes.TOSSUP_CONTEST_FIGHTS));

        return axios
            .get(host + 'api/fights/draws/tossup?contestId=' + contestId + '&categoryId=' + categoryId, {
                contestId: contestId,
                categoryId: categoryId
            })
            .then(response => {
                dispatch(createAction(actionTypes.TOSSUP_CONTEST_FIGHTS_SUCCESS, response.data));
            })
            .catch(err => {
                dispatch(createAction(actionTypes.TOSSUP_CONTEST_FIGHTS_REJECTED));
                dispatch(
                    createAction(
                        actionTypes.SHOW_ERROR,
                        err.response != null ? err.response.data : 'Cannot connect to server'
                    )
                );
            });
    };
};

export const moveFighter = movingParams => {
    return dispatch => {
        dispatch(createAction(actionTypes.MOVE_FIGHTER));

        return axios
            .post(host + 'api/fights/movefighter', movingParams)
            .then(response => {
                dispatch(createAction(actionTypes.MOVE_FIGHTER_SUCCESS, response.data));
            })
            .catch(err => {
                dispatch(createAction(actionTypes.MOVE_FIGHTER_REJECTED));
                dispatch(
                    createAction(
                        actionTypes.SHOW_ERROR,
                        err.response != null ? err.response.data : 'Cannot connect to server'
                    )
                );
            });
    };
};

export const dragFight = dragParams => {
    return dispatch => {
        dispatch(createAction(actionTypes.DRAG_FIGHT, dragParams));
    };
};

export const moveFight = movingParams => {
    return dispatch => {
        dispatch(createAction(actionTypes.MOVE_FIGHT));

        return axios
            .post(host + 'api/fights/movefight', movingParams)
            .then(response => {
                dispatch(createAction(actionTypes.MOVE_FIGHT_SUCCESS, response.data));
            })
            .catch(err => {
                dispatch(createAction(actionTypes.MOVE_FIGHT_REJECTED));
                dispatch(
                    createAction(
                        actionTypes.SHOW_ERROR,
                        err.response != null ? err.response.data : 'Cannot connect to server'
                    )
                );
            });
    };
};
