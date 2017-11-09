import axios from "axios";

export const configApiHost = () => {
  axios.defaults.baseURL =
    process.env.NODE_ENV !== "production"
      ? "http://localhost:5000/"
      : "https://imuaythai-api.herokuapp.com/";
};

export const setAuthToken = token => {
  axios.defaults.headers.common["Authorization"] = "Bearer " + token;
};
