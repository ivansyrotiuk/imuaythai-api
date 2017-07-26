import React, { Component } from 'react';
import { Field, reduxForm } from 'redux-form';
import DatePicker from 'react-datepicker';
import moment from 'moment';
import 'react-datepicker/dist/react-datepicker.css';
import RemoveButton from "../Components/Buttons/RemoveButton"
import EditButton from "../Components/Buttons/EditButton"
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
class CreateContestPage extends Component {



  render() {
    var toggle = false;
    var isopen = false;
    const contestTypes = ["contest1", "contest2", "contest3", "contest4", "contest5"];
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

    const {handleSubmit, submitting, countries} = this.props;
    const mappedCountries = countries.map((country, i) => <option key={ i } value={ country.id }>
                                                            { country.name }
                                                          </option>);
    const mappedContestTypes = contestTypes.map((contestType, i) => <option key={ i } value={ i }>
                                                                      { contestType }
                                                                    </option>)
    return (
      <div classname="container">
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
              <div className="col-md-1 offset-md-11">
                <span className="btn btn-link">Create</span>
                <Modal isOpen="true" toggle={ this.toggle } className={ this.props.className }>
                  <ModalHeader toggle={ this.toggle }>Add contest type</ModalHeader>
                  <ModalBody>
                    <div className="form-group">
                      <label>Contest Type</label>
                      <Field name="contestType" className="form-control" component="select">
                        { mappedContestTypes }
                      </Field>
                    </div>
                  </ModalBody>
                  <ModalFooter>
                    <Button color="primary" onClick={ this.toggle }>Add</Button>
                    { ' ' }
                    <Button color="secondary" onClick={ this.toggle }>Cancel</Button>
                  </ModalFooter>
                </Modal>
              </div>
              <table className="table">
                <thead>
                  <tr>
                    <th className="col-md-11">Contest name</th>
                    <th className="col-md-1">Remove</th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td className="col-md-11">Samppa Nori</td>
                    <td>
                      <RemoveButton/>
                    </td>
                  </tr>
                  <tr>
                    <td className="col-md-11">Estavan Lykos</td>
                    <td>
                      <RemoveButton/>
                    </td>
                  </tr>
                  <tr>
                    <td className="col-md-11">Chetan Mohamed</td>
                    <td>
                      <RemoveButton/>
                    </td>
                  </tr>
                  <tr>
                    <td className="col-md-11">Derick Maximinus</td>
                    <td>
                      <RemoveButton/>
                    </td>
                  </tr>
                  <tr>
                    <td className="col-md-11">Friderik Dávid</td>
                    <td>
                      <RemoveButton/>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>

      );
  }
}

export default reduxForm({
  form: 'CreateContestPage',
})(CreateContestPage);