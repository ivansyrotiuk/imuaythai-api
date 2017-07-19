import React, {Component} from 'react'
import Login from '../../views/Pages/Login/'
import {connect} from 'react-redux'
import * as actions from '../../actions/AccountActions'
import {saveState, loadState} from '../../localStorage'
import jwtDecode from 'jwt-decode';

class LoginContainer extends Component {

    render() {
        if (this.props.authToken != "") {
            if (this.props.rememberMe) {
                const authAccount = {
                    authToken: this.props.authToken,
                    error: null,
                    fetching: false,
                    fetched: false,
                    rememberMe: !this.props.rememberMe,
                    user: (this.props.authToken)
                }
                saveState(authAccount)
            }
            this
                .props
                .history
                .push("/");
        }

        return (< Login onSubmit = {
            this.props.onSubmit
        }
        islogining = {
            this.props.fetching
        } />)
    }
}
const mapStateToProps = (state) => {
    return {fetching: state.Account.fetching, authToken: state.Account.authToken, rememberMe: state.Account.rememberMe}
}

const mapDispatchToProps = (dispatch) => {
    return ({
        onSubmit: (values) => {
            dispatch(actions.getLoginAccount({email: values.login, password: values.password, rememberMe: values.rememberme}));
        }
    })
}
LoginContainer = connect(mapStateToProps, mapDispatchToProps)(LoginContainer)
export default LoginContainer;