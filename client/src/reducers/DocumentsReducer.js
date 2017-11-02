import * as actionTypes from "../actions/actionTypes";
const documentsInitialState = {
  documents: [],
  fetching: false,
  fetched: false
};
const documents = (state = documentsInitialState, action) => {
  switch (action.type) {
    case actionTypes.GET_DOCUMENTS_SUCCESS:
      return {
        ...state,
        documents: action.payload,
        fetched: true,
        fetching: false
      };
    case actionTypes.SEND_DOCUMENTS:
    case actionTypes.GET_DOCUMENTS:
      return {
        ...state,
        fetching: true,
        fetched: false
      };

    case actionTypes.SEND_DOCUMENTS_SUCCESS:
      return {
        ...state,
        fetched: true,
        fetching: false,
        documents: state.documents.concat(action.payload)
      };
    default:
      return state;
  }
};

export default documents;
