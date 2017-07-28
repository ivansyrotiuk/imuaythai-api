import React, {Component} from 'react';
import {host} from "../../../global"
import axios from "axios";
import {connect} from "react-redux";
import moment from 'moment';
import 'react-datepicker/dist/react-datepicker.css';


import {Field, reduxForm} from 'redux-form';

let KhanLevelDataForm = props => {
    const {handleSubmit, pristine, reset, submitting} = props;
    return (

        <form onSubmit={handleSubmit}>

                <div className="card-block">
                    <div className="form-group row">
                        <label className="col-md-3 form-control-label" htmlFor="text-input">Name</label>
                        <div className="col-md-9">
                            <Field
                                name="name"
                                component="input"
                                type="text"
                                className="form-control"
                                placeholder="Name"/>
                        </div>
                    </div>
                    <div className="form-group row">
                        <label className="col-md-3 form-control-label" htmlFor="text-input">Level</label>
                        <div className="col-md-9">
                            <Field
                                name="level"
                                component="input"
                                type="number"
                                className="form-control"
                                placeholder="Level"/>
                        </div>
                    </div>
                    

                </div>
                   <button type="submit"  disabled={pristine || submitting} className="btn btn-primary pull-right">Save changes</button>
        </form>
    );
};

export default reduxForm({
    form: 'KhanLevelDataForm', // a unique identifier for this form
})(KhanLevelDataForm);
