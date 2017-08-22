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
        <p>
          { address }
        </p>
        <p>
          { owner }
        </p>
        <p>
          { contactPerson }
        </p>
        <p>
          { phone }
        </p>
        <p>
          { email }
        </p>
      </div>

    )
  }

}

