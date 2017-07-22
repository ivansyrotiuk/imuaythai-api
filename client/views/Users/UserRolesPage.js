import React, {Component} from 'react';
import Spinner from "../Components/Spinners/Spinner";
import UserRolesTable from "../Components/Tables/UserRolesTable"
import UserRoleRequestForm from "./Forms/UserRoleRequestForm"
import {fetchRoles} from "../../actions/RolesActions";
import {fetchUserRoles, saveUserRoleRequest} from "../../actions/UserRolesActions";
import {connect} from "react-redux";

class UserRolesPage extends Component {
    constructor(props) {
        super(props);
        this.state = {adding: false};
        this.addRole = this.addRole.bind(this);
        this.onCancel = this.onCancel.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
    }
    
    componentWillMount() {
        const userId = this.props.match.params.id;
        this.props.fetchUserRoles(userId);

        if (!this.props.roles.length){
            this.props.fetchRoles();
        }
    }

    addRole(){
        this.setState({adding: true})
    }

    onCancel(){
        this.setState({adding: false})
    }

    onSubmit(values){

    }

    render() {
        const {roles, userRoles} = this.props;

        const content = this.state.adding ? <UserRoleRequestForm roles={roles} onSubmit={this.onSubmit} onCancel={this.onCancel}/>
                                          : <UserRolesTable userRoles={userRoles} addRoleClick={this.addRole}/>
        return (
            <div>
                {content}
            </div>
        );
    }
};

const mapStateToProps = (state, ownProps) => {
    return {
       roles: state.Roles.roles,
       userRoles: state.UserRoles.roles
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
            dispatch(saveUserRoleRequest(roleRequest));
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(UserRolesPage)
