import React, { Component } from 'react'
import Register from '../../views/Pages/Register/'
import { connect } from 'react-redux'
import * as actions from '../../actions/AccountActions'
import Registered from '../../components/Presentational/Registered'
import { UncontrolledAlert } from 'reactstrap';
import { siteHost } from '../../global'

class RegisterContainer extends Component {

    componentWillMount() {
        this.props.resetErrors();
        if (this.props.authToken != "")
            this.props.history.push("/")
    }

    render() {
        return (<Register onSubmit={ this.props.onSubmit } fetching={ this.props.fetching } errorMessage={ this.props.error } fetched={ this.props.isRegistered } onDismiss={ this.props.resetErrors }
                />)

    }
}

const mapStateToProps = (state) => {
    return {
        fetching: state.Account.fetching,
        isRegistered: state.Account.isRegistered,
        authToken: state.Account.authToken,
        error: state.Account.error
    }
}

const mapDispatchToProps = (dispatch) => {
    return ({
        onSubmit: (values) => {
            dispatch(actions.resetErrorAction());
            if (values.login == undefined || values.password == undefined || values.confirmpassword == undefined) {
                dispatch(actions.errorAction("Login or password cannot be empty"))
            } else if (values.password != values.confirmpassword) {
                dispatch(actions.errorAction("Passwords must be the same"));
            } else {
                dispatch(actions.getRegisterAccount({
                    email: values.login,
                    password: values.password,
                    confirmpassword: values.confirmpassword,
                    callbackurl: siteHost + "confirmemail"
                }));
                values.password = values.login = values.confirmpassword = "";
            }
        },
        resetErrors: () => {
            dispatch(actions.resetErrorAction());
        }
    })
}
RegisterContainer = connect(mapStateToProps, mapDispatchToProps)(RegisterContainer)

export default RegisterContainer;