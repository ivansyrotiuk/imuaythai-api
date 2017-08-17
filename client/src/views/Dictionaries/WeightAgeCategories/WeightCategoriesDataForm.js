import React, { Component } from 'react';
import { host } from "../../../global"
import axios from "axios";
import { connect } from "react-redux";
import moment from 'moment';
import 'react-datepicker/dist/react-datepicker.css';


import { Field, reduxForm } from 'redux-form';

let WeightCategoriesDataForm = props => {
  const {handleSubmit, pristine, reset, submitting} = props;
  return (

    <form onSubmit={ handleSubmit }>
      <div className="card-block">
        <div className="form-group row">
          <label className="col-md-3 form-control-label" htmlFor="text-input">Name</label>
          <div className="col-md-9">
            <Field name="name" component="input" type="text" className="form-control" placeholder="Name" />
          </div>
        </div>
        <div className="form-group row">
          <label className="col-md-3 form-control-label" htmlFor="text-input">Minimal age</label>
          <div className="col-md-9">
            <Field name="minAge" component="input" type="number" className="form-control" />
          </div>
        </div>
        <div className="form-group row">
          <label className="col-md-3 form-control-label" htmlFor="text-input">Maximal age</label>
          <div className="col-md-9">
            <Field name="maxAge" component="input" type="number" className="form-control" />
          </div>
        </div>
        <div className="form-group row">
          <label className="col-md-3 form-control-label" htmlFor="text-input">Minimal weight</label>
          <div className="col-md-9">
            <Field name="minWeight" component="input" type="number" className="form-control" />
          </div>
        </div>
        <div className="form-group row">
          <label className="col-md-3 form-control-label" htmlFor="text-input">Maximal weight</label>
          <div className="col-md-9">
            <Field name="maxWeight" component="input" type="number" className="form-control" />
          </div>
        </div>
        <div className="form-group row">
          <label className="col-md-3 form-control-label" htmlFor="text-input">Gender</label>
          <div className="col-md-9">
            <Field name="gender" component="select" type="text" className="form-control">
              <option value="male">Male</option>
              <option value="female">Female</option>
            </Field>
          </div>
        </div>
      </div>
      <button type="submit" disabled={ pristine || submitting } className="btn btn-primary pull-right">Save changes</button>
    </form>
    );
};

export default reduxForm({
  form: 'WeightCategoriesDataForm', // a unique identifier for this form
})(WeightCategoriesDataForm);
