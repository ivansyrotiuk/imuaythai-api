import React from 'react';
import PropTypes from 'prop-types';
import ActionButtonGroup from '../../../views/Components/Buttons/ActionButtonGroup';

const InstitutionRow = props => {
    const { previewClick, editClick, deleteClick } = props;

    return (
        <tr>
            <td>{props.id}</td>
            <td>{props.name}</td>
            <td>{props.country && props.country.name}</td>
            <td>
                <ActionButtonGroup
                    previewClick={() => previewClick(props.id)}
                    editClick={() => editClick(props.id)}
                    deleteClick={() => deleteClick(props.id)}
                />
            </td>
        </tr>
    );
};

InstitutionRow.defaultProps = {
    id: 0,
    name: 'no name',
    country: {}
};

InstitutionRow.propTypes = {
    id: PropTypes.number,
    name: PropTypes.string,
    country: PropTypes.object,
    previewClick: PropTypes.func,
    editClick: PropTypes.func,
    deleteClick: PropTypes.func
};

export default InstitutionRow;
