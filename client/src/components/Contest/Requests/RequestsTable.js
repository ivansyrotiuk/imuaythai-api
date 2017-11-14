import React from 'react';
import PropTypes from 'prop-types';
import RequestRow from "./RequestRow";
import EditButton from "../../../views/Components/Buttons/EditButton";
import AcceptButton from "../../../views/Components/Buttons/AcceptButton";
import RejectButton from "../../../views/Components/Buttons/RejectButton";
import RemoveButton from "../../../views/Components/Buttons/RemoveButton";

const RequestsTable = props => {
    const {requests, actions} = props;

    const mappedRequests = requests.map((request, i) => <RequestRow key={i} request={request}>
            {actions.edit && <EditButton accepting={ request.accepting } click={ () => actions.edit(request) } />}
            {actions.accept && <AcceptButton accepting={ request.accepting } click={ () => actions.accept(request) } />}
            {actions.reject && <RejectButton rejecting={ request.rejecting } click={ () => actions.reject(request) } />}
            {actions.remove && <RemoveButton removing={request.removing} click={() => actions.remove(request)}/>}
        </RequestRow>);

    return (<table className="table table-hover mb-0 hidden-sm-down">
        <thead>
        <tr>
            <th className="col-2">Name</th>
            <th>Gym</th>
            <th>City</th>
            <th>Country</th>
            <th>Status</th>
            <th>Accepted by</th>
            <th className="text-center">Actions</th>
        </tr>
        </thead>
        <tbody>
            {mappedRequests}
        </tbody>
    </table>);
};

RequestsTable.defaultProps = {
    requests: [],
    actions: {}
};

RequestsTable.propTypes = {
    requests: PropTypes.array,
    actions: PropTypes.object
};

export default RequestsTable;
