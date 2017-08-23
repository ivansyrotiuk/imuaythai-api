import React, { Component } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap'

export default class DeleteConfirmationModal extends Component {
  constructor(props) {
    super(props);

    this.toggleDeleteConfirmation = this.toggleDeleteConfirmation.bind(this);

    this.state = {
      deleteConfirmation: false
    };
  }

  toggleDeleteConfirmation() {
    this.setState({
      deleteConfirmation: !this.state.deleteConfirmation
    })
  }

  render() {
    const {deleteClick} = this.props;
    return (
      <Modal isOpen={ this.state.deleteConfirmation } toggle={ this.toggleDeleteConfirmation } className={ this.props.className }>
        <ModalHeader toggle={ this.toggleDeleteConfirmation }>Modal title</ModalHeader>
        <ModalBody>
          Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
          exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat
          nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
        </ModalBody>
        <ModalFooter>
          <Button color="primary" onClick={ deleteClick }>Delete</Button>
          { ' ' }
          <Button color="secondary" onClick={ this.toggleDeleteConfirmation }>Cancel</Button>
        </ModalFooter>
      </Modal>
    )
  }

}


