import {host} from "../global"
import axios from "axios";

export function fetchCountries() {
    return function (dispatch) {
        dispatch({
            type: "FETCH_COUNTRIES"
        });
        axios
            .get(host + "api/locations/countries")
            .then((response) => {
                dispatch({
                    type: "FETCH_COUNTRIES_FULFILLED",
                    payload: response.data
                })
            })
            .catch((err) => {
                dispatch({
                    type: "FETCH_COUNTRIES_REJECTED",
                    payload: err
                })
            })
    }
}