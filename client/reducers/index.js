import { combineReducers } from "redux"
import Gyms from "./GymsReducer"
import Fighters from "./FightersReducer"
import ContestTypes from "./ContestTypesReducer"
import ContestRanges from "./ContestRangesReducer"
import Countries from "./CountriesReducer"
import KhanLevels from "./KhanLevelsReducer"
import SuspensionTypes from "./SuspensionTypesReducer"
import ContestPoints from "./ContestPointsReducer"
import { reducer as reduxFormReducer } from 'redux-form';
export default combineReducers({
    Gyms, 
    ContestTypes,
    Fighters,
    Countries,
    ContestRanges,
    KhanLevels,
    SuspensionTypes,
    ContestPoints,
    form: reduxFormReducer, 
})