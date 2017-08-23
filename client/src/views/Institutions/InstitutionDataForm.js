import React, { Component } from 'react';
import Spinner from "../Components/Spinners/Spinner";
import { saveFighter } from "../../actions/UsersActions";
import DatePicker from 'react-datepicker';
import { Field, reduxForm, reset } from 'redux-form';
import { connect } from 'react-redux';
import RenderDropZone from '../Users/RenderDropZone';
import moment from 'moment';
import 'react-datepicker/dist/react-datepicker.css';

const inputIconStyle = {
  width: '25px'
}

const socialMediaInputStyleStyle = {
  zIndex: 0
}

const RenderDatePicker = props => {
  return (
    <div>
      <DatePicker {...props.input} dateFormat="DD-MM-YYYY" selected={ props.input.value
                                                                      ? moment(props.input.value)
                                                                      : null } className="form-control" />
      { props.touched && props.error && <span>{ props.error }</span> }
    </div>
    );
};


class InstitutionDataForm extends Component {
  render() {
    const {countries, handleSubmit, pristine, reset, submitting} = this.props;

    const logo = this.props.initialValues != undefined ? this.props.initialValues.logo : undefined;


    const mappedCountries = countries.map((country, i) => <option key={ i } value={ country.id }>
                                                            { country.name }
                                                          </option>);

    const headerStyle = {
      backgroundColor: 'white'
    };

    return (

      <form onSubmit={ handleSubmit }>
        <div className="card">
          <div className="card-header" style={ headerStyle }>
            <i className="fa fa-id-card-o" aria-hidden="true"></i> General Information
          </div>
          <div className="card-block">
            <div className="row">
              <div className="col-md-3">
                <Field name="logo" component={ RenderDropZone } imageUrl={ logo } />
              </div>
              <div className="col-md-9">
                <div className="row">
                  <div className="col-md-12">
                    <div className="form-group">
                      <label className="form-control-label" htmlFor="text-input">Name*</label>
                      <Field name="name" component="input" type="text" className="form-control" placeholder="Gym name" required/>
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-3">
                    <div className="form-group">
                      <label className="form-control-label" htmlFor="text-input">Address*</label>
                      <Field name="address" component="input" className="form-control" type="text" placeholder="Address" required/>
                    </div>
                  </div>
                  <div className="col-md-3">
                    <div className="form-group">
                      <label className="form-control-label" htmlFor="text-input">City*</label>
                      <Field name="city" component="input" className="form-control" type="input" placeholder="City" required/>
                    </div>
                  </div>
                  <div className="col-md-3">
                    <div className="form-group">
                      <label className="form-control-label" htmlFor="text-input">Zip Code</label>
                      <Field name="zipCode" component="input" className="form-control" type="input" placeholder="Zip Code" />
                    </div>
                  </div>
                  <div className="col-md-3">
                    <div className="form-group">
                      <label className="form-control-label" htmlFor="text-input">Country*</label>
                      <Field name="countryId" className="form-control" component="select" required>
                        <option value="">No country</option>
                        { mappedCountries }
                      </Field>
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-6">
                    <div className="form-group">
                      <label className="form-control-label" htmlFor="text-input">Owner</label>
                      <Field name="owner" component="input" className="form-control" type="input" placeholder="Owner" />
                    </div>
                  </div>
                  <div className="col-md-6">
                    <div className="form-group">
                      <label className="form-control-label" htmlFor="text-input">Contact person</label>
                      <Field name="contactPerson" component="input" className="form-control" type="input" placeholder="Contact person" />
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-6">
                    <div className="form-group">
                      <label className="form-control-label" htmlFor="text-input">Phone*</label>
                      <Field name="phone" component="input" className="form-control" type="text" placeholder="Phone" required/>
                    </div>
                  </div>
                  <div className="col-md-6">
                    <div className="form-group">
                      <label className="form-control-label" htmlFor="text-input">Email*</label>
                      <Field name="email" component="input" className="form-control" type="email" placeholder="Email" required/>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="card">
          <div className="card-header" style={ headerStyle }>
            <i className="fa fa-facebook-square" aria-hidden="true"></i> Social media
          </div>
          <div className="card-block">
            <div className="form-group row">
              <div className="col-md-12">
                <div className="input-group">
                  <span className="input-group-addon">
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  <i className="fa fa-facebook" style={ inputIconStyle }></i>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  </span>
                  <Field name="facebook" component="input" type="text" className="form-control" placeholder="Facebook" style={ socialMediaInputStyleStyle } />
                </div>
              </div>
            </div>
            <div className="form-group row">
              <div className="col-md-12">
                <div className="input-group">
                  <span className="input-group-addon">
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  <i className="fa fa-instagram" style={ inputIconStyle }></i>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  </span>
                  <Field name="instagram" component="input" className="form-control" type="text" placeholder="Instagram" style={ socialMediaInputStyleStyle } />
                </div>
              </div>
            </div>
            <div className="form-group row">
              <div className="col-md-12">
                <div className="input-group">
                  <span className="input-group-addon">
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  <i className="fa fa-twitter" style={ inputIconStyle }></i>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  </span>
                  <Field name="twitter" component="input" className="form-control" type="input" placeholder="Twitter" style={ socialMediaInputStyleStyle } />
                </div>
              </div>
            </div>
            <div className="form-group row">
              <div className="col-md-12">
                <div className="input-group">
                  <span className="input-group-addon">
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  <i className="fa fa-vk" style={ inputIconStyle }></i>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  </span>
                  <Field name="vk" component="input" className="form-control" type="input" placeholder="Vk" style={ socialMediaInputStyleStyle } />
                </div>
              </div>
            </div>
            <div className="form-group row">
              <div className="col-md-12">
                <div className="input-group">
                  <span className="input-group-addon">
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  <i className="fa fa-globe" style={ inputIconStyle }></i>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              </span>
                  <Field name="website" component="input" className="form-control" type="input" placeholder="Website" style={ socialMediaInputStyleStyle } />
                </div>
              </div>
            </div>
          </div>
        </div>
        <button type="button" type="submit" disabled={ pristine || submitting } className="btn btn-primary pull-right">Save</button>
      </form>
      );
  }
}
;

export default reduxForm({
  form: 'InstitutionDataForm',
  enableReinitialize: true
})(InstitutionDataForm);
