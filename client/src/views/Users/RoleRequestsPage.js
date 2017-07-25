import { connect } from 'react-redux'
import React, { Component } from 'react';
import { fetchRolesRequests, acceptRequest, rejectRequest } from "../../actions/RolesRequestsActions"
import Spinner from "../Components/Spinners/Spinner"
import RolesRequestsTable from "../Components/Tables/RolesRequestsTable"

export class RoleRequestsPage extends Component {
    componentWillMount() {
        this.props.fetchRolesRequests();
    }

    render() {
        const {roleRequest, fetching} = this.props;

        if (fetching) {
            return <Spinner />
        }

        return (<div>
                  <RolesRequestsTable 
                    roleRequests={ this.props.roleRequests } 
                    acceptClick={ this.props.accept } 
                    rejectClick={ this.props.reject } />
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
        },
        accept: (request) => {
            dispatch(acceptRequest(request));
        },
        reject: (request) => {
            dispatch(rejectRequest(request));
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(RoleRequestsPage)