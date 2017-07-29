import React, { Component } from 'react';
import { Field, reduxForm, FieldArray, formValueSelector } from 'redux-form';
import Datetime from 'react-datetime';
import RemoveButton from "../Components/Buttons/RemoveButton";
import EditButton from "../Components/Buttons/EditButton";
import { connect } from 'react-redux';
import RenderContestCategoriesTable from './RenderContestCategoriesTable';
import DatePicker from 'react-datepicker';
import moment from 'moment';
import 'react-datepicker/dist/react-datepicker.css';

class CreateContestPage extends Component {

  render() {
    const {handleSubmit, submitting, countries, contestCategoryId, contestTypes, contestCategories} = this.props;

    const RenderDatePicker = props => {
      return (
        <div>
          <DatePicker {...props.input} selected={ props.input.value
                                                  ? moment(props.input.value)
                                                  : null } className="form-control" />
          { props.touched && props.error && <span>{ props.error }</span> }
        </div>
        );
    };


    const mappedContestyTypes = contestTypes.map((contestType, i) => (
      <option key={ i } value={ contestType.id }>
        { contestType.name }
      </option>));

    const mappedCountries = countries.map((country, i) => (
      <option key={ i } value={ country.id }>
        { country.name }
      </option>));


    return (
      <div className="animated fadeIn">
        <div className="row">
          <div className="col-md-6">
            <div className="card">
              <div className="card-header">
                <strong>Basic information</strong>
              </div>
              <div className="card-block">
                <form onSubmit={ handleSubmit }>
                  <div className="row">
                    <div className="col-md-12">
                      <div className="form-group">
                        <label>Contest name</label>
                        <Field name="name" component="input" type="text" className="form-control" placeholder="Contest name" />
                      </div>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-md-12">
                      <div className="form-group">
                        <label>Contest date</label>
                        <Field name="date" component={ RenderDatePicker } className="form-control" />
                      </div>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-md-4">
                      <div className="form-group">
                        <label>Contest adress</label>
                        <Field name="address" component="input" className="form-control" placeholder="Adress" />
                      </div>
                    </div>
                    <div className="col-md-4">
                      <div className="form-group">
                        <label>Contest duration</label>
                        <Field name="duration" component="input" className="form-control" placeholder="Contest duration in days" />
                      </div>
                    </div>
                    <div className="col-md-4">
                      <div className="form-group">
                        <label>Rings count</label>
                        <Field name="ringsCount" component="input" className="form-control" placeholder="Rings count" />
                      </div>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-md-4">
                      <div className="form-group">
                        <label>Contest city</label>
                        <Field name="city" component="input" className="form-control" placeholder="City" />
                      </div>
                    </div>
                    <div className="col-md-4">
                      <div className="form-group">
                        <label>Contest country</label>
                        <Field name="countryId" className="form-control" component="select">
                          { mappedCountries }
                        </Field>
                      </div>
                    </div>
                    <div className="col-md-4">
                      <div className="form-group">
                        <label>Date of registration end</label>
                        <Field name="endRegisterDate" component="input" className="form-control" />
                      </div>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-md-12">
                      <div className="form-group">
                        <label className="form-check-label">
                          <Field name="allowUnassociated" component="input" type="checkbox" className="form-check-input" /> Allow unassociated
                        </label>
                      </div>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-md-12">
                      <div className="form-group">
                        <label>Website</label>
                        <Field name="website" component="input" className="form-control" placeholder="Website" />
                      </div>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-md-12">
                      <div className="form-group">
                        <label>Facebook</label>
                        <Field name="facebook" component="input" className="form-control" placeholder="Faecbook" />
                      </div>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-md-12">
                      <div className="form-group">
                        <label>VK</label>
                        <Field name="vk" component="input" className="form-control" placeholder="VK" />
                      </div>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-md-12">
                      <div className="form-group">
                        <label>Twitter</label>
                        <Field name="twitter" component="input" className="form-control" placeholder="Twitter" />
                      </div>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-md-12">
                      <div className="form-group">
                        <label>Instagram</label>
                        <Field name="intagram" component="input" className="form-control" placeholder="Instagram" />
                      </div>
                    </div>
                  </div>
                  <div>
                    <button type="submit" className="btn btn-primary" disabled={ submitting }>Submit</button>
                  </div>
                </form>
              </div>
            </div>
          </div>
          <div className="col-md-6">
            <div className="card">
              <div className="card-header">
                <strong>Contest category</strong>
              </div>
              <div className="card-block">
                <div className="row mb-4">
                  <div className="col-md-10">
                    <Field name="contestCategoryId" className="form-control" component="select">
                      { mappedContestyTypes }
                    </Field>
                  </div>
                  <div className="col-md-2">
                    <button className="btn btn-primary" onClick={ () => {
                                                                    if (contestCategoryId != undefined && (contestCategories == undefined || !contestCategories.find((item) => item.id == contestCategoryId))) {
                                                                      var contestCategory = contestTypes.find((contestCategory) => {
                                                                        return contestCategory.id == contestCategoryId
                                                                      });
                                                                      this.refs.contestCategories.getRenderedComponent().addContestCategory(contestCategory);
                                                                    }
                                                                  } }>Add</button>
                  </div>
                </div>
                <FieldArray name="contestCategories" component={ RenderContestCategoriesTable } withRef ref="contestCategories" />
              </div>
            </div>
          </div>
        </div>
      </div>

      );
  }
}

CreateContestPage = reduxForm({
  form: 'CreateContestPage',
})(CreateContestPage);

const selector = formValueSelector('CreateContestPage');

CreateContestPage = connect(
  state => {
    const contestCategoryId = selector(state, 'contestCategoryId')
    const contestCategories = selector(state, "contestCategories")

    return {
      contestCategoryId,
      contestCategories
    }
  }
)(CreateContestPage)

export default CreateContestPage;