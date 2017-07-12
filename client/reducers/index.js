import { combineReducers } from "redux"
import Gyms from "./GymsReducer"
import Fighters from "./FightersReducer"
import SingleFighter from "./FighterReducer"
import ContestTypes from "./ContestTypesReducer"
import SingleContestType from "./SingleContestTypeReducer"
import ContestRanges from "./ContestRangesReducer"
import SingleContestRange from "./SingleContestRangeReducer"
import { reducer as reduxFormReducer } from 'redux-form';
export default combineReducers({
    Gyms, 
    ContestTypes,
    SingleContestType,
    Fighters,
    SingleFighter,
    ContestRanges,
    SingleContestRange,
    form: reduxFormReducer, 

})