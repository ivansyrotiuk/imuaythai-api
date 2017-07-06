import { combineReducers } from "redux"
import dummyUsers from "./dummyUsersReducer"
import Gyms from "./GymsReducer"
import ContestTypes from "./ContestTypesReducer"
export default combineReducers({
    dummyUsers,
    Gyms, 
    ContestTypes
})