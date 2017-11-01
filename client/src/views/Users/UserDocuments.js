import React from "react";
import DocumentViewer from "./DocumentViewer";
import Moment from "moment";
import Dropzone from "react-dropzone";
import Spinner from "../Components/Spinners/Spinner";

const convertToByteArray = file => {
  return new Promise((resolve, reject) => {
    let fileReader = new FileReader();
    fileReader.onload = function(event) {
      resolve(this.result);
    };
    fileReader.readAsDataURL(file);
  });
};

class UserDocuments extends React.Component {
  constructor() {
    super();

    this.state = {
      activeDropzone: false
    };
    this.onDrop = this.onDrop.bind(this);
    this.onDragEnter = this.onDragEnter.bind(this);
    this.onDragLeave = this.onDragLeave.bind(this);
  }
  componentWillMount() {
    this.props.getUserDocuments();
  }

  onDrop(files) {
    let filesToSend = [];
    for (let fileId in files) {
      let file = files[fileId];
      convertToByteArray(file)
        .then(response => {
          filesToSend.push({
            name: file.name,
            byteArray: response,
            userId: this.props.userId,
            contestId: this.props.contestId,
            institutionId: this.props.institutionId
          });
        })
        .then(() => {
          if (filesToSend.length === files.length) {
            this.setState({
              activeDropzone: false
            });
            this.props.sendUserDocuments(filesToSend);
          }
        });
    }
  }

  onDragEnter() {
    this.setState({
      activeDropzone: true
    });
  }

  onDragLeave() {
    this.setState({
      activeDropzone: false
    });
  }
  render() {
    if (this.props.fetching)
      return (
        <div>
          <h1>Document's list</h1>
          <h6>Please drag and drop documents in order to add them.</h6>
          <Spinner />
        </div>
      );
    else if (this.props.fetched)
      return (
        <div>
          <Dropzone
            onDrop={this.onDrop}
            style={{ border: "none" }}
            onDragEnter={this.onDragEnter}
            onDragLeave={this.onDragLeave}
            disableClick>
            <div>
              <h1>Document's list</h1>
              <h6>Please drag and drop documents in order to add them.</h6>
              {this.state.activeDropzone ? (
                <div
                  className="container text-center mt-5"
                  style={{ color: "green" }}>
                  <i className="fa fa-cloud-upload fa-4x" aria-hidden="true" />
                  <br />
                  <h3>Drop files here</h3>
                </div>
              ) : (
                <DocumentViewer documents={this.props.documents} />
              )}
            </div>
          </Dropzone>
        </div>
      );
    else
      return (
        <div>
          <span>Something went wrong</span>
        </div>
      );
  }
}

export default UserDocuments;
