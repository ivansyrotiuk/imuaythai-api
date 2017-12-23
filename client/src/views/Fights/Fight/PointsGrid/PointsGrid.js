import React from 'react';
import ReactTable from 'react-table';
import 'react-table/react-table.css';
import PointsCell, { PointCell } from './PointsCell';

export const PointsGrid = props => {
    const { roundsCount } = props;

    const roundsColumns = Array(roundsCount)
        .fill()
        .map((e, index) => {
            return {
                Header: 'Round ' + index + 1,
                id: 'round',
                accessor: d => d.rounds[index],
                Cell: row => <PointCell points={row.value} />
            };
        });

    const columns = [
        {
            Header: 'Judge',
            accessor: 'judgeName'
        },
        ...roundsColumns
    ];

    return <ReactTable data={props.points} columns={columns} defaultPageSize={5} className="-striped -highlight" />;
};

export default PointsGrid;
