import {combineReducers} from "redux"
import dummyUsers from "./dummyUsersReducer"
import Gyms from "./GymsReducer"
import ContestTypes from "./ContestTypesReducer"
import Account from "./AccountReducer"
import {reducer as form} from 'redux-form';
export default combineReducers({dummyUsers, Gyms, ContestTypes, Account, form})