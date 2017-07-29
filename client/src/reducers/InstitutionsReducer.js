import * as actionTypes from "../actions/actionTypes"

export default function reducer(state = {
    gyms: [],
    nationalFederations: [],
    continentalFederations: [],
    worldFederations: [],
    fetching: false,
    fetched: false,
    error: null
  } , action) {

  switch (action.type) {
    case actionTypes.FETCH_GYMS: {
      return {
        ...state,
        fetching: true
      }
    }
    case actionTypes.FETCH_GYMS_REJECTED: {
      return {
        ...state,
        fetching: false,
        error: action.payload
      }
    }
    case actionTypes.FETCH_GYMS_FULFILLED: {
      return {
        ...state,
        fetching: false,
        fetched: true,
        gyms: action.payload
      }
    }
    case actionTypes.FETCH_NATIONAL_FEDERATIONS: {
      return {
        ...state,
        fetching: true
      }
    }
    case actionTypes.FETCH_NATIONAL_FEDERATIONS_REJECTED: {
      return {
        ...state,
        fetching: false,
        error: action.payload
      }
    }
    case actionTypes.FETCH_NATIONAL_FEDERATIONS_FULFILLED: {
      return {
        ...state,
        fetching: false,
        fetched: true,
        nationalFederations: action.payload
      }
    }
    case actionTypes.FETCH_CONTINENTAL_FEDERATIONS: {
      return {
        ...state,
        fetching: true
      }
    }
    case actionTypes.FETCH_CONTINENTAL_FEDERATIONS_REJECTED: {
      return {
        ...state,
        fetching: false,
        error: action.payload
      }
    }
    case actionTypes.FETCH_CONTINENTAL_FEDERATIONS_FULFILLED: {
      return {
        ...state,
        fetching: false,
        fetched: true,
        continentalFederations: action.payload
      }
    }
    case actionTypes.FETCH_WORLD_FEDERATIONS: {
      return {
        ...state,
        fetching: true
      }
    }
    case actionTypes.FETCH_WORLD_FEDERATIONS_REJECTED: {
      return {
        ...state,
        fetching: false,
        error: action.payload
      }
    }
    case actionTypes.FETCH_WORLD_FEDERATIONS_FULFILLED: {
      return {
        ...state,
        fetching: false,
        fetched: true,
        worldFederations: action.payload
      }
    }
  }
  return state
}