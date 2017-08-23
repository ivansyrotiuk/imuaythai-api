import React, { Component } from 'react';
import { Link } from 'react-router-dom'

export default class InstitutionGeneralInformaitonBlock extends Component {
  constructor(props) {
    super(props);
  }
  render() {
    const {name, address, owner, contactPerson, phone, email} = this.props;
    return (

      <div>
        <h2> { name } </h2>
        <div className="row">
          <div className="col-2">
            <i className="fa fa-home" aria-hidden="true"> </i>
          </div>
          <div className="col-10">
            { address }
          </div>
          <div className="col-2">
            <i className="fa fa-user" aria-hidden="true"> </i>
          </div>
          <div className="col-10">
            { owner }
          </div>
          <div className="col-2">
            <i className="fa fa-id-card" aria-hidden="true">  </i>
          </div>
          <div className="col-10">
            { contactPerson }
          </div>
          <div className="col-2">
            <i className="fa fa-phone" aria-hidden="true"></i>
          </div>
          <div className="col-10">
            { phone }
          </div>
          <div className="col-2">
            <i className="fa fa-envelope" aria-hidden="true"> </i>
          </div>
          <div className="col-10">
            { email }
          </div>
        </div>
      </div>

    )
  }

}

