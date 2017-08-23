import React, { Component } from 'react'
import Login from '../../views/Pages/Login/'
import { connect } from 'react-redux'
import * as actions from '../../actions/AccountActions'
import { saveState, loadState } from '../../localStorage'
import jwtDecode from 'jwt-decode';
import { setAuthToken } from "../../axiosConfiguration"

class LoginContainer extends Component {

    componentWillMount() {
        this.props.resetErrors();
    }
    render() {
        if (this.props.authToken != "") {
            const authAccount = {
                authToken: this.props.authToken,
                error: null,
                fetching: false,
                fetched: false,
                isRegistered: false,
                isLoggedIn: false,
                isResseted: false,
                isConfimed: false,
                rememberMe: !this.props.rememberMe,
                loggedUser: null,
                qrcode: '',
                fetchingUser: false,
                fetchedUser: false,
                user: jwtDecode(this.props.authToken)
            }
            saveState(authAccount)

            setAuthToken(this.props.authToken);

            this.props.history.push("/");
        }

        return (<Login onSubmit={ this.props.onSubmit } fetching={ this.props.fetching } errorMessage={ this.props.error } isLoggedIn={ this.props.isLoggedIn } onDismiss={ this.props.resetErrors }
                />)
    }
}
const mapStateToProps = (state) => {
    return {
        fetching: state.Account.fetching,
        authToken: state.Account.authToken,
        rememberMe: state.Account.rememberMe,
        error: state.Account.error,
        isLoggedIn: state.Account.isLoggedIn
    }
}

const mapDispatchToProps = (dispatch) => {
    return ({
        onSubmit: (values) => {
            if (values.login == undefined || values.password == undefined) {
                dispatch(actions.errorAction("Login or password cannot be empty"));
            } else {
                dispatch(actions.getLoginAccount({
                    email: values.login,
                    password: values.password,
                    rememberMe: values.rememberme
                }));
            }
        },
        resetErrors: () => {
            dispatch(actions.resetErrorAction());
        }
    })
}
LoginContainer = connect(mapStateToProps, mapDispatchToProps)(LoginContainer)
export default LoginContainer;