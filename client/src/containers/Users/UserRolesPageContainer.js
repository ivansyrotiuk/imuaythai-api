import React, { Component } from 'react';
import Spinner from "../../views/Components/Spinners/Spinner";
import UserRolesTable from "../../views/Components/Tables/UserRolesTable"
import UserRoleRequestForm from "../../views/Users/UserRoleRequestForm"
import Page from "../../views/Components/Page"
import { fetchRoles } from "../../actions/RolesActions";
import { fetchUserRoles, saveUserRoleRequest, addUserRole, setRequestedRole, cancelAddingUserRole } from "../../actions/UserRolesActions";
import { connect } from "react-redux";

class UserRolesPageContainer extends Component {
    constructor(props) {
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
    }

    componentWillMount() {
        const userId = this.props.match.params.id;
        this.props.fetchUserRoles(userId);
        if (!this.props.roles.length) {
            this.props.fetchRoles();
        }
    }

    onSubmit(values) {
        const userRoleRequest = {
            id: 0,
            roleId: values.roleId,
            userId: this.props.match.params.id
        }

        return this.props.saveUserRoleRequest(userRoleRequest);
    }

    render() {
        const {roles, userRoles, requestedRole, adding} = this.props;
        const availableRoles = roles.filter(r => userRoles.findIndex(u => u.roleId === r.id) === -1);


        if (adding) {
            const header = <strong>Add role request</strong>
            const form = <UserRoleRequestForm roles={ availableRoles } onSubmit={ this.onSubmit } onRoleChange={ this.onRoleChange } onCancel={ this.props.cancelAddingUserRole } />
            return <Page header={ header } content={ form } />
        }

        return <UserRolesTable userRoles={ userRoles } addRole={ this.props.addUserRole } requestRoleAgain={ this.onSubmit } />
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        roles: state.Roles.roles,
        userRoles: state.UserRoles.roles,
        requestedRole: state.UserRoles.requestedRole,
        adding: state.UserRoles.adding
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchRoles: () => {
            dispatch(fetchRoles());
        },
        fetchUserRoles: (userId) => {
            dispatch(fetchUserRoles(userId));
        },
        saveUserRoleRequest: (roleRequest) => {
            return dispatch(saveUserRoleRequest(roleRequest));
        },
        addUserRole: () => {
            dispatch(addUserRole());
        },
        cancelAddingUserRole: () => {
            dispatch(cancelAddingUserRole());
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(UserRolesPageContainer)
