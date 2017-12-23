import { applyMiddleware, createStore, compose } from 'redux';
import logger from 'redux-logger';
import thunk from 'redux-thunk';
import promise from 'redux-promise-middleware';
import reducer from './reducers';
import { loadState } from './localStorage';
import { setAuthToken } from './axiosConfiguration';
const persistedState = loadState();

if (persistedState !== undefined && persistedState.Account !== undefined) {
    setAuthToken(persistedState.Account.authToken);
}
const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
let middleware = [promise(), thunk];

if (process.env.NODE_ENV !== 'production') {
    middleware = [...middleware, logger];
}

const store = createStore(reducer, persistedState, composeEnhancers(applyMiddleware(...middleware)));
export default store;
