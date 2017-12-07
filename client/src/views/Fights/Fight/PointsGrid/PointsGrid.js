import React from "react";
import PointsGridHeader from "./PointsGridHeader";
import PointsRow from "./PointsRow";

export const PointsGrid = props => {
    const { points, roundsCount } = props;
    const mappedPoints = points.map((judgePoints, key) => <PointsRow key={key} points={judgePoints} />);
    return (
        <table className="table table-hover mb-0 hidden-sm-down table-bordered">
            <thead>
                <PointsGridHeader rounds={roundsCount} />
            </thead>
            <tbody>{mappedPoints}</tbody>
        </table>
    );
};

export default PointsGrid;
