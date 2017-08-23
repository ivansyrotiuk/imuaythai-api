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
                       const reader = new FileReader();
                       reader.onload = (event) => {
                           input.onChange(event.target.result);
                   
                           this.setState({
                               base64: event.target.result
                           });
                       }
                       reader.readAsDataURL(file);
                   } }>
              <img src={ this.state.base64 != "" ? this.state.base64 : this.props.imageUrl } style={ style } />
            </Dropzone>



        )

    }
}
export default RenderDropZone;