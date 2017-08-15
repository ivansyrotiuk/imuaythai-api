import React, { Component } from 'react'
import Login from '../../views/Pages/Login/'
import { connect } from 'react-redux'
import { logout, fetchUser } from '../../actions/AccountActions'
import Header from '../../components/Header/Header'

class HeaderContainer extends Component {
    constructor(props) {
        super(props);
        this.gotoProfile = this.gotoProfile.bind(this);
        if (this.props.user == null && this.props.userId != null)
            this.props.getUser(this.props.userId);
    }

    gotoProfile() {
        this.props.history.push('/users/' + this.props.userId)
    }

    render() {
        if (this.props.user)
            return <Header user={ this.props.user } logout={ this.props.logout } gotoProfile={ this.gotoProfile } />
        else
            return <div></div>

    }
}

const mapStateToProps = (state) => {
    return {
        userId: state.Account.user.UserId,
        user: state.Account.loggedUser
    }
}

const mapDispatchToProps = (dispatch) => {
    return ({
        logout: () => dispatch(logout()),
        getUser: (id) => dispatch(fetchUser(id))
    })
}
HeaderContainer = connect(mapStateToProps, mapDispatchToProps)(HeaderContainer)
export default HeaderContainer;