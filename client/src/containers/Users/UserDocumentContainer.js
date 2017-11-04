import UserDocuments from "../../views/Users/UserDocuments";
import React from "react";
import { connect } from "react-redux";
import {
  sendUserDocuments,
  getUserDocuments
} from "../../actions/UsersActions";

const mapStateToProps = (state, ownProps) => {
  return {
    documents: state.Documents.documents,
    fetching: state.Documents.fetching,
    fetched: state.Documents.fetched,
    userId: ownProps.type === "user" ? ownProps.id : undefined,
    contestId: ownProps.type === "contest" ? ownProps.id : undefined,
    institutionId: ownProps.type === "institution" ? ownProps.id : undefined
  };
};
const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    sendUserDocuments(documents) {
      dispatch(sendUserDocuments(documents));
    },
    getUserDocuments() {
      dispatch(getUserDocuments(ownProps.type, ownProps.id));
    }
  };
};
export default connect(mapStateToProps, mapDispatchToProps)(UserDocuments);
