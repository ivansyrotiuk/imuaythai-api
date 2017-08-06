import React, { Component } from 'react';
import { connect } from 'react-redux';
import UserEditPageContainer from './UserEditPageContainer';
import LoggedUserEditContainer from './LoggedUserEditContainer';

class UserEditWrapperContainer extends Component {

    render() {
        const userId = this.props.match.params.id;

        if (userId == this.props.loggedUserId)
            return (<LoggedUserEditContainer userId={ userId } />);
        else
            return (<UserEditPageContainer userId={ userId } />);
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        loggedUserId: state.Account.user.UserId
    }
}

export default connect(mapStateToProps, null)(UserEditWrapperContainer)