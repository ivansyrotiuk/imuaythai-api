import React from "react";
import Dropzone from "react-dropzone";

const convertToByteArray = file => {
  return new Promise((resolve, reject) => {
    let fileReader = new FileReader();
    fileReader.onload = function(event) {
      //let buffer = new Uint8Array(this.result);
      resolve(this.result);
    };
    fileReader.readAsDataURL(file);
  });
};

class AddUserDocuments extends React.Component {
  constructor() {
    super();

    this.state = {
      files: []
    };
  }

  onDrop(files) {
    this.setState({
      files
    });
  }

  onClick() {
    let filesToSend = [];
    const { files } = this.state;
    for (let fileId in files) {
      let file = files[fileId];
      convertToByteArray(file)
        .then(response => {
          filesToSend.push({
            name: file.name,
            byteArray: response
          });
        })
        .then(() => {
          if (filesToSend.length === files.length)
            this.props.sendDocuments(filesToSend);
        });
    }
  }
  render() {
    return (
      <div>
        <Dropzone onDrop={this.onDrop.bind(this)} />
        <aside>
          <h2>Dropped files</h2>
          <ul>
            {this.state.files.map((f, key) => <li key={key}>{f.name}</li>)}
          </ul>
        </aside>
        <button onClick={this.onClick.bind(this)}>Send</button>
      </div>
    );
  }
}

export default AddUserDocuments;
