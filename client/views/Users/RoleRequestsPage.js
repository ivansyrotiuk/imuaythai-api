import { connect } from 'react-redux'
import React, { Component } from 'react';
import { fetchRolesRequests } from "../../actions/RolesRequestsActions"
import Spinner from "../Components/Spinners/Spinner"
import RolesRequestsTable from "../Components/Tables/RolesRequestsTable"

export class RoleRequestsPage extends Component {
    componentWillMount() {
        this.props.fetchRolesRequests();
    }

    accept(userId) {
        console.log('accept' + userId);
    }

    reject(userId) {
        console.log('reject' + userId);
    }

    render() {
        const {roleRequest, fetching} = this.props;

        if (fetching) {
            return <Spinner />
        }

        return (<div>
                  <RolesRequestsTable 
                    roleRequests={ this.props.roleRequests } 
                    acceptClick={ this.accept } 
                    rejectClick={ this.reject } />
                </div>);
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        roleRequests: state.RoleRequests.roleRequests,
        fetching: state.RoleRequests.fetching,
        fetched: state.RoleRequests.fetched,
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchRolesRequests: () => {
            dispatch(fetchRolesRequests())
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(RoleRequestsPage)