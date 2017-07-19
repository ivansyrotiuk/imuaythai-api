import React, {Component} from 'react';
import ForgotPassword from '../../views/Pages/ForgotPassword/ForgotPassword'
import {connect} from 'react-redux'
import * as actions from '../../actions/AccountActions'

class ForgotPasswordContainer extends Component {
    render() {
        return (<ForgotPassword onSubmit={this.props.onSubmit}/>);
    }
}

const mapStateToProps = (state) => {
    return {fetching: state.Account.fetching, authToken: state.Account.authToken, error: state.Account.error, fetched: state.Account.fetched}
}

const mapDispatchToProps = (dispatch) => {
    return ({
        onSubmit: (values) => {
            dispatch(actions.getForgotPassword({email: values.email, callbackurl: "http://localhost:8080/#/resetpassword"}));
        }
    })
}

ForgotPasswordContainer = connect(mapStateToProps, mapDispatchToProps)(ForgotPasswordContainer)
export default ForgotPasswordContainer;