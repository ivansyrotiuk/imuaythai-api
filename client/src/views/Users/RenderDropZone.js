import Dropzone from 'react-dropzone';
import React, { Component } from 'react';


class RenderDropZone extends Component {
    constructor() {
        super();

        this.state = {
            base64: ""
        }
    }
    render() {
        const {input} = this.props;
        const style = {
            display: "block",
            maxWidth: "197px",
            maxHeight: "196px",
            width: "auto",
            height: "auto"
        }
        return (
            <Dropzone onDrop={ (filesToUpload, e) => {
                       var file = filesToUpload[0];
                       var base64Data = null;
                       const reader = new FileReader();
                       reader.onload = (event) => {
                           input.onChange(event.target.result);
                   
                           this.setState({
                               base64: event.target.result
                           });
                       }
                       reader.readAsDataURL(file);
                   } }>
              { this.state.base64 != "" ? <img src={ this.state.base64 } style={ style } /> : <p>Drop your avatar here, or click to select image to upload.</p> }
            </Dropzone>
            );
    }
}
export default RenderDropZone;