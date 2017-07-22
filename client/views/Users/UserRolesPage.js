import React, {Component} from 'react';
import Spinner from "../Components/Spinners/Spinner";
import UserRolesTable from "../Components/Tables/UserRolesTable"
import UserRoleRequestForm from "./Forms/UserRoleRequestForm"
import {fetchRoles} from "../../actions/RolesActions";
import {fetchUserRoles, saveUserRoleRequest, addUserRole} from "../../actions/UserRolesActions";
import {connect} from "react-redux";

class UserRolesPage extends Component {
    constructor(props) {
        super(props);
        this.state = {
            adding: false
        };
        this.onCancel = this
            .onCancel
            .bind(this);
        this.onSubmit = this
            .onSubmit
            .bind(this);
    }

    componentWillMount() {
        const userId = this.props.match.params.id;
        this.props.fetchUserRoles(userId);

        if (!this.props.roles.length) {
            this.props.fetchRoles();
        }
    }

    onCancel() {
        this.setState({adding: false})
    }

    onSubmit(values) {
        const userRoleRequest = {
            id: 0,
            roleId: values.roleId,
            userId: this.props.match.params.id
        }

        this.props.saveUserRoleRequest(userRoleRequest);
    }

    render() {
        const {roles, userRoles, adding} = this.props;

        const availableRoles = roles.filter(r => userRoles.findIndex(u => u.roleId === r.id) === -1);

        const content = adding
            ? <UserRoleRequestForm
                    roles={availableRoles}
                    onSubmit={this.onSubmit}
                    onCancel={this.onCancel}/>
            : <UserRolesTable 
                    userRoles={userRoles} 
                    addRoleClick={this.props.addUserRole}/>
        return (
            <div>
                {content}
            </div>
        );
    }
};

const mapStateToProps = (state, ownProps) => {
    return {roles: state.Roles.roles, userRoles: state.UserRoles.roles, adding: state.UserRoles.adding}
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
            dispatch(saveUserRoleRequest(roleRequest));
        },
        addUserRole: () => {
            dispatch(addUserRole());
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(UserRolesPage)
