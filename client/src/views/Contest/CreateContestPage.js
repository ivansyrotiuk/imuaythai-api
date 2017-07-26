import React, { Component } from 'react';
import { Field, reduxForm, FieldArray, formValueSelector } from 'redux-form';
import DatePicker from 'react-datepicker';
import moment from 'moment';
import 'react-datepicker/dist/react-datepicker.css';
import RemoveButton from "../Components/Buttons/RemoveButton";
import EditButton from "../Components/Buttons/EditButton";
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Table } from 'reactstrap';
import { connect } from 'react-redux';

class CreateContestPage extends Component {

  render() {
    const {handleSubmit, submitting, countries, contestCategoryId, contestTypes, contestCategories} = this.props;

    const mappedContestyTypes = contestTypes.map((contestType, i) => (
      <option key={ i } value={ contestType.id }>
        { contestType.name }
      </option>));

    const mappedCountries = countries.map((country, i) => (
      <option key={ i } value={ country.id }>
        { country.name }
      </option>));

    const RenderContestCategoriesTable = ({fields, meta: {error, submitFailed}}) => (
      <div>
        <div className="row mb-4">
          <div className="col-md-10">
            <Field name="contestCategoryId" className="form-control" component="select">
              { mappedContestyTypes }
            </Field>
          </div>
          <div className="col-md-2">
            <button className="btn btn-primary" onClick={ () => {
                                                            if (contestCategoryId != undefined)
                                                              fields.push({
                                                                id: contestCategoryId
                                                              })
                                                          } }>Add</button>
          </div>
        </div>
        <Table>
          <thead>
            <tr>
              <th className="col-md-11">
                Contest category
              </th>
              <th className="col-md-1">
                Remove
              </th>
            </tr>
          </thead>
          <tbody>
            { fields.map((member, index) => (<tr key={ index }>
                                               <td className="col-md-11">
                                                 { contestTypes.find((contestType) => {
                                                     return contestType.id == fields.get(index).id
                                                   }).name }
                                               </td>
                                               <td className="col-md-1">
                                                 <RemoveButton click={ () => fields.remove(index) } />
                                               </td>
                                             </tr>)
              ) }
          </tbody>
        </Table>
      </div>
    )

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



    return (
      <div className="container">
        <div className="row">
          <div className="col-md-6">
            <div className="card-header">
              <strong>Basic information</strong>
            </div>
            <div className="card-block">
              <form onSubmit={ handleSubmit }>
                <div className="row">
                  <div className="col-md-12">
                    <div className="form-group">
                      <label>Contest name</label>
                      <Field name="contestname" component="input" type="text" className="form-control" placeholder="First Name" />
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-12">
                    <div className="form-group">
                      <label>Contest date</label>
                      <Field name="contestdate" component={ RenderDatePicker } className="form-control" />
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-4">
                    <div className="form-group">
                      <label>Contest adress</label>
                      <Field name="contestaddress" component="input" className="form-control" placeholder="Adress" />
                    </div>
                  </div>
                  <div className="col-md-4">
                    <div className="form-group">
                      <label>Contest duration</label>
                      <Field name="contestduration" component="input" className="form-control" placeholder="Contest duration in days" />
                    </div>
                  </div>
                  <div className="col-md-4">
                    <div className="form-group">
                      <label>Rings count</label>
                      <Field name="contestringscount" component="input" className="form-control" placeholder="Rings count" />
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-4">
                    <div className="form-group">
                      <label>Contest city</label>
                      <Field name="contestcity" component="input" className="form-control" placeholder="City" />
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
                    <div className="form-check">
                      <label className="form-check-label">
                        <Field name="allowunassociated" component="input" type="checkbox" className="form-check-input" /> Allow unassociated
                      </label>
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-12">
                    <div className="form-group">
                      <label>Website</label>
                      <Field name="contestwebsite" component="input" className="form-control" placeholder="Website" />
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-12">
                    <div className="form-group">
                      <label>Facebook</label>
                      <Field name="contestfacebook" component="input" className="form-control" placeholder="Faecbook" />
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-12">
                    <div className="form-group">
                      <label>VK</label>
                      <Field name="contestvk" component="input" className="form-control" placeholder="VK" />
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-12">
                    <div className="form-group">
                      <label>Twitter</label>
                      <Field name="contesttwitter" component="input" className="form-control" placeholder="Twitter" />
                    </div>
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-12">
                    <div className="form-group">
                      <label>Instagram</label>
                      <Field name="contestinstagram" component="input" className="form-control" placeholder="Instagram" />
                    </div>
                  </div>
                </div>
                <div>
                  <button type="submit" className="btn btn-primary" disabled={ submitting }>Submit</button>
                </div>
              </form>
            </div>
          </div>
          <div className="col-md-6">
            <div className="card-header">
              <strong>Contest category</strong>
            </div>
            <div className="card-block">
              <FieldArray name="contestCategories" component={ RenderContestCategoriesTable } />
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