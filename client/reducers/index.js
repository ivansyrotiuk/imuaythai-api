import { combineReducers } from "redux"
import Gyms from "./GymsReducer"
import Fighters from "./FightersReducer"
import SingleFighter from "./FighterReducer"
import ContestTypes from "./ContestTypesReducer"
import { reducer as reduxFormReducer } from 'redux-form';

export default combineReducers({
    Gyms, 
    ContestTypes,
    Fighters,
    SingleFighter,
    form: reduxFormReducer, 
})