import {combineReducers} from "redux"
import Gyms from "./GymsReducer"
import Fighters from "./FightersReducer"
import ContestTypes from "./ContestTypesReducer"
import Account from "./AccountReducer"
import SingleContestType from "./SingleContestTypeReducer"
import ContestRanges from "./ContestRangesReducer"
import SingleContestRange from "./SingleContestRangeReducer"
import Countries from "./CountriesReducer"
import {reducer as reduxFormReducer} from 'redux-form';
export default combineReducers({
    Account,
    Gyms,
    ContestTypes,
    Fighters,
    Countries,
    ContestRanges,
    form: reduxFormReducer
})