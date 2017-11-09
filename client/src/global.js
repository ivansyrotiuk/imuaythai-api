export const host =
  process.env.NODE_ENV !== "production"
    ? "http://localhost:5000/"
    : "https://imuaythai-api.herokuapp.com/";
export const siteHost =
  process.env.NODE_ENV !== "production"
    ? "http://localhost:3000/"
    : "https://imuaythai.herokuapp.com/";
