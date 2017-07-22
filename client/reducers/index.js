import {combineReducers} from "redux"
import Gyms from "./GymsReducer"
import Fighters from "./FightersReducer"
import ContestTypes from "./ContestTypesReducer"
import Account from "./AccountReducer"
import ContestRanges from "./ContestRangesReducer"
import Countries from "./CountriesReducer"
import KhanLevels from "./KhanLevelsReducer"
import SuspensionTypes from "./SuspensionTypesReducer"
import ContestPoints from "./ContestPointsReducer"
import Roles from "./RolesReducer"
import UserRoles from "./UserRolesReducer"
import RoleRequests from "./RoleRequestsReducer"
import { reducer as reduxFormReducer } from 'redux-form';
export default combineReducers({
    Account,
    Gyms,
    ContestTypes,
    Fighters,
    Countries,
    ContestRanges,
    KhanLevels,
    Roles,
    UserRoles,
    RoleRequests,
    SuspensionTypes,
    ContestPoints,
    form: reduxFormReducer, 
})