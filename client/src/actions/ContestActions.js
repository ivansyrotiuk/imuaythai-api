import { host } from '../global';
import axios from 'axios';
import * as actionTypes from './actionTypes';

export const fetchConstests = () => {
    return dispatch => {
        dispatch({
            type: actionTypes.FETCH_CONTESTS
        });

        return axios
            .get(host + 'api/contests/')
            .then(response => {
                dispatch({
                    type: actionTypes.FETCH_CONTESTS_FULFILLED,
                    payload: response.data
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.SHOW_ERROR,
                    payload: err.message
                });
            });
    };
};

export const fetchContest = id => {
    return dispatch => {
        dispatch({
            type: actionTypes.FETCH_SINGLE_CONTEST
        });

        return axios
            .get(host + 'api/contests/' + id)
            .then(response => {
                dispatch({
                    type: actionTypes.FETCH_SINGLE_CONTEST_FULFILLED,
                    payload: response.data
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.FETCH_SINGLE_CONTEST_REJECTED,
                    payload: err
                });
            });
    };
};

export function addContest(contest) {
    return {
        type: actionTypes.ADD_NEW_CONTEST,
        payload: contest
    };
}

export function resetContest() {
    return {
        type: actionTypes.RESET_CONTEST
    };
}

export const saveContest = contest => {
    return dispatch => {
        dispatch({
            type: actionTypes.SAVE_CONTEST,
            payload: contest
        });

        return axios
            .post(host + 'api/contests/save', contest)
            .then(response => {
                dispatch({
                    type: actionTypes.SAVE_CONTEST_SUCCESS,
                    payload: response.data
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.SAVE_CONTEST_REJECTED,
                    payload: err.response != null ? err.response.data : 'Cannot connect to server'
                });
            });
    };
};

export const fetchContestCandidates = () => {
    return dispatch => {
        dispatch({
            type: actionTypes.FETCH_CONTEST_CANDIDATES
        });

        return axios
            .get(host + 'api/contestrequests/candidates')
            .then(response => {
                dispatch({
                    type: actionTypes.FETCH_CONTEST_CANDIDATES_FULFILLED,
                    payload: response.data
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.FETCH_CONTEST_CANDIDATES_REJECTED,
                    payload: err
                });
            });
    };
};

export const fetchContestRequests = contestId => {
    return dispatch => {
        dispatch({
            type: actionTypes.FETCH_CONTEST_REQUESTS
        });

        return axios
            .get('api/contestrequests?contestId=' + contestId)
            .then(response => {
                dispatch({
                    type: actionTypes.FETCH_CONTEST_REQUESTS_FULFILLED,
                    payload: response.data
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.FETCH_CONTEST_REQUESTS_REJECTED,
                    payload: err
                });
            });
    };
};

export const fetchContestJudges = contestId => {
    return dispatch => {
        dispatch({
            type: actionTypes.FETCH_CONTEST_JUDGES
        });

        return axios
            .get('api/contestrequests/judges?contestId=' + contestId)
            .then(response => {
                dispatch({
                    type: actionTypes.FETCH_CONTEST_JUDGES_FULFILLED,
                    payload: response.data
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.FETCH_CONTEST_JUDGES_REJECTED
                });
                dispatch({
                    type: actionTypes.SHOW_ERROR,
                    payload: err.data
                });
            });
    };
};

export const fetchInstitutionContestRequests = contestId => {
    return dispatch => {
        dispatch({
            type: actionTypes.FETCH_INSTITUTION_CONTEST_REQUESTS
        });

        return axios
            .get('api/contestrequests/myrequests?contestId=' + contestId)
            .then(response => {
                dispatch({
                    type: actionTypes.FETCH_INSTITUTION_CONTEST_REQUESTS_FULFILLED,
                    payload: response.data
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.FETCH_INSTITUTION_CONTEST_REQUESTS_REJECTED,
                    payload: err
                });
            });
    };
};

export function addContestRequest(request) {
    return {
        type: actionTypes.ADD_CONTEST_REQUEST,
        payload: request
    };
}

export function cancelContestRequest() {
    return {
        type: actionTypes.CANCEL_CONTEST_REQUEST
    };
}

export function editContestRequest(request) {
    return {
        type: actionTypes.EDIT_CONTEST_REQUEST,
        payload: request
    };
}

export const saveContestRequest = request => {
    return dispatch => {
        dispatch({
            type: actionTypes.SAVE_CONTEST
        });

        return axios
            .post(host + 'api/contestrequests/save', request)
            .then(response => {
                dispatch({
                    type: actionTypes.SAVE_CONTEST_REQUEST_SUCCESS,
                    payload: response.data
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.SAVE_CONTEST_REQUEST_REJECTED,
                    payload: err.response != null ? err.response.data : 'Cannot connect to server'
                });

                dispatch({
                    type: actionTypes.SHOW_ERROR,
                    payload: err.response != null ? err.response.data : 'Cannot connect to server'
                });
            });
    };
};

export const acceptContestRequest = request => {
    return dispatch => {
        dispatch({
            type: actionTypes.ACCEPT_CONTEST_REQUEST,
            payload: request
        });

        return axios
            .post(host + 'api/contestrequests/accept', request)
            .then(response => {
                dispatch({
                    type: actionTypes.ACCEPT_CONTEST_REQUEST_SUCCESS,
                    payload: response.data
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.ACCEPT_CONTEST_REQUEST_REJECTED,
                    payload: request
                });
            });
    };
};

export const rejectContestRequest = request => {
    return dispatch => {
        dispatch({
            type: actionTypes.REJECT_CONTEST_REQUEST,
            payload: request
        });

        return axios
            .post(host + 'api/contestrequests/reject', request)
            .then(response => {
                dispatch({
                    type: actionTypes.REJECT_CONTEST_REQUEST_SUCCESS,
                    payload: response.data
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.REJECT_CONTEST_REQUEST_REJECTED,
                    payload: request
                });
            });
    };
};

export const removeContestRequest = request => {
    return dispatch => {
        dispatch({
            type: actionTypes.REMOVE_CONTEST_REQUEST,
            payload: request
        });

        return axios
            .post(host + 'api/contestrequests/remove', request)
            .then(response => {
                dispatch({
                    type: actionTypes.REMOVE_CONTEST_REQUEST_SUCCESS,
                    payload: request
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.REMOVE_CONTEST_REQUEST_REJECTED,
                    payload: request
                });
            });
    };
};

export const fetchCategoriesWithFighters = contestId => {
    return dispatch => {
        dispatch({
            type: actionTypes.FETCH_CONTEST_CATEGORIES_WITH_FIGHTERS
        });

        return axios
            .get(host + 'api/contests/categories?contestId=' + contestId)
            .then(response => {
                dispatch({
                    type: actionTypes.FETCH_CONTEST_CATEGORIES_WITH_FIGHTERS_SUCCESS,
                    payload: response.data
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.CONTEST_CANCEL_FETCHING
                });
                dispatch({
                    type: actionTypes.SHOW_ERROR,
                    payload: err.data
                });
            });
    };
};

export const fetchContestFights = contestId => {
    return dispatch => {
        dispatch({
            type: actionTypes.FETCH_CONTEST_FIGHTS
        });

        return axios
            .get(host + 'api/fights/get?contestId=' + contestId)
            .then(response => {
                dispatch({
                    type: actionTypes.FETCH_CONTEST_FIGHTS_FULFILLED,
                    payload: response.data
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.CONTEST_CANCEL_FETCHING
                });
                dispatch({
                    type: actionTypes.SHOW_ERROR,
                    payload: err.data
                });
            });
    };
};

export const tossupJudges = contestId => {
    return dispatch => {
        dispatch({
            type: actionTypes.TOSSUP_JUDGES
        });

        return axios
            .get(host + 'api/fights/judges/tossup?contestid=' + contestId)
            .then(response => {
                dispatch({
                    type: actionTypes.TOSSUP_JUDGES_SUCCESS,
                    payload: response.data
                });
                dispatch({
                    type: actionTypes.SHOW_SUCCESS_MESSAGE,
                    payload: 'Judges has beed tossed up.'
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.TOSSUP_JUDGES_REJECTED
                });
                dispatch({
                    type: actionTypes.SHOW_ERROR,
                    payload: err.response.data
                });
            });
    };
};

export const scheduleFights = contestId => {
    return dispatch => {
        dispatch({
            type: actionTypes.SCHEDULE_FIGHTS
        });

        return axios
            .get(host + 'api/fights/schedule?contestid=' + contestId)
            .then(response => {
                dispatch({
                    type: actionTypes.SCHEDULE_FIGHTS_SUCCESS,
                    payload: response.data
                });
                dispatch({
                    type: actionTypes.SHOW_SUCCESS_MESSAGE,
                    payload: 'Fights has beed scheduled.'
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.SCHEDULE_FIGHTS_REJECTED
                });
                dispatch({
                    type: actionTypes.SHOW_ERROR,
                    payload: err.data
                });
            });
    };
};

export const allocateJudgeRequest = judgeRequest => {
    return dispatch => {
        dispatch({
            type: actionTypes.CONTEST_ALLOCATE_JUGDE
        });

        return axios
            .post(host + 'api/contestrequests/allocatejudge', judgeRequest)
            .then(response => {
                dispatch({
                    type: actionTypes.CONTEST_ALLOCATE_JUGDE_SUCCESS,
                    payload: response.data
                });
            })
            .catch(err => {
                dispatch({
                    type: actionTypes.CONTEST_ALLOCATE_JUGDE_REJECTED
                });
                dispatch({
                    type: actionTypes.SHOW_ERROR,
                    payload: err.data
                });
            });
    };
};
