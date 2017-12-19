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
                    <th>Id</th>
                    <th>Name</th>
                    <th>Country</th>
                    <th className="text-center">Actions</th>
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
