import React from "react";
import JudgeCell from "../PointsGrid/JudgeCell";
import WarningsCell from "./WarningsCell";

export const WarningsRow = props => {
    const { points } = props;
    const mappedPoints = points.rounds.map((roundPoints, key) => <WarningsCell key={key} points={roundPoints} />);
    return (
        <tr>
            <JudgeCell>{points.judgeName}</JudgeCell>
            {mappedPoints}
        </tr>
    );
};

export default WarningsRow;
