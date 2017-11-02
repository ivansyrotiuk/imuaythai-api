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
    userId:
      ownProps.match.params.type === "user"
        ? ownProps.match.params.id
        : undefined,
    contestId:
      ownProps.match.params.type === "contest"
        ? ownProps.match.params.id
        : undefined,
    institutionId:
      ownProps.match.params.type === "institution"
        ? ownProps.match.params.id
        : undefined
  };
};
const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    sendUserDocuments(documents) {
      dispatch(sendUserDocuments(documents));
    },
    getUserDocuments() {
      dispatch(
        getUserDocuments(ownProps.match.params.type, ownProps.match.params.id)
      );
    }
  };
};
export default connect(mapStateToProps, mapDispatchToProps)(UserDocuments);
