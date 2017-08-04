import React, { Component } from 'react'
import Login from '../../views/Pages/Login/'
import { connect } from 'react-redux'
import { logout } from '../../actions/AccountActions'
import { fetchUser } from '../../actions/UsersActions'
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
        return (<div>
                  { this.props.user ? <Header user={ this.props.user } logout={ this.props.logout } gotoProfile={ this.gotoProfile } /> : "" }
                </div>
            );
    }
}

const mapStateToProps = (state) => {
    return {
        userId: state.Account.user.UserId,
        user: state.SingleUser.user
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