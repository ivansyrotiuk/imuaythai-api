import React from "react";
import WarningsRow from "./WarningsRow";
import WarningsGridHeader from "./WarningsGridHeader";

export const WarningsGrid = props => {
    const { points, roundsCount } = props;
    const mappedWarnings = points.map((judgePoints, key) => <WarningsRow key={key} points={judgePoints} />);
    return (
        <table className="table table-hover mb-0 hidden-sm-down table-bordered">
            <thead>
                <WarningsGridHeader rounds={roundsCount} />
            </thead>
            <tbody>{mappedWarnings}</tbody>
        </table>
    );
};

export default WarningsGrid;
