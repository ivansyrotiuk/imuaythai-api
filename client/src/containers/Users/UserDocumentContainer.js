import UserDocuments from "../../views/Users/UserDocuments";
import React from "react";
import { connect } from "react-redux";
import { sendUserDocuments } from "../../actions/UsersActions";

const mapStateToProps = state => {
  return {
    //documents: state.Documents.documents
  };
};
const mapDispatchToProps = dispatch => {
  return {
    sendUserDocuments(documents) {
      dispatch(sendUserDocuments(documents));
    }
  };
};
export default connect(mapStateToProps, mapDispatchToProps)(UserDocuments);
