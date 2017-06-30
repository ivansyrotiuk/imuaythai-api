import React from "react"
import {Link} from "react-router";

export default class Login extends React.Component {
    render() {

        return (

                <div class="col-md-12">
                    <div class="modal-dialog">
                        <div class="modal-content">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">Sign In</h3>
                                    </div>
                                    <div class="panel-body">
                                        <form role="form">
                                            <fieldset>
                                                <div class="form-group">
                                                    <input class="form-control" placeholder="E-mail" name="email" type="email" autofocus=""/>
                                                </div>
                                                <div class="form-group">
                                                    <input class="form-control" placeholder="Password" name="password" type="password" value=""/>
                                                </div>
                                                <div class="checkbox">
                                                    <label>
                                                        <input name="remember" type="checkbox" value="Remember Me"/>Remember Me
                                                    </label>
                                                </div>
                                        
                                                <a href="javascript:;" class="btn btn-sm btn-success">Login</a>
                                            </fieldset>
                                        </form>
                                    </div>
                                </div>
                    </div>
                </div>


        );
    }
}

