import React, { Component } from 'react';
import { Field, reduxForm } from 'redux-form';
import { Alert } from 'reactstrap';

class Register extends Component {
  render() {
    const {handleSubmit, pristine, reset, submitting, fetching, errorMessage, fetched, onDismiss} = this.props
    const loadingButton = <a className="btn btn-block btn-success" disabled={ fetching || submitting }>
                            <i className="fa fa-spinner fa-pulse fa-1x fa-fw"></i> Create Account
                          </a>;
    const button = <button type="submit" className="btn btn-block btn-success" disabled={ fetching || submitting }>Create Account</button>;
    return (
      <div>
        <Alert color="danger" isOpen={ !fetching && errorMessage != null } toggle={ onDismiss }>
          { errorMessage != null ? errorMessage : "" }
        </Alert>
        <Alert color="success" isOpen={ !fetching && errorMessage == null && fetched } toggle={ onDismiss }>
          <span>You have been registered successfully</span>
          <br/>
          <span>Please check your e-mail in order to activate your account</span>
        </Alert>
        <div className="app flex-row align-items-center">
          <div className="container">
            <div className="row justify-content-center">
              <div className="col-md-6">
                <div className="card mx-4">
                  <form onSubmit={ handleSubmit }>
                    <div className="card-block p-4">
                      <h1>Register</h1>
                      <p className="text-muted">Create your account</p>
                      <div className="input-group mb-3">
                        <span className="input-group-addon">
                                                                          <i className="icon-user"></i>
                                                                        </span>
                        <Field name="login" className="form-control" component="input" type="e-mail" placeholder="E-mail" />
                      </div>
                      <div className="input-group mb-3">
                        <span className="input-group-addon">
                                                                          <i className="icon-lock"></i>
                                                                        </span>
                        <Field name="password" className="form-control" component="input" type="password" placeholder="Password" />
                      </div>
                      <div className="input-group mb-4">
                        <span className="input-group-addon">
                                                                          <i className="icon-lock"></i>
                                                                        </span>
                        <Field name="confirmpassword" className="form-control" component="input" type="password" placeholder="Repeat password" />
                      </div>
                      { fetching
                        ? loadingButton
                        : button }
                    </div>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      );
  }
}
export default reduxForm({
  form: 'registerForm' // a unique identifier for this form
})(Register)
