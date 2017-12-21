import React from 'react';
import classnames from 'classnames';

export const KnockdownsCell = props => {
    const red = props.points.redFighterPoints;
    const blue = props.points.blueFighterPoints;

    const redKnockDown = red !== null ? red.knockDown : '-';
    const blueKnockDown = blue !== null ? blue.knockDown : '-';

    const accepted = red && red.accepted ? 'text-primary' : 'text-muted';
    const cellClasses = classnames('text-center', accepted);

    return (
        <div className={cellClasses}>
            {redKnockDown}/{blueKnockDown}
        </div>
    );
};

export default KnockdownsCell;
