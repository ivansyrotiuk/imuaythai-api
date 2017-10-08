import React from "react";

export const PointCell = props => {
    const red = props.points.redFighterPoints;
    const blue = props.points.blueFighterPoints;
    const redPoints = red !== null ? red.fighterPoints : "-";
    const bluePoints = blue !== null ? blue.fighterPoints : "-";

    return (
        <td>
            {redPoints}/{bluePoints}
        </td>
    );
};

export default PointCell;
