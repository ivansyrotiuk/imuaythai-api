import axios from "axios";

export function fetchDummyUsers() {
    return function (dispatch) {
        dispatch({
            type: "FETCH_DUMMY_USERS"
        });
        axios
            .get("http://localhost:65240/api/Users/DummyUsers")
            .then((response) => {
                dispatch({
                    type: "FETCH_DUMMY_USERS_FULFILLED",
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: "FETCH_DUMMY_USERS_REJECTED",
                    payload: err
                })
            })
    }
}

export function addDummyUser(id, firstname, surname) {
    return {
        type: 'ADD_DUMMY_USER',
        payload: {
            id,
            firstname,
            surname
        }
    }
}

export function updateDummyUser(id, firstname, surname) {
    return {
        type: 'UPDATE_DUMMY_USER',
        payload: {
            id,
            firstname,
            surname
        }
    }
}

export function deleteDummyUser(id) {
    return {
        type: 'DELETE_DUMMY_USER',
        payload: id
    }
}