import React, { Component } from 'react';
import { Field, reduxForm } from 'redux-form'
import { Link } from 'react-router-dom'
import { Alert } from 'reactstrap';

class ForgotPassword extends Component {
  render() {
    const {handleSubmit, fetching, errorMessage, onDismiss, submitting, fetched} = this.props;

    const loadingButton = <a class="btn btn-success" disabled={ fetching || submitting }>
                            <i class="fa fa-spinner fa-pulse fa-1x fa-fw"></i> Reset password
                          </a>;
    const button = <button type="submit" className="btn btn-success" disabled={ fetching || submitting }>Reset password</button>;
    return (
      <div>
        <Alert color="danger" isOpen={ !fetching && errorMessage != null } toggle={ onDismiss }>
          { errorMessage != null ? errorMessage : "" }
        </Alert>
        <Alert color="success" isOpen={ !fetching && errorMessage == null && fetched } toggle={ onDismiss }>
          <span>You have reset your password successfully</span>
          <br/>
          <span>A mail with a link to set a new password has been sent</span>
          <br/>
          <Link to="/">Click here to go back to main page</Link>
        </Alert>
        <div className="container">
          <h1 className="text-center">Please enter your e-mail in order to reset password</h1>
          <form onSubmit={ handleSubmit }>
            <div className="row mt-4">
              <div className="col-md-6 offset-md-2">
                <div className="input-group mb-3">
                  <span className="input-group-addon"> <i className="icon-user"></i></span>
                  <Field name="email" className="form-control" component="input" type="e-mail" placeholder="E-mail" />
                </div>
              </div>
              <div className="col-md-4">
                { fetching ? loadingButton : button }
              </div>
            </div>
          </form>
        </div>
      </div>
      );
  }
}
export default reduxForm({
  form: 'forgotPasswordForm'
})(ForgotPassword)
