import React from 'react';
import UserTableRow from './UserTableRow';

const UserTable = props => {
    const mappedUsers =
        props.users && props.users.map((user, i) => <UserTableRow key={i} user={user} deleteUser={props.deleteUser} />);

    return (
        <table className="table table-hover mb-0 hidden-sm-down">
            <thead>
                <tr>
                    <th />
                    <th>Name</th>
                    <th>Country</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>{mappedUsers}</tbody>
        </table>
    );
};

export default UserTable;
