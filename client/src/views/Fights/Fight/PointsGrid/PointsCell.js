import React from "react";

export const PointCell = props => {
    const red = props.points.redFighterPoints;
    const blue = props.points.blueFighterPoints;
    const redPoints = red !== null ? red.fighterPoints : "-";
    const bluePoints = blue !== null ? blue.fighterPoints : "-";

    const redAccepted = (red && red.accepted) ? 'text-primary' : 'text-muted';
    const blueAccepted = (blue && blue.accepted) ? 'text-primary' : 'text-muted';
    return (
        <td>
            <div className="row">
                <div className={redAccepted}>
                    {redPoints}
                </div>
                /
                <div className={blueAccepted}>
                    {bluePoints}
                </div>
            </div>
        </td>
    );
};

export default PointCell;
