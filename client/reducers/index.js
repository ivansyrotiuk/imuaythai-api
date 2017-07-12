import { combineReducers } from "redux"
import Gyms from "./GymsReducer"
import Fighters from "./FightersReducer"
import ContestTypes from "./ContestTypesReducer"
import Countries from "./CountriesReducer"
import { reducer as reduxFormReducer } from 'redux-form';

export default combineReducers({
    Gyms, 
    ContestTypes,
    Fighters,
    Countries,
    form: reduxFormReducer, 
})