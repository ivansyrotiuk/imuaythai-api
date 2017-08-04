import React, { Component } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import Spinner from "../Components/Spinners/Spinner";
import Cropper from 'react-crop';
import 'react-crop/cropper.css';
import "babel-core/register";
import "babel-polyfill";

export default class RenderAvatarEditor extends Component {
    constructor(props) {
        super(props);
        this.state = {
            image: null,
            modal: false
        };

        this.toggle = this
            .toggle
            .bind(this);
        this.onChange = this
            .onChange
            .bind(this);
        this.crop = this
            .crop
            .bind(this);
        this.clear = this
            .clear
            .bind(this);
        this.imageLoaded = this
            .imageLoaded
            .bind(this);
    }

    toggle() {
        this.setState({
            modal: !this.state.modal
        });
    }

    onChange(evt) {
        this.setState({
            image: evt.target.files[0]
        })
    }

    async crop() {
        var image = await this.refs.crop.cropImage()
        this.props.input.onChange(image)
        this.toggle();
    }

    clear() {
        this.refs.file.value = null
        this.setState({
            image: null
        })
    }

    imageLoaded(img) {
        if (img.naturalWidth && img.naturalWidth < 262 && img.naturalHeight && img.naturalHeight < 147) {
            this.crop()
        }
    }

    render() {
        return <div className="col-md-7">
                 <div className="btn btn-primary" onClick={ this.toggle }>Choose avatar</div>
                 <Modal isOpen={ this.state.modal } toggle={ this.toggle } className={ this.props.className }>
                   <ModalHeader toggle={ this.toggle }>Choose avatar</ModalHeader>
                   <ModalBody>
                     <div>
                       <input ref='file' type='file' onChange={ this.onChange } />
                       { this.state.image && <div>
                                               <Cropper ref='crop' image={ this.state.image } width={ 100 } height={ 80 } onImageLoaded={ this.imageLoaded } />
                                             </div> }
                     </div>
                   </ModalBody>
                   <ModalFooter>
                     <button type="button" className="btn btn-primary" onClick={ this.crop }>Crop</button>
                     { ' ' }
                     <button type="button" className="btn btn-danger" onClick={ this.toggle }>Cancel</button>
                   </ModalFooter>
                 </Modal>
               </div>

    }
}