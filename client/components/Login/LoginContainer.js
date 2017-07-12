import React, {Component} from 'react'
import Login from '../../views/Pages/Login/'
import {connect} from 'react-redux'
import * as actions from '../../actions/AccountActions'

class LoginContainer extends Component {
    render() {
        return (< Login onSubmit = {
            this.props.onSubmit
        } />)
    }
}

const mapStateToProps = (state) => {
    return {username: state.username, password: state.password}
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return ({
        onSubmit: (values) => {
            dispatch(actions.loginAccount({login: values.login, password: values.password}));
        }
    })
}
LoginContainer = connect(mapStateToProps, mapDispatchToProps)(LoginContainer)
export default LoginContainer;