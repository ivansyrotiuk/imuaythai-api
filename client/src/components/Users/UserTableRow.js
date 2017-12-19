import React from 'react';
import Avatar from 'react-avatar';
import RemoveButton from '../../views/Components/Buttons/RemoveButton';
import EditButton from '../../views/Components/Buttons/EditButton';
import PreviewButton from '../../views/Components/Buttons/PreviewButton';
import { Link } from 'react-router-dom';

const TableUserRow = props => {
    const { user } = props;
    const fullName = user.firstname + ' ' + user.surname;

    return (
        <tr>
            <td>
                <Avatar size={40} name={fullName} src={user.photo} round={true} />
            </td>
            <td>{fullName}</td>
            <td>{user.countryName}</td>
            <td>
                <div className="row justify-content-around">
                    <Link to={'/users/' + user.id}>
                        <PreviewButton id={user.id} />
                    </Link>
                    <Link to={'/users/' + user.id + '/edit'}>
                        <EditButton id={user.id} />
                    </Link>
                    {props.deleteUser && <RemoveButton id={user.id} click={() => props.deleteUser(user.id)} />}
                </div>
            </td>
        </tr>
    );
};

export default TableUserRow;
