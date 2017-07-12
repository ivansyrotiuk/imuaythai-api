import React, {Component} from 'react';
import {Button, Modal, ModalHeader, ModalBody, ModalFooter} from 'reactstrap';
import Spinner from "../Components/Spinners/Spinner";
import Cropper from 'react-crop';
import 'react-crop/cropper.css';
import "babel-core/register";
import "babel-polyfill";

export default class AvatarEditor extends Component {
    constructor(props) {
        super(props);
        this.state = {
            image: null,
            previewImage: null,
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
        this.setState({image: evt.target.files[0]})
    }

    async crop() {
        let image = await this
            .refs
            .crop
            .cropImage()
        this.setState({
            previewUrl: window
                .URL
                .createObjectURL(image)
        })
    }

    clear() {
        this.refs.file.value = null
        this.setState({previewUrl: null, image: null})
    }

    imageLoaded(img) {
        if (img.naturalWidth && img.naturalWidth < 262 && img.naturalHeight && img.naturalHeight < 147) {
            this.crop()
        }
    }

    render() {
        return <div className="col">
            <img src={this.props.image}/>
            <div className="btn btn-primary" onClick={this.toggle}>Change</div>

            <Modal
                isOpen={this.state.modal}
                toggle={this.toggle}
                className={this.props.className}>
                <ModalHeader toggle={this.toggle}>Modal title</ModalHeader>
                <ModalBody>
                    <div>

                        <input ref='file' type='file' onChange={this.onChange}/> 
                        
                        {
                            this.state.image && <div>
                                <Cropper
                                    ref='crop'
                                    image={this.state.image}
                                    width={100}
                                    height={80}
                                    onImageLoaded={this.imageLoaded}/>

                                <button className="btn btn-primary" onClick={this.crop}>Crop</button>
                                <button className="btn btn-danger" onClick={this.clear}>Clear</button>
                            </div>
                        }

                        {
                            this.state.previewUrl && <img src={this.state.previewUrl}/>
                        }

                    </div>
                </ModalBody>
                <ModalFooter>
                    <Button color="primary" onClick={this.toggle}>Do Something</Button>{' '}
                    <Button color="secondary" onClick={this.toggle}>Cancel</Button>
                </ModalFooter>
            </Modal>
        </div>

    }
}