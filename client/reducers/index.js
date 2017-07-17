import {combineReducers} from "redux"
import Gyms from "./GymsReducer"
import Fighters from "./FightersReducer"
import ContestTypes from "./ContestTypesReducer"
import Account from "./AccountReducer"
import ContestRanges from "./ContestRangesReducer"
import Countries from "./CountriesReducer"
import KhanLevels from "./KhanLevelsReducer"
import { reducer as reduxFormReducer } from 'redux-form';
export default combineReducers({
    Account,
    Gyms,
    ContestTypes,
    Fighters,
    Countries,
    ContestRanges,
    KhanLevels,
    form: reduxFormReducer, 
})