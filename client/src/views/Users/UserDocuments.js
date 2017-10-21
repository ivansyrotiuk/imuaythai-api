import React from 'react';
import FileBrowser from 'react-keyed-file-browser';

const UserDocuments = props => {
  return (
    <div>
      <FileBrowser files={props.documents} />
    </div>
  );
};

export default UserDocuments;
