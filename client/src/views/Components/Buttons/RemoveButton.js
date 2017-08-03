import React, { Component } from 'react';


export default class RemoveButton extends Component {
  render() {
    const {text, removing, click} = this.props;
    return (
      <div className="btn btn-link pull-right" onClick={ click }>
        { !removing && <i className="fa fa-trash text-danger"></i> }
        { removing && <i style={ { width: '12px' } } className="fa fa-spinner fa-pulse fa-1x fa-fw "></i> }
      </div>
    )
  }
}