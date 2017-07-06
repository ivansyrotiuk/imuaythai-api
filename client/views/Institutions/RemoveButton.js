import React, {Component} from 'react';


export default class RemoveButton extends Component {
  render() {
   const {text, id, click} = this.props;
   return <button type="button" className="btn btn-danger"  onClick={click}><i className="fa fa-trash"></i>{text}</button>
  }
}