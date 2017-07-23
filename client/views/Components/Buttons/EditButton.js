import React, {Component} from 'react';


export default class EditButton extends Component {
  render() {
   const {text, id, click} = this.props;
   return <button type="button" className="btn btn-link" onClick={click}><i className="fa fa-pencil text-primary"></i>{text}</button>
  }
}