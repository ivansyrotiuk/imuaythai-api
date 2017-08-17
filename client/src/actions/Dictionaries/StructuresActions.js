import { host } from "../../global"
import axios from "axios";

export function fetchStructures() {
    return function(dispatch) {
        dispatch({
            type: "FETCH_STRUCTURES"
        });
        axios
            .get(host + "api/dictionaries/structures/")
            .then((response) => {
                dispatch({
                    type: "FETCH_STRUCTURES_FULFILLED",
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: "FETCH_STRUCTURES_REJECTED",
                    payload: err
                })
            })
    }
}

export function saveStructure(category) {
    return {
        type: 'SAVE_STRUCTURE',
        payload: category
    }
}

export function deleteStructure(id) {
    return {
        type: 'DELETE_STRUCTURE',
        payload: id
    }
}
