import React from 'react';
import classnames from 'classnames';

export const CautionsCell = props => {
    const red = props.points.redFighterPoints;
    const blue = props.points.blueFighterPoints;

    const redCautions = red !== null ? red.cautions : '-';
    const blueCautions = blue !== null ? blue.cautions : '-';

    const accepted = red && red.accepted ? 'text-primary' : 'text-muted';
    const cellClasses = classnames('text-center', accepted);

    return (
        <div className={cellClasses}>
            {redCautions}/{blueCautions}
        </div>
    );
};

export default CautionsCell;
