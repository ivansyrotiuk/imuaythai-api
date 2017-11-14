import React from 'react';
import PropTypes from 'prop-types';
import {
    CONTEST_REQUEST_PENDING,
    CONTEST_REQUEST_ACCEPTED,
    CONTEST_REQUEST_REJECTED
} from '../../../common/contestRequestStatuses'

const RequestRow = props => {
    const {request} = props;

    return (
        <tr>
            <td className="col-2">
                {request.userName}
            </td>
            <td className="col-2">
                {request.institutionName}
            </td>
            <td className="col-1">
                {request.user && request.user.city}
            </td>
            <td className="col-2">
                {request.user && request.user.countryName}
            </td>
            {request.contestCategoryId && <td>
                {request.contestCategoryName}
            </td>}
            <td>
                {request.status === CONTEST_REQUEST_PENDING && <span className="badge badge-warning">Pending</span>}
                {request.status === CONTEST_REQUEST_ACCEPTED && <span className="badge badge-success">Accepted</span>}
                {request.status === CONTEST_REQUEST_REJECTED && <span className="badge badge-danger">Rejected</span>}
            </td>
            <td>
                {request.acceptedByUserName}
            </td>
            <td>
                {props.children}
            </td>
        </tr>
    );
};

RequestRow.defaultProps = {
    request: {}
};

RequestRow.propTypes = {
    request: PropTypes.object
};

export default RequestRow;
