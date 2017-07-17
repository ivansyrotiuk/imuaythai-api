import React, {Component} from 'react'
import Register from '../../views/Pages/Register/'
import {connect} from 'react-redux'
import * as actions from '../../actions/AccountActions'
import Registered from '../../components/Presentational/Registered'

class RegisterContainer extends Component {

    componentWillMount() {
        if (this.props.authToken != "") 
            this.props.history.push("/")
    }

    render() {
        if (this.props.fetched && this.props.error == null) 
            return (<Registered
                headerText="You have been registered successfully"
                description="Please check your e-mail in order to activate your account"
                callback="/"
                callbackButtonText="Return to main page"/>)
        else if (this.props.error != null) 
            return (
                <div>
                    <div class="alert alert-danger" role="alert">Something went wrong. Try again</div>
                    <Register onSubmit={this.props.onSubmit}/>
                </div>
            )
        else 
            return (<Register onSubmit={this.props.onSubmit}/>);

        }
    }

const mapStateToProps = (state) => {
    return {fetching: state.Account.fetching, fetched: state.Account.fetched, authToken: state.Account.authToken, error: state.Account.error}
}

const mapDispatchToProps = (dispatch) => {
    return ({
        onSubmit: (values) => {
            dispatch(actions.getRegisterAccount({email: values.login, password: values.password, confirmpassword: values.confirmpassword, callbackurl: "http://localhost:8080/#/confirmemail"}));
        }
    })
}
RegisterContainer = connect(mapStateToProps, mapDispatchToProps)(RegisterContainer)

export default RegisterContainer;