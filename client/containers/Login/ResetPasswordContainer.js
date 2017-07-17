import React, {Component} from 'react';
import ResetPassword from '../../views/Pages/ResetPassword/ResetPassword'
import {connect} from 'react-redux'
import * as actions from '../../actions/AccountActions'
class ResetPasswordContainer extends Component {
    constructor() {
        super();

        this.getParams = this
            .getParams
            .bind(this);
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

        return (<ResetPassword
            onSubmit={this.props.onSubmit}
            fetching={this.props.fetching}
            initialValues={params}/>);
    }
}

const mapStateToProps = (state) => {
    return {fetching: state.Account.fetching, authToken: state.Account.authToken, error: state.Account.error, fetched: state.Account.fetched}
}

const mapDispatchToProps = (dispatch) => {
    return ({
        onSubmit: (values) => {
            dispatch(actions.getResetPassword({password: values.password, confirmpassword: values.confirmpassword, userid: values.userid, code: values.code}));
        }
    })
}
ResetPasswordContainer = connect(mapStateToProps, mapDispatchToProps)(ResetPasswordContainer)

export default ResetPasswordContainer;