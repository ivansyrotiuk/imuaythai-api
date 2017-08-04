import React, { Component } from 'react'
import Login from '../../views/Pages/Login/'
import { connect } from 'react-redux'
import { logout } from '../../actions/AccountActions'
import Header from '../../components/Header/Header'

class HeaderContainer extends Component {
    constructor(props) {
        super(props);
        this.gotoProfile = this.gotoProfile.bind(this);
    }

    gotoProfile() {
        this.props.history.push('users/' + this.props.userId)
    }

    render() {
        return (
            <Header username={ this.props.username } logout={ this.props.logout } gotoProfile={ this.gotoProfile } />
            );
    }
}

const mapStateToProps = (state) => {
    return {
        username: state.Account.user.sub,
        userId: state.Account.user.UserId
    }
}

const mapDispatchToProps = (dispatch) => {
    return ({
        logout: () => dispatch(logout())
    })
}
HeaderContainer = connect(mapStateToProps, mapDispatchToProps)(HeaderContainer)
export default HeaderContainer;