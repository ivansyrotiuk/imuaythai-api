import React from "react";
import Row from "../../../../components/Layout/Row";

export const PointCell = props => {
    const red = props.points.redFighterPoints;
    const blue = props.points.blueFighterPoints;
    const redPoints = red !== null ? red.fighterPoints : "-";
    const bluePoints = blue !== null ? blue.fighterPoints : "-";

    const redAccepted = (red && red.accepted) ? 'text-primary' : 'text-muted';
    const blueAccepted = (blue && blue.accepted) ? 'text-primary' : 'text-muted';
    return (
        <td>
            <Row className="justify-content-center">
                <div className={redAccepted}>
                    {redPoints}
                </div>
                /
                <div className={blueAccepted}>
                    {bluePoints}
                </div>
            </Row>
        </td>
    );
};

export default PointCell;
