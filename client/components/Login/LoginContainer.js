import React, {Component} from 'react'
import Login from '../../views/Pages/Login/'
import {connect} from 'react-redux'
import * as actions from '../../actions/AccountActions'
import {hashHistory} from 'react-router-dom'

class LoginContainer extends Component {

    render() {
        if (this.props.authToken != "") 
            this.props.history.push("/");
        
        return (< Login onSubmit = {
            this.props.onSubmit
        }
        islogining = {
            this.props.fetching
        } />)
    }
}
const mapStateToProps = (state) => {
    return {fetching: state.Account.fetching, authToken: state.Account.authToken}
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return ({
        onSubmit: (values) => {
            dispatch(actions.getLoginAccount({email: values.login, password: values.password}));
        }
    })
}
LoginContainer = connect(mapStateToProps, mapDispatchToProps)(LoginContainer)
export default LoginContainer;