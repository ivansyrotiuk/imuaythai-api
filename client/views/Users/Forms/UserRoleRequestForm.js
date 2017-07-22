import React, { Component } from 'react';
import Spinner from "../../Components/Spinners/Spinner";
import { saveFighter } from "../../../actions/UsersActions";
import UserRolesTable from "../../Components/Tables/UserRolesTable"
import { Field, reduxForm } from 'redux-form';

class UserRolesForm extends Component {
    render() {
        const {handleSubmit, onCancel, pristine, reset, submitting, countries, roles, userRoles} = this.props;

        const mappedRoles = roles.map((role, i) => <option key={ i } 
                                                     value={ role.id }>
                                                     { role.name }
                                                   </option>);
       
        return (
            <div className="animated fadeIn">
              <div className="row">
                <div className="col-lg-12">
                  <div className="card">
                    <div className="card-header">
                      <i className="fa fa-users"></i> User role request
                    </div>
                    <div className="card-block">
                      <form onSubmit={ handleSubmit }>
                        <div className="form-group row">
                          <label className="col-md-3 form-control-label" htmlFor="text-input">Please select your user type</label>
                          <div className="col-md-9">
                            <Field name="roleId" className="form-control" component="select">
                              { mappedRoles }
                            </Field>
                          </div>
                        </div>
                        <button type="reset" class="btn btn-sm btn-danger pull-right" onClick={ onCancel }><i class="fa fa-ban"></i> Cancel</button>
                        <button type="submit" disabled={ pristine || submitting } className="btn btn-sm btn-primary pull-right">
                          {submitting && <i class="fa fa-spinner fa-pulse fa-1x fa-fw"></i> } Save
                        </button>
                      </form>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            );
    }
}
;

export default reduxForm({
    form: 'UserRolesForm'
})(UserRolesForm);
