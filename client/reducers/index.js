import { combineReducers } from "redux"
import dummyUsers from "./dummyUsersReducer"
import Gyms from "./GymsReducer"

export default combineReducers({
    dummyUsers,
    Gyms
})