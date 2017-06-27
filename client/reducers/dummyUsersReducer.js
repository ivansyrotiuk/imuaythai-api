export default function reducer(state={
    dummyUsers: [],
    fetching: false,
    fetched: false,
    error: null,
  }, action) {

    switch (action.type) {
      case "FETCH_DUMMY_USERS": {
        return {...state, fetching: true}
      }

      case "FETCH_DUMMY_USERS_REJECTED": {
        return {...state, fetching: false, error: action.payload}
      }

      case "FETCH_DUMMY_USERS_FULFILLED": {
        return {
          ...state,
          fetching: false,
          fetched: true,
          dummyUsers: action.payload,
        }
      }

      case "ADD_DUMMY_USER": {
        return {
          ...state,
          dummyUsers: [...state.dummyUsers, action.payload],
        }
      }

      case "UPDATE_DUMMY_USER": {
        const { id, firstname, surname } = action.payload
        const newDummyUsers = [...state.dummyUsers]
        const dummyUserToUpdate = newDummyUsers.findIndex(d => dummyUser.id === id)
        newDummyUsers[dummyUserToUpdate] = action.payload;
        return {
          ...state,
          dummyUsers: newDummyUsers,
        }
      }
      case "DELETE_DUMMY_USER": {
        return {
          ...state,
          dummyUsers: state.dummyUsers.filter(dummyUser => dummyUser.id !== action.payload),
        }
      }
    }
    return state
  }