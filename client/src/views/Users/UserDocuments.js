import React from 'react';
import FileBrowser from 'react-keyed-file-browser';
import Moment from 'moment'

const UserDocuments = (props) => {
    const file = {
        key: 'test.docx',
        modified: +Moment().subtract(1, 'hours'),
        size: 1.5 * 1024 * 1024,
    }
    return(<div>
        <FileBrowser files={file}/>
    </div>)
}

export default UserDocuments;