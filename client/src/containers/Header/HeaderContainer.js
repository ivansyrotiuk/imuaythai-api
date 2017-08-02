import React, { Component } from 'react'
import Login from '../../views/Pages/Login/'
import { connect } from 'react-redux'
import { logout } from '../../actions/AccountActions'
import Header from '../../components/Header/Header'

class HeaderContainer extends Component {
    render() {
        return (
            <Header username={ this.props.username } logout={ this.props.logout } />
            );
    }
}

const mapStateToProps = (state) => {
    return {
        username: state.Account.user.sub
    }
}

const mapDispatchToProps = (dispatch) => {
    return ({
        logout: () => dispatch(logout())
    })
}
HeaderContainer = connect(mapStateToProps, mapDispatchToProps)(HeaderContainer)
export default HeaderContainer;