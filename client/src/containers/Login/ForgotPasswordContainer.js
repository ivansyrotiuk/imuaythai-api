import React, { Component } from 'react';
import ForgotPassword from '../../views/Pages/ForgotPassword/ForgotPassword';
import { connect } from 'react-redux';
import * as actions from '../../actions/AccountActions';
import { siteHost } from '../../global';

class ForgotPasswordContainer extends Component {
    componentWillMount() {
        this.props.resetErrors();
        if (this.props.authToken != '') this.props.history.push('/');
    }

    render() {
        return (
            <ForgotPassword
                onSubmit={this.props.onSubmit}
                onDismiss={this.props.resetErrors}
                fetching={this.props.fetching}
                fetched={this.props.fetched}
                errorMessage={this.props.error}
            />
        );
    }
}

const mapStateToProps = state => {
    return {
        fetching: state.Account.fetching,
        authToken: state.Account.authToken,
        error: state.Account.error,
        fetched: state.Account.fetched
    };
};

const mapDispatchToProps = dispatch => {
    return {
        onSubmit: values => {
            if (values.email === undefined) dispatch(actions.errorAction('E-mail cannot be empty.'));
            else
                dispatch(
                    actions.getForgotPassword({
                        email: values.email,
                        callbackurl: siteHost + 'resetpassword'
                    })
                );
        },
        resetErrors: () => {
            dispatch(actions.resetErrorAction());
        }
    };
};

ForgotPasswordContainer = connect(mapStateToProps, mapDispatchToProps)(ForgotPasswordContainer);
export default ForgotPasswordContainer;
