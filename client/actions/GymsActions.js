import axios from "axios";

export function fetchGyms() {
    return function (dispatch) {
        dispatch({
            type: "FETCH_GYMS"
        });
        axios
            .get("http://localhost:65240/api/gyms/")
            .then((response) => {
                dispatch({
                    type: "FETCH_GYMS_FULFILLED",
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: "FETCH_GYMS_REJECTED",
                    payload: err
                })
            })
    }
}

export function saveGym(gym) {
    return {
        type: 'SAVE_GYM',
        payload: gym
    }
}

export function deleteGym(id) {
    return {
        type: 'DELETE_GYM',
        payload: id
    }
}