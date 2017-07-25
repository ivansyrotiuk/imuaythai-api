import React, { Component } from 'react'
import Registered from '../../components/Presentational/Registered'
import { connect } from 'react-redux'
import * as actions from '../../actions/AccountActions'
import Spinner from '../../views/Components/Spinners/Spinner'

class ConfirmEmailContainer extends Component {
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
    componentWillMount() {
        this.props.resetErrors();
        if (this.props.authToken != "")
            this.props.history.push("/")
        var urlString = this.props.location.search;
        var params = urlString.substring(urlString.indexOf('?') + 1);
        this
            .props
            .confirmEmail(this.getParams(params));
    }

    render() {
        return (this.props.fetching
            ? <Spinner/>
            : <Registered headerText="Email has been confirmed" description="Now you can log in" callback="/login" callbackButtonText="To login page" />);
    }
}

const mapStateToProps = (state) => {
    return {
        fetching: state.Account.fetching,
        authToken: state.Account.authToken,
        fetched: state.Account.fetched
    }
}

const mapDispatchToProps = (dispatch) => {
    return ({
        confirmEmail: (email) => {
            dispatch(actions.getConfirmAccount(email));
        },
        resetErrors: () => {
            dispatch(actions.resetErrorAction());
        }
    })
}

ConfirmEmailContainer = connect(mapStateToProps, mapDispatchToProps)(ConfirmEmailContainer);

export default ConfirmEmailContainer;