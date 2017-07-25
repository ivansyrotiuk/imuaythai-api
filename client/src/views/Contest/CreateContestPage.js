import React, { Component } from 'react';
import { Field, reduxForm } from 'redux-form';
import DatePicker from 'react-datepicker';
import moment from 'moment';
import 'react-datepicker/dist/react-datepicker.css';
import RemoveButton from "../Components/Buttons/RemoveButton"
import EditButton from "../Components/Buttons/EditButton"
class CreateContestPage extends Component {



  render() {

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
              <table className="table">
                <thead>
                  <tr>
                    <th className="col-md-10">Contest name</th>
                    <th className="col-md-2">Action</th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td className="col-md-10">Samppa Nori</td>
                    <td>
                      <EditButton/>
                      <RemoveButton/>
                    </td>
                  </tr>
                  <tr>
                    <td className="col-md-10">Estavan Lykos</td>
                    <td>
                      <EditButton/>
                      <RemoveButton/>
                    </td>
                  </tr>
                  <tr>
                    <td className="col-md-10">Chetan Mohamed</td>
                    <td>
                      <EditButton/>
                      <RemoveButton/>
                    </td>
                  </tr>
                  <tr>
                    <td className="col-md-10">Derick Maximinus</td>
                    <td>
                      <EditButton/>
                      <RemoveButton/>
                    </td>
                  </tr>
                  <tr>
                    <td className="col-md-10">Friderik Dávid</td>
                    <td>
                      <EditButton/>
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