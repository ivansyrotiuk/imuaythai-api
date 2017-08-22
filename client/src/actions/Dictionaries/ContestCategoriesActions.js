import * as actionTypes from "../actionTypes"
import axios from "axios";

export function fetchContestCategories() {
    return function(dispatch) {
        dispatch({
            type: actionTypes.FETCH_CONTEST_CATEGORIES
        });
        axios
            .get("api/dictionaries/categories")
            .then((response) => {
                dispatch({
                    type: actionTypes.FETCH_CONTEST_CATEGORIES_FULFILLED,
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: actionTypes.FETCH_CONTEST_CATEGORIES_REJECTED,
                    payload: err
                })
            })
    }
}
export function deleteContestCategory(id) {
    return function(dispatch) {
        dispatch({
            type: actionTypes.DELETE_CONTEST_CATEGORY,
            payload: id
        });

    }
}