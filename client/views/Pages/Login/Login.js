import React, {Component} from 'react';
import {Field, reduxForm} from 'redux-form';
import {Link} from 'react-router-dom'

class Login extends Component {
  render() {
    const {handleSubmit, pristine, reset, submitting, islogining} = this.props

    return (
      <div className="app flex-row align-items-center">
        <div className="container">
          <div className="row justify-content-center">
            <div className="col-md-8">
              <div className="card-group mb-0">
                <div className="card p-4">
                  <form onSubmit={handleSubmit}>
                    <div className="card-block">
                      <h1>Login</h1>
                      <p className="text-muted">Sign In to your account</p>
                      <div className="input-group mb-3">
                        <span className="input-group-addon">
                          <i className="icon-user"></i>
                        </span>
                        <Field
                          name="login"
                          component="input"
                          type="e-mail"
                          className="form-control"
                          placeholder="E-mail"/>
                      </div>
                      <div className="input-group mb-4">
                        <span className="input-group-addon">
                          <i className="icon-lock"></i>
                        </span>
                        <Field
                          name="password"
                          component="input"
                          type="password"
                          className="form-control"
                          placeholder="Password"/>
                      </div>
                      <div className="row">
                        <div className="col-6">
                          <button
                            type="submit"
                            className="btn btn-primary px-4"
                            disabled={islogining || submitting}>Login</button>
                        </div>
                        <div className="col-6 text-right center-block">

                          <div class="form-check">
                            <label class="form-check-label">
                              <Field
                                name="rememberme"
                                component="input"
                                type="checkbox"
                                class="form-check-input"/>
                              Remember me?
                            </label>
                          </div>
                        </div>
                      </div>
                      <div className="row">
                        <div className="col-md-12 text-right">
                          <button type="button" className="btn btn-link px-0">Forgot password?</button>
                        </div>
                      </div>
                    </div>
                  </form>
                </div>
                <div
                  className="card card-inverse card-primary py-5 d-md-down-none"
                  style={{
                  width: 44 + '%'
                }}>
                  <div className="card-block text-center">
                    <div>
                      <h2>Sign up</h2>
                      <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
                        tempor incididunt ut labore et dolore magna aliqua.</p>
                      <Link to="/register" className="btn btn-primary active mt-3">Register Now!</Link>
                    </div>
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

export default reduxForm({
  form: 'loginForm' // a unique identifier for this form
})(Login)
