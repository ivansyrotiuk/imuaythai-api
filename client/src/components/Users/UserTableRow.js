import React from 'react';
import Avatar from 'react-avatar'
import RemoveButton from "../../views/Components/Buttons/RemoveButton"
import EditButton from "../../views/Components/Buttons/EditButton"
import PreviewButton from "../../views/Components/Buttons/PreviewButton"
import {Link} from "react-router-dom";

const TableUserRow = (props) => {
        const { user} = props;
        const fullName = user.firstname + ' ' + user.surname;

        return (
            <tr>
                <td className="col-md-1">
                    <Avatar size="40" name={ fullName } src={user.photo} round={true}/>
                </td>
                <td className="col-md-7">
                    { fullName }
                </td>
                <td className="col-md-2">
                    { user.countryName }
                </td>
                <td className="col-md-2">
                    <div className="row justify-content-between">
                        <Link to={ "/users/" + user.id }>
                            <PreviewButton id={ user.id } />
                        </Link>
                        <Link to={ "/users/" + user.id + "/edit" }>
                            <EditButton id={ user.id } />
                        </Link>
                        {props.deleteUser && <RemoveButton id={ user.id } click={ () => props.deleteUser(user.id)} />}
                    </div>
                </td>
            </tr>
        );
};

export default TableUserRow;
