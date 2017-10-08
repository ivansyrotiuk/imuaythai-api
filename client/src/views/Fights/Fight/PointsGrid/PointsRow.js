import React from "react";
import JudgeCell from "./JudgeCell";
import PointsCell from "./PointsCell";

export const PointRow = props => {
    const { points } = props;
    const mappedPoints = points.rounds.map((roundPoints, key) => <PointsCell key={key} points={roundPoints} />);
    return (
        <tr>
            <JudgeCell>{points.judgeName}</JudgeCell>
            {mappedPoints}
        </tr>
    );
};

export default PointRow;
