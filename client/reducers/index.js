import { combineReducers } from "redux"
import Gyms from "./GymsReducer"
import Fighters from "./FightersReducer"
import SingleFighter from "./FighterReducer"
import ContestTypes from "./ContestTypesReducer"

export default combineReducers({
    Gyms, 
    ContestTypes,
    Fighters,
    SingleFighter
})