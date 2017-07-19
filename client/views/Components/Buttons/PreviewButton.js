import React, {Component} from 'react';


export default class PreviewButton extends Component {
  render() {
   const {text, id, click} = this.props;
   return <button type="button" className="btn btn-secondary" onClick={click}><i className="fa fa-external-link"></i>{text}</button>
  }
}