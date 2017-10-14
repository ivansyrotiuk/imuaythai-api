import React from "react";
import DetailedVersus from "./DetailedVersus";
import FighterVersusBox from "./FighterVersusBox";

export const FightersBox = props => {
    const { fight } = props;
    return (
        <div className="row">
            <div className="col-md-5">{<FighterVersusBox fighter={fight.redAthlete} corner="red" />}</div>
            <div className="col-md-2 text-center align-self-center">
                <DetailedVersus />
            </div>
            <div className="col-md-5">{<FighterVersusBox fighter={fight.blueAthlete} corner="blue" />}</div>
        </div>
    );
};

export default FightersBox;
