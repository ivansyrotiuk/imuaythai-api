import * as actionTypes from "../actions/actionTypes"

export default function reducer(state = {
    fighters: [],
    judges: [],
    coaches: [],
    fetching: false,
    fetched: false,
    error: null
  }, action) {

  switch (action.type) {
    case actionTypes.FETCH_FIGTHERS: {
      return {
        ...state,
        fetching: true
      }
    }
    case actionTypes.FETCH_FIGTHERS_REJECTED: {
      return {
        ...state,
        fetching: false,
        error: action.payload
      }
    }
    case actionTypes.FETCH_FIGTHERS_FULFILLED: {
      return {
        ...state,
        fetching: false,
        fetched: true,
        fighters: action.payload
      }
    }
    case actionTypes.FETCH_JUDGES: {
      return {
        ...state,
        fetching: true
      }
    }
    case actionTypes.FETCH_JUDGES_REJECTED: {
      return {
        ...state,
        fetching: false,
        error: action.payload
      }
    }
    case actionTypes.FETCH_JUDGES_FULFILLED: {
      return {
        ...state,
        fetching: false,
        fetched: true,
        judges: action.payload
      }
    }
    case actionTypes.FETCH_COACHES: {
      return {
        ...state,
        fetching: true
      }
    }
    case actionTypes.FETCH_COACHES_REJECTED: {
      return {
        ...state,
        fetching: false,
        error: action.payload
      }
    }
    case actionTypes.FETCH_COACHES_FULFILLED: {
      return {
        ...state,
        fetching: false,
        fetched: true,
        coaches: action.payload
      }
    }
  }
  return state
}