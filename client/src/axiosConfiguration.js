import axios from "axios";

export const configApiHost = () => {
  axios.defaults.baseURL = "https://imuaythai.herokuapp.com/";
};

export const setAuthToken = token => {
  axios.defaults.headers.common["Authorization"] = "Bearer " + token;
};
