import { host } from "../../global"
import axios from "axios";

export function fetchWeightCategories() {
    return function(dispatch) {
        dispatch({
            type: "FETCH_WEIGHT_CATEGORIES"
        });
        axios
            .get(host + "api/dictionaries/weightcategories/")
            .then((response) => {
                dispatch({
                    type: "FETCH_WEIGHT_CATEGORIES_FULFILLED",
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: "FETCH_WEIGHT_CATEGORIES_REJECTED",
                    payload: err
                })
            })
    }
}

export function saveWeightCategory(category) {
    return {
        type: 'SAVE_WEIGHT_CATEGORY',
        payload: category
    }
}

export function deleteWeightCategory(id) {
    return {
        type: 'DELETE_WEIGHT_CATEGORY',
        payload: id
    }
}
