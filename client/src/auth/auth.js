import locationHelperBuilder from 'redux-auth-wrapper/history4/locationHelper'
import { connectedRouterRedirect } from 'redux-auth-wrapper/history4/redirect'
import connectedAuthWrapper from 'redux-auth-wrapper/connectedAuthWrapper'
import authWrapper from 'redux-auth-wrapper/authWrapper'
import Spinner from '../views/Components/Spinners/Spinner'

const locationHelper = locationHelperBuilder({})

const userIsAuthenticatedDefaults = {
  authenticatedSelector: state => state.Account.authToken.length != 0,
  authenticatingSelector: state => state.Account.fetching,
  wrapperDisplayName: 'UserIsAuthenticated'
}

export const userIsAuthenticated = connectedAuthWrapper(userIsAuthenticatedDefaults)

export const userIsAuthenticatedRedir = connectedRouterRedirect({
  ...userIsAuthenticatedDefaults,
  AuthenticatingComponent: Spinner,
  redirectPath: '/login'
})

export const userIsAdminRedir = connectedRouterRedirect({
  redirectPath: '/',
  allowRedirectBack: false,
  authenticatedSelector: state => state.Account.authToken.length != 0 && state.Account.user.roles.find(r => r === "Admin"),
  wrapperDisplayName: 'UserIsAdmin'
})

export const userIsFighterRedir = connectedRouterRedirect({
  redirectPath: '/',
  allowRedirectBack: false,
  authenticatedSelector: state => state.Account.authToken.length != 0 && state.Account.user.roles.find(r => r === "Admin" || r === "Fighter"),
  wrapperDisplayName: 'UserIsAdmin'
})

const userIsNotAuthenticatedDefaults = {
  authenticatedSelector: state => state.Account.authToken.length != 0 && state.Account.fetching === false,
  wrapperDisplayName: 'UserIsNotAuthenticated'
}

export const userIsNotAuthenticated = connectedAuthWrapper(userIsNotAuthenticatedDefaults)

export const userIsNotAuthenticatedRedir = connectedRouterRedirect({
  ...userIsNotAuthenticatedDefaults,
  redirectPath: (state, ownProps) => locationHelper.getRedirectQueryParam(ownProps) || '/login',
  allowRedirectBack: false
})

const userIsAdminDefaults = {
  authenticatedSelector: state => state.Account.authToken.length != 0 && state.Account.user.roles.find(r => r == "Admin") != undefined,
  authenticatingSelector: state => state.Account.fetching,
  wrapperDisplayName: 'UserIsAdmin'
}

export const userIsAdmin = connectedAuthWrapper(userIsAdminDefaults)

const userCanManageRolesDefaults = {
  authenticatedSelector: state => state.Account.authToken.length != 0 &&
    state.Account.user.roles.find(r => r == "Admin" || r == "InstitutionAdmin") != undefined,
  wrapperDisplayName: 'userCanManageRoles'
}

export const userCanManageRoles = connectedAuthWrapper(userCanManageRolesDefaults)


export const userCanAcceptContestRequest = connectedAuthWrapper({
  authenticatedSelector: state => state.Contest.singleContest && state.Account.user.InstitutionId == state.Contest.singleContest.institutionId &&
    state.Account.user.roles.find(r => r == "Admin" || r == "Gym" || r == "NationalFederation" || r == "ContinentalFederation" || r == "WorldFederation") != undefined,
  wrapperDisplayName: 'userCanManageRoles'
})

export const userCanAddContestRequest = connectedAuthWrapper({
  authenticatedSelector: state => state.Account.user.roles.find(r => r == "Admin" || r == "Gym" || r == "NationalFederation" || r == "ContinentalFederation" || r == "WorldFederation") != undefined,
  wrapperDisplayName: 'userCanManageRoles'
})

export const userCanSeeContests = connectedAuthWrapper({
  authenticatedSelector: state => state.Account.user.roles.find(r => r == "Admin" || r == "Gym" || r == "NationalFederation" || r == "ContinentalFederation" || r == "WorldFederation") != undefined || !state.Account.user.InstitutionId,
  wrapperDisplayName: 'userCanManageRoles'
})


const userIsFighterDefaults = {
  authenticatedSelector: state => state.Account.authToken.length != 0 && state.Account.user.roles.find(r => r == "Fighter") != undefined,
  authenticatingSelector: state => state.Account.fetching,
  wrapperDisplayName: 'UserIsFighter'
}

export const userIsFighter = connectedAuthWrapper(userIsFighterDefaults)

const userIsJudgeDefaults = {
  authenticatedSelector: state => state.Account.authToken.length != 0 && state.Account.user.roles.find(r => r == "Judge") != undefined,
  authenticatingSelector: state => state.Account.fetching,
  wrapperDisplayName: 'UserIsJudge'
}

export const userIsJudge = connectedAuthWrapper(userIsJudgeDefaults)

const userIsDoctorDefaults = {
  authenticatedSelector: state => state.Account.authToken.length != 0 && state.Account.user.roles.find(r => r == "Doctor") != undefined,
  authenticatingSelector: state => state.Account.fetching,
  wrapperDisplayName: 'UserIsDoctor'
}

export const userIsDoctor = connectedAuthWrapper(userIsDoctorDefaults)

const userIsNormalUserDefaults = {
  authenticatedSelector: state => state.Account.authToken.length != 0 && state.Account.user.roles.find(r => r != "Admin" && r != "") != undefined,
  authenticatingSelector: state => state.Account.fetching,
  wrapperDisplayName: 'UserIsNormalUser'
}

export const userIsNormalUser = connectedAuthWrapper(userIsNormalUserDefaults)


const userHasRoleDefaults = {
  authenticatedSelector: state => state.Account.authToken.length != 0 && state.Account.user.roles.find(r => r != "") != undefined,
  authenticatingSelector: state => state.Account.fetching,
  wrapperDisplayName: 'UserIHasRole'
}

export const userHasRole = connectedAuthWrapper(userHasRoleDefaults)


const userWithoutRolesDefaults = {
  authenticatedSelector: state => state.Account.authToken.length != 0 && state.Account.user.roles.find(r => r != "") !== undefined,
  authenticatingSelector: state => state.Account.fetching,
  wrapperDisplayName: 'UserIWithoutRole'
}

export const userWithoutRole = connectedAuthWrapper(userWithoutRolesDefaults)

export const userWithoutRoleRedir = connectedRouterRedirect({
  ...userWithoutRolesDefaults,
  AuthenticatingComponent: Spinner,
  redirectPath: '/register/second_step'
})
