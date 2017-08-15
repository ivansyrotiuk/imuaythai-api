import React, { Component } from 'react';
import EditButton from "./EditButton"
import RemoveButton from "./RemoveButton"
import PreviewButton from "./PreviewButton"
import { Link } from 'react-router-dom'

export default class ActionButtonGroup extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        const {previewClick, editClick, deleteClick} = this.props;
        return (
            <div className="row">
              <div className="col-4">
                <PreviewButton click={ previewClick } />
              </div>
              <div className="col-4">
                <EditButton click={ editClick } />
              </div>
              <div className="col-4">
                <RemoveButton click={ deleteClick } />
              </div>
            </div>
        )
    }

}


