import React from "react";
import WarningsJudgeColumn from "./WarningsJudgeColumn";
import WarningsRoundColumn from "./WarningsRoundColumn";

export const WarningsGridHeader = props => {
    const roundsColumns = Array(props.rounds)
        .fill()
        .map((e, i) => i + 1)
        .map((e, key) => <WarningsRoundColumn key={key} roundNumber={e} />);

    return (
        <tr>
            <WarningsJudgeColumn />
            {roundsColumns}
        </tr>
    );
};

export default WarningsGridHeader;
