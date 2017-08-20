import React, { Component } from 'react';
import { Field, reduxForm, FieldArray, formValueSelector } from 'redux-form';
import RemoveButton from "../Components/Buttons/RemoveButton";
import EditButton from "../Components/Buttons/EditButton";
import { connect } from 'react-redux';
import RenderContestCategoriesTable from './RenderContestCategoriesTable';
import RenderContestRings from './RenderContestRings'
import moment from 'moment';
import Datetime from 'react-datetime';

import { createContestRing } from '../../common/contestConstructors'
import { RenderDatePicker } from '../Forms/RenderDatePickers'

const RenderCondestDurationInput = props => <input {...props.input} type="number" name="quantity" min="1" max="5" className="form-control" placeholder="Contest duration in days" />
const RenderWaiKhruTimeInput = props => <input {...props.input} type="number" name="quantity" min="1" max="5" className="form-control" placeholder="Wai Khru time" />

class CreateContestPage extends Component {
  constructor(props) {
    super(props);
    this.contestDurationChange = this.contestDurationChange.bind(this);
  }

  contestDurationChange(e) {
    const {startDate} = this.props;
    const rings = this.refs.rings.value;
    const duration = e.target.value;
    const contestDuration = duration > 5 ? 5 : duration;
    const ringsCount = rings !== undefined ? rings.length : 0;
    if (contestDuration > ringsCount) {

      const lastDate = ringsCount > 0 ? moment(rings[ringsCount - 1].contestDay) : moment(startDate);
      const start = ringsCount > 0 ? 1 : 0;
      const end = contestDuration - ringsCount + start;

      for (let i = start; i < end; i++) {
        const contestDay = lastDate.add(i, 'days').toDate();
        const ringItem = createContestRing(contestDay);
        this.refs.rings.value.push(ringItem);
      }
    } else if (contestDuration < ringsCount) {
      for (let i = 0; i < ringsCount - contestDuration; i++) {
        this.refs.rings.getRenderedComponent().removeLast();
      }
    }
  }


  render() {
    const {handleSubmit, submitting, duration, startDate, pristine, countries, contestCategoryId, contestTypes, contestRanges, categories, contestCategories} = this.props;


    const mappedContestTypes = contestTypes.map((type, i) => (
      <option key={ i } value={ type.id }>
        { type.name }
      </option>));

    const mappedCountries = countries.map((country, i) => (
      <option key={ i } value={ country.id }>
        { country.name }
      </option>));

    const mappedRanges = contestRanges.map((range, i) => (
      <option key={ i } value={ range.id }>
        { range.name }
      </option>));

    const mappedCategories = categories.map((category, i) => (
      <option key={ i } value={ category.id }>
        { category.name }
      </option>));



    return (
      <div className="animated fadeIn">
        <div className="row">
          <div className="col-md-7">
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
                    <div className="col-md-6">
                      <div className="form-group">
                        <label>Contest date</label>
                        <Field name="date" component={ RenderDatePicker } className="form-control" type="input" />
                      </div>
                    </div>
                    <div className="col-md-6">
                      <div className="form-group">
                        <label>Date of registration end</label>
                        <Field name="endRegistrationDate" component={ RenderDatePicker } className="form-control" type="input" />
                      </div>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-md-4">
                      <div className="form-group">
                        <label>Range</label>
                        <Field name="contestRangeId" component="select" className="form-control" type="select">
                          <option>-</option>
                          { mappedRanges }
                        </Field>
                      </div>
                    </div>
                    <div className="col-md-4">
                      <div className="form-group">
                        <label>Type</label>
                        <Field name="contestTypeId" component="select" className="form-control" type="select">
                          <option>-</option>
                          { mappedContestTypes }
                        </Field>
                      </div>
                    </div>
                    <div className="col-md-4">
                      <div className="form-group">
                        <label>Wai Khru time</label>
                        <Field name="waiKhruTime" component={ RenderWaiKhruTimeInput } className="form-control" />
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
                        <Field name="instagram" component="input" className="form-control" placeholder="Instagram" />
                      </div>
                    </div>
                  </div>
                  <div>
                    <button type="submit" className="btn btn-primary pull-right" disabled={ pristine || submitting }>
                      { submitting && <i className="fa fa-spinner fa-pulse fa-1x fa-fw"></i> } Save</button>
                  </div>
                </form>
              </div>
            </div>
          </div>
          <div className="col-md-5">
            <div className="card">
              <div className="card-header">
                <strong>Contest category</strong>
              </div>
              <div className="card-block">
                <div className="row mb-4">
                  <div className="col-md-10">
                    <Field name="contestCategoryId" className="form-control" component="select">
                      { mappedCategories }
                    </Field>
                  </div>
                  <div className="col-md-2">
                    <button className="btn btn-primary" onClick={ () => {
                                                                    if (contestCategoryId != undefined && (contestCategories == undefined || !contestCategories.find((item) => item.id == contestCategoryId))) {
                                                                      var contestCategory = categories.find((contestCategory) => {
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
            <div className="card">
              <div className="card-header">
                <strong>Rings</strong>
              </div>
              <div className="card-block">
                <div className="row mb-4">
                  <div className="col-md-12">
                    <div className="form-group">
                      <label>Contest duration</label>
                      <Field name="duration" component={ RenderCondestDurationInput } onChange={ this.contestDurationChange } />
                    </div>
                  </div>
                </div>
                <div className="row mb-4">
                  <div className="col-md-12">
                    <FieldArray name="rings" component={ RenderContestRings } withRef ref="rings" />
                  </div>
                </div>
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
  enableReinitialize: true
})(CreateContestPage);

const selector = formValueSelector('CreateContestPage');

CreateContestPage = connect(
  state => {
    const contestCategoryId = selector(state, 'contestCategoryId');
    const contestCategories = selector(state, 'contestCategories');
    const duration = selector(state, 'duration');
    const startDate = selector(state, 'date');
    const rings = selector(state, 'rings');
    return {
      contestCategoryId,
      contestCategories,
      duration,
      startDate,
      rings
    }
  }
)(CreateContestPage)

export default CreateContestPage;