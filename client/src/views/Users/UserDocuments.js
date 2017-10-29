import React from "react";
import FileBrowser from "react-keyed-file-browser";
import AddUserDocuments from "./AddUserDocuments";

const UserDocuments = props => {
  return (
    <div>
      <AddUserDocuments sendDocuments={props.sendUserDocuments} />
    </div>
  );
};

export default UserDocuments;
