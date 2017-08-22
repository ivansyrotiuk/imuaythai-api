import React, { Component } from 'react';
import { host } from "../../../global"
import axios from "axios";
import { connect } from "react-redux";
import moment from 'moment';
import 'react-datepicker/dist/react-datepicker.css';


import { Field, reduxForm } from 'redux-form';

let WeightCategoriesDataForm = props => {
  const {handleSubmit, pristine, reset, submitting, points, structures} = props;
  const mappedPoints = points.map((point, i) => <option key={ i } value={ point.id }>
                                                  { point.contestRange.name + ' ' + point.contestType.name }
                                                </option>);

  const mappedStructures = structures.map((structure, i) => <option key={ i } value={ structure.id }>
                                                              { structure.weightAgeCategory.name + ' ' + structure.round.name }
                                                            </option>);
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
          <label className="col-md-3 form-control-label" htmlFor="text-input">Fight structure</label>
          <div className="col-md-9">
            <Field name="fightStructureId" className="form-control" component="select">
              <option value="0"></option>
              { mappedStructures }
            </Field>
          </div>
        </div>
        <div className="form-group row">
          <label className="col-md-3 form-control-label" htmlFor="text-input">Contest points</label>
          <div className="col-md-9">
            <Field name="contestTypePointsId" className="form-control" component="select">
              <option value="0"></option>
              { mappedPoints }
            </Field>
          </div>
        </div>
      </div>
      <button type="submit" disabled={ pristine || submitting } className="btn btn-primary pull-right">Save changes</button>
    </form>
    );
};

export default reduxForm({
  form: 'ContestPointDataForm', // a unique identifier for this form
})(WeightCategoriesDataForm);
