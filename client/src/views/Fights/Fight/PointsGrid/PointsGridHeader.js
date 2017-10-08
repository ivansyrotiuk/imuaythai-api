import React from "react";
import JudgeColumn from "./JudgeColumn";
import RoundColumn from "./RoundColumn";

export const PointsGridHeader = props => {
    const roundsColumns = Array(props.rounds)
        .fill()
        .map((e, i) => i + 1)
        .map((e, key) => <RoundColumn key={key} roundNumber={e} />);

    return (
        <tr>
            <JudgeColumn />
            {roundsColumns}
        </tr>
    );
};

export default PointsGridHeader;
