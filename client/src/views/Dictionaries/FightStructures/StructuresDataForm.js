import React, { Component } from 'react';
import { host } from "../../../global"
import axios from "axios";
import { connect } from "react-redux";
import moment from 'moment';
import 'react-datepicker/dist/react-datepicker.css';


import { Field, reduxForm } from 'redux-form';

let StructuresDataForm = props => {
  const {handleSubmit, pristine, reset, submitting, categories, rounds} = props;
  const mappedCategories = categories.map((category, i) => <option key={ i } value={ category.id }>
                                                             { category.name }
                                                           </option>);

  const mappedRounds = rounds.map((round, i) => <option key={ i } value={ round.id }>
                                                  { round.name }
                                                </option>);
  return (

    <form onSubmit={ handleSubmit }>
      <div className="card-block">
        <div className="form-group row">
          <label className="col-md-3 form-control-label" htmlFor="text-input">Weight category</label>
          <div className="col-md-9">
            <Field name="weightAgeCategoryId" className="form-control" component="select">
              <option value="0"></option>
              { mappedCategories }
            </Field>
          </div>
        </div>
        <div className="form-group row">
          <label className="col-md-3 form-control-label" htmlFor="text-input">Rounds type</label>
          <div className="col-md-9">
            <Field name="roundId" className="form-control" component="select">
              <option value="0"></option>
              { mappedRounds }
            </Field>
          </div>
        </div>
      </div>
      <button type="submit" disabled={ pristine || submitting } className="btn btn-primary pull-right">Save changes</button>
    </form>
    );
};

export default reduxForm({
  form: 'StructuresDataForm', // a unique identifier for this form
})(StructuresDataForm);
