import React, {Component} from 'react';
import {Field, reduxForm} from 'redux-form'

class ForgotPassword extends Component {
    render() {
        const {handleSubmit} = this.props;
        return (
            <div className="container">
                <h1 className="text-center">Please enter your e-mail in order to reset password</h1>
                <form onSubmit={handleSubmit}>
                    <div className="row mt-4">
                        <div className="col-md-6 offset-md-2">
                            <div className="input-group mb-3">
                                <span className="input-group-addon">
                                    <i className="icon-user"></i>
                                </span>
                                <Field
                                    name="email"
                                    className="form-control"
                                    component="input"
                                    type="e-mail"
                                    placeholder="E-mail"/>
                            </div>
                        </div>
                        <div className="col-md-4">
                            <button type="submit" className="btn  btn-primary">Reset password</button>
                        </div>
                    </div>
                </form>
            </div>
        );
    }
}
export default reduxForm({form: 'forgotPasswordForm'})(ForgotPassword)
