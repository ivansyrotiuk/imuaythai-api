import React, { Component } from 'react';
import { Field, reduxForm } from 'redux-form'
import { Alert } from 'reactstrap';
import { Link } from 'react-router-dom';

class ResetPassword extends Component {
  render() {
    const {handleSubmit, code, userid, submitting, fetching, errorMessage, isResseted, onDismiss} = this.props
    const loadingButton = <a class="btn btn-block btn-success" disabled={ fetching || submitting }>
                            <i class="fa fa-spinner fa-pulse fa-1x fa-fw"></i> Save new password
                          </a>;
    const button = <button type="submit" className="btn btn-block btn-success" disabled={ fetching || submitting }>Save new password</button>;

    return (
      <div>
        <Alert color="danger" isOpen={ !fetching && errorMessage != null } toggle={ onDismiss }>
          { errorMessage != null ? errorMessage : "" }
        </Alert>
        <Alert color="success" isOpen={ !fetching && errorMessage == null && isResseted } toggle={ onDismiss }>
          <span>You have reset your password successfully</span>
          <br/>
          <span>Now you can log in with new password</span>
          <br/>
          <Link to="/login">Click here to go back to login page</Link>
        </Alert>
        <div className="app flex-row align-items-center">
          <div className="container">
            <div className="row justify-content-center">
              <div className="col-md-6">
                <div className="card mx-4">
                  <form onSubmit={ handleSubmit }>
                    <div className="card-block p-4">
                      <h1>Reset password</h1>
                      <p className="text-muted">Reset your password</p>
                      <div className="input-group mb-3">
                        <span className="input-group-addon"><i className="icon-lock"></i></span>
                        <Field name="password" className="form-control" component="input" type="password" placeholder="Password" />
                      </div>
                      <div className="input-group mb-4">
                        <span className="input-group-addon"><i className="icon-lock"></i></span>
                        <Field name="confirmpassword" className="form-control" component="input" type="password" placeholder="Repeat password" />
                      </div>
                      <Field name="code" component="input" type="hidden" value={ code } />
                      <Field name="userid" component="input" type="hidden" value={ userid } />
                      { fetching ? loadingButton : button }
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
  form: 'resetPasswordForm' // a unique identifier for this form
})(ResetPassword)
