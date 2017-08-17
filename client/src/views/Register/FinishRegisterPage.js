import React, { Component } from 'react';
import { Field, reduxForm, formValueSelector } from 'redux-form';
import { Alert } from 'reactstrap';
import { connect } from 'react-redux'

class FinishRegisterPage extends Component {
  render() {
    const {handleSubmit, error, pristine, reset, submitting, countries, roles, gyms, fetchingGyms, hasOwnGym, selectedGymRole, fetching, onCountryChange} = this.props;
    console.log('submitting: ' + submitting);
    const mappedCountries = countries.map((country, i) => <option key={ i } value={ country.id }>
                                                            { country.name }
                                                          </option>);

    const mappedRoles = roles.map((role, i) => <option key={ i } value={ role.id }>
                                                 { role.name }
                                               </option>);

    const mappedGyms = gyms.map((gym, i) => <option key={ i } value={ gym.id }>
                                              { gym.name }
                                            </option>);


    const ownGymCheckboxField = !fetchingGyms && selectedGymRole && <div className="input-group mb-3">
                                                                      <label htmlFor="ownGym"></label>
                                                                      <div>
                                                                        <Field name="ownGym" id="ownGym" component="input" type="checkbox" /> I have own gym
                                                                      </div>
                                                                    </div>
    const gymNameField = !fetchingGyms && hasOwnGym && <div className="input-group mb-4">
                                                         <span className="input-group-addon"><i className="fa fa-building-o"></i></span>
                                                         <Field name="gymName" className="form-control" component="input" type="text" placeholder="Gym name" />
                                                       </div>

    const gymSelectField = !fetchingGyms && !hasOwnGym && <div className="input-group mb-4">
                                                            <span className="input-group-addon"><i className="fa fa-building-o"></i></span>
                                                            <Field name="institutionId" className="form-control" component="select" type="select" placeholder="Role">
                                                              <option value="">Select your gym</option>
                                                              { mappedGyms }
                                                            </Field>
                                                          </div>

    const gymLoading = fetchingGyms && <div className="row justify-content-center" style={ { marginBottom: '10px' } }>
                                         <i className="fa fa-cog fa-spin fa-2x fa-fw"></i>
                                       </div>


    return (
      <div>
        { error && <Alert color="danger">
                     { error }
                   </Alert> }
        <div className="app flex-row align-items-center">
          <div className="container">
            <div className="row justify-content-center">
              <div className="col-md-7">
                <div className="card mx-4">
                  <form onSubmit={ handleSubmit }>
                    <div className="card-block p-4">
                      <h1>Registration. Second step</h1>
                      <p className="text-muted">Set up your account</p>
                      <div className="row">
                        <div className="col-md-6">
                          <div className="input-group mb-3">
                            <span className="input-group-addon"><i className="fa fa-id-card-o"></i></span>
                            <Field name="firstName" className="form-control" component="input" type="text" placeholder="First name" />
                          </div>
                        </div>
                        <div className="col-md-6">
                          <div className="input-group mb-3">
                            <span className="input-group-addon"><i className="fa fa-id-card-o"></i></span>
                            <Field name="surname" className="form-control" component="input" type="text" placeholder="Surname" />
                          </div>
                        </div>
                      </div>
                      <div className="input-group mb-3">
                        <span className="input-group-addon"><i className="fa fa-globe"></i></span>
                        <Field name="countryId" className="form-control" component="select" type="select" placeholder="Your country" onChange={ onCountryChange }>
                          <option value="">Select your country</option>
                          { mappedCountries }
                        </Field>
                      </div>
                      <div className="input-group mb-3">
                        <span className="input-group-addon"><i className="fa fa-user-plus"></i></span>
                        <Field name="roleId" className="form-control" component="select" type="select" placeholder="Role">
                          <option value="">Select your role</option>
                          { mappedRoles }
                        </Field>
                      </div>
                      { gymLoading }
                      { ownGymCheckboxField }
                      { gymNameField }
                      { gymSelectField }
                      <button type="submit" className="btn btn-block btn-success" disabled={ fetching || submitting }>
                        { submitting && <i className="fa fa-spinner fa-pulse fa-1x fa-fw"></i> } Create Account</button>
                    </div>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      );
  }
}
FinishRegisterPage = reduxForm({
  form: 'FinishRegisterPage', // a unique identifier for this form
  destroyOnUnmount: false
})(FinishRegisterPage)

const selector = formValueSelector('FinishRegisterPage')
FinishRegisterPage = connect(state => {
  const hasOwnGym = selector(state, 'ownGym')
  const roleId = selector(state, 'roleId')
  const requestedRole = state.Roles.publicRoles.find(r => r.id === roleId);
  const selectedGymRole = requestedRole !== undefined && requestedRole.normalizedName === "GYMADMIN";
  return {
    hasOwnGym,
    selectedGymRole
  }
})(FinishRegisterPage)

export default FinishRegisterPage;
