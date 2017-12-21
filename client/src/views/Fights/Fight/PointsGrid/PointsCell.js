import React from 'react';
import Row from '../../../../components/Layout/Row';

export const PointCell = props => {
    const red = props.points.redFighterPoints;
    const blue = props.points.blueFighterPoints;
    const redPoints = red !== undefined ? red.fighterPoints : '-';
    const bluePoints = blue !== undefined ? blue.fighterPoints : '-';

    const redAccepted = red && red.accepted ? 'text-primary' : 'text-muted';
    const blueAccepted = blue && blue.accepted ? 'text-primary' : 'text-muted';
    return (
        <Row className="justify-content-center">
            <div className={redAccepted}>{redPoints}</div>
            /
            <div className={blueAccepted}>{bluePoints}</div>
        </Row>
    );
};

export default PointCell;
