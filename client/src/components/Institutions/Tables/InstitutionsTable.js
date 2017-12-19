import React from 'react';
import PropTypes from 'prop-types';
import InstitutionRow from './InstitutionRow';

const InstitutionsTable = props => {
    const institutionRows = props.institutions.map((institution, i) => (
        <InstitutionRow key={i} {...institution} {...props.actions} />
    ));
    return (
        <table className="table table-hover mb-0 hidden-sm-down">
            <thead>
                <tr>
                    <th className="col-md-2">Id</th>
                    <th className="col-md-4">Name</th>
                    <th className="col-md-3">Country</th>
                    <th className="col-md-3 text-center">Actions</th>
                </tr>
            </thead>
            <tbody>{institutionRows}</tbody>
        </table>
    );
};

InstitutionsTable.defaultProps = {
    institutions: []
};

InstitutionsTable.propTypes = {
    institutions: PropTypes.array
};

export default InstitutionsTable;
