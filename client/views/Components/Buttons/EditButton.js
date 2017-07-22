import React, {Component} from 'react';


export default class EditButton extends Component {
  render() {
   const {text, id, click} = this.props;
   return <button type="button" className="btn btn-primary" onClick={click}><i className="fa fa-pencil"></i>{text}</button>
  }
}