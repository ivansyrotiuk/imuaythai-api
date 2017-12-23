import React from 'react';
import classnames from 'classnames';

export const InjuryCell = props => {
    const red = props.points.redFighterPoints;
    const blue = props.points.blueFighterPoints;

    const redJ = red !== null ? red.j : '-';
    const blueJ = blue !== null ? blue.j : '-';

    const accepted = red && red.accepted ? 'text-primary' : 'text-muted';
    const cellClasses = classnames('text-center', accepted);
    return (
        <div className={cellClasses}>
            {redJ}/{blueJ}
        </div>
    );
};

export default InjuryCell;
