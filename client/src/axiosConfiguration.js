import axios from "axios";

export const configApiHost = () => {
    axios.defaults.baseURL = 'http://localhost:5000/';
}

export const setAuthToken = (token) => {
    axios.defaults.headers.common['Authorization'] = 'Bearer ' + token;
}