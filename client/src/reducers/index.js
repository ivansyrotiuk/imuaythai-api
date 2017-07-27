import {combineReducers} from "redux"
import Gyms from "./GymsReducer"
import Users from "./UsersReducer"
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
import SingleUser from "./UserReducer"
import { reducer as reduxFormReducer } from 'redux-form';
export default combineReducers({
    Account,
    Gyms,
    ContestTypes,
    Users,
    Countries,
    ContestRanges,
    KhanLevels,
    SingleUser,
    Roles,
    UserRoles,
    RoleRequests,
    SuspensionTypes,
    ContestPoints,
    form: reduxFormReducer, 
})