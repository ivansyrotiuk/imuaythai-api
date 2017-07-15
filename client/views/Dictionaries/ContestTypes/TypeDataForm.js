import React, {Component} from 'react';
import {host} from "../../../global"
import Spinner from "../../Components/Spinners/Spinner";
import {saveType, fetchType, deleteType} from "../../../actions/Dictionaries/SingleContestTypeActions"

import axios from "axios";
import {connect} from "react-redux";
import DatePicker from 'react-datepicker';
import moment from 'moment';
import 'react-datepicker/dist/react-datepicker.css';


import {Field, reduxForm} from 'redux-form';

let TypeDataForm = props => {
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

                    

                </div>
                   <button type="submit"  disabled={pristine || submitting} className="btn btn-primary pull-right">Save changes</button>
        </form>
    );
};

export default reduxForm({
    form: 'TypeDataForm', // a unique identifier for this form
})(TypeDataForm);
