import React from 'react';
import ReactTable from 'react-table';
import 'react-table/react-table.css';
import ActionButtonGroup from '../../../views/Components/Buttons/ActionButtonGroup';

const InstitutionsTable = props => {
    const { previewClick, editClick, deleteClick } = props.actions;
    return (
        <ReactTable
            data={props.institutions}
            columns={[
                {
                    Header: 'id',
                    accessor: 'id'
                },
                {
                    Header: 'Name',
                    accessor: 'name'
                },
                {
                    Header: 'Country',
                    accessor: 'countryName'
                },
                {
                    Header: 'Actions',
                    accessor: 'id',
                    Cell: row => (
                        <ActionButtonGroup
                            previewClick={() => previewClick(row.value)}
                            editClick={() => editClick(row.value)}
                            deleteClick={() => deleteClick(row.value)}
                        />
                    )
                }
            ]}
            defaultPageSize={10}
            className="-striped -highlight"
        />
    );
};

InstitutionsTable.defaultProps = {
    institutions: []
};

export default InstitutionsTable;
