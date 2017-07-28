import { applyMiddleware, createStore, compose } from "redux"
import logger from "redux-logger"
import thunk from "redux-thunk"
import promise from "redux-promise-middleware"
import reducer from "./reducers"
import { loadState } from "./localStorage"
import { setAuthToken } from "./axiosConfiguration"
const persistedState = loadState();

if (persistedState != undefined && persistedState.Account != undefined) {
  setAuthToken(persistedState.Account.authToken)
}
const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
const middleware = [promise(), thunk, logger];
export default createStore(reducer, persistedState, composeEnhancers(applyMiddleware(...middleware)));