import React, { Component } from 'react';
import 'react-datepicker/dist/react-datepicker.css';
import { Field, reduxForm } from 'redux-form';
import { connect } from 'react-redux';
import RenderDropZone from './RenderDropZone';
import moment from 'moment';
import Datetime from 'react-datetime';
import 'react-datetime/css/react-datetime.css';

const inputIconStyle = {
  width: '25px'
}

const socialMediaInputStyleStyle = {
  zIndex: 0
}

const RenderDatePicker = props => {
  return (
    <Datetime {...props.input} selected={ props.input.value } dateFormat="DD-MM-YYYY" timeFormat="HH:mm" />
    );
};

class CommonUserDataForm extends Component {
  render() {
    const {handleSubmit, pristine, reset, submitting, countries, gyms} = this.props;
    const mappedCountries = countries.map((country, i) => <option key={ i } value={ country.id }>
                                                            { country.name }
                                                          </option>);

    const mappedGyms = gyms.map((gym, i) => <option key={ i } value={ gym.id }>
                                              { gym.name }
                                            </option>);



    return (
      <form onSubmit={ handleSubmit }>
        <div className="card">
          <div className="card-header" style={ { backgroundColor: 'white' } }>
            <i className="fa fa-id-card-o" aria-hidden="true"></i> Common
          </div>
          <div className="card-block">
            <div className="row">
              <div className="col-md-3">
                <Field name="avatarImage" component={ RenderDropZone } imageUrl={ this.props.imageUrl } />
                { console.log(this.props.imageUrl) }
              </div>
              <div className="col-md-9">
                <div className="row">
                  <div className="col-md-6">
                    <div className="form-group">
                      <label htmlFor="text-input">First name</label>
                      <Field name="firstname" component="input" type="text" className="form-control" placeholder="First Name" />
                    </div>
                  </div>
                  <div className="col-md-6">
                    <div className="form-group">
                      <label htmlFor="text-input">Surname</label>
                      <Field name="surname" component="input" className="form-control" type="text" placeholder="Surname" />
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-6">
                    <div className="form-group">
                      <label htmlFor="text-input">Nationality</label>
                      <Field name="nationality" component="input" className="form-control" type="input" placeholder="Nationality" />
                    </div>
                  </div>
                  <div className="col-md-6">
                    <div className="form-group">
                      <label htmlFor="text-input">Birthdate</label>
                      <Field name="birthdate" component={ RenderDatePicker } type="input" />
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-6">
                    <div className="form-group">
                      <label htmlFor="text-input">Gender</label>
                      <Field name="gender" component="select" className="form-control">
                        <option value="male">Male</option>
                        <option value="female">Female</option>
                      </Field>
                    </div>
                  </div>
                  <div className="col-md-6">
                    <div className="form-group">
                      <label htmlFor="text-input">Phone</label>
                      <Field name="phone" component="input" className="form-control" type="text" placeholder="Phone" />
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div className="form-group row">
              <label className="col-md-3 form-control-label" htmlFor="text-input">Country</label>
              <div className="col-md-9">
                <Field name="countryId" className="form-control" component="select">
                  <option value="">No country</option>
                  { mappedCountries }
                </Field>
              </div>
            </div>
            <div className="form-group row">
              <label className="col-md-3 form-control-label" htmlFor="text-input">Gym</label>
              <div className="col-md-9">
                <Field name="institutionId" className="form-control" component="select">
                  <option value="">No gym</option>
                  { mappedGyms }
                </Field>
              </div>
            </div>
          </div>
        </div>
        <div className="card">
          <div className="card-header" style={ { backgroundColor: 'white' } }>
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
          </div>
        </div>
        <button type="submit" disabled={ pristine || submitting } className="btn btn-primary pull-right">
          { submitting && <i className="fa fa-spinner fa-pulse fa-1x fa-fw"></i> } Save
        </button>
      </form>
      );
  };
}
;

CommonUserDataForm = reduxForm({
  form: 'CommonUserDataForm'
})(CommonUserDataForm);
export default CommonUserDataForm;
