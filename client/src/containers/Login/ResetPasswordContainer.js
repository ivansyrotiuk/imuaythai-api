import React, { Component } from 'react';
import ResetPassword from '../../views/Pages/ResetPassword/ResetPassword'
import { connect } from 'react-redux'
import * as actions from '../../actions/AccountActions'
class ResetPasswordContainer extends Component {
    constructor() {
        super();

        this.getParams = this
            .getParams
            .bind(this);
    }

    componentWillMount() {
        this.props.resetErrors();
    }

    getParams(queryString) {
        var params = {},
            queries,
            temp,
            i,
            l;
        queries = queryString.split("&");
        for (i = 0, l = queries.length; i < l; i++) {
            temp = queries[i].split('=');
            params[temp[0]] = temp[1];
        }
        params["code"] = params["code"] + "==";
        return params;
    };

    render() {
        var urlString = this.props.location.search;
        var paramString = urlString.substring(urlString.indexOf('?') + 1);
        var params = this.getParams(paramString);

        return (<ResetPassword onSubmit={ this.props.onSubmit } fetching={ this.props.fetching } errorMessage={ this.props.error } initialValues={ params } onDismiss={ this.props.resetErrors }
                  isResseted={ this.props.isResseted } />);
    }
}

const mapStateToProps = (state) => {
    return {
        fetching: state.Account.fetching,
        authToken: state.Account.authToken,
        error: state.Account.error,
        isResseted: state.Account.isResseted
    }
}

const mapDispatchToProps = (dispatch) => {
    return ({
        onSubmit: (values) => {
            if (values.password == undefined || values.confirmpassword == undefined) {
                dispatch(actions.errorAction("Password or confirm password cannot be empty"));
            } else if (values.password != values.confirmpassword) {
                dispatch(actions.errorAction("Passwords must be the same"));
            } else {
                dispatch(actions.getResetPassword({
                    password: values.password,
                    confirmpassword: values.confirmpassword,
                    userid: values.userid,
                    code: values.code
                }));
            }
        },
        resetErrors: () => {
            dispatch(actions.resetErrorAction());
        }
    })
}
ResetPasswordContainer = connect(mapStateToProps, mapDispatchToProps)(ResetPasswordContainer)

export default ResetPasswordContainer;