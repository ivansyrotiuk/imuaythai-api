import React, {Component} from 'react';
import {Field, reduxForm} from 'redux-form'

class ResetPassword extends Component {
    render() {
        const {handleSubmit, code, userid, fetching} = this.props

        return (
            <div className="app flex-row align-items-center">
                <div className="container">
                    <div className="row justify-content-center">
                        <div className="col-md-6">
                            <div className="card mx-4">
                                <form onSubmit={handleSubmit}>
                                    <div className="card-block p-4">
                                        <h1>Reset password</h1>
                                        <p className="text-muted">Reset your password</p>
                                        <div className="input-group mb-3">
                                            <span className="input-group-addon">
                                                <i className="icon-lock"></i>
                                            </span>
                                            <Field
                                                name="password"
                                                className="form-control"
                                                component="input"
                                                type="password"
                                                placeholder="Password"/>

                                        </div>
                                        <div className="input-group mb-4">
                                            <span className="input-group-addon">
                                                <i className="icon-lock"></i>
                                            </span>
                                            <Field
                                                name="confirmpassword"
                                                className="form-control"
                                                component="input"
                                                type="password"
                                                placeholder="Repeat password"/>
                                        </div>
                                        <Field name="code" component="input" type="hidden" value={code}/>
                                        <Field name="userid" component="input" type="hidden" value={userid}/>

                                        <button type="submit" className="btn btn-block btn-success" disabled={fetching}>Save new password</button>
                                    </div>
                                </form>
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
