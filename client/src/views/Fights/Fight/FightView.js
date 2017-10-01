import moment from "moment";
import React from "react";
import DetailedVersus from "./DetailedVersus";
import FighterBox from "./FighterBox";
import CornerBox from "./CornerBox";

const FightView = props => {
    return (
        <div className="card">
            <div className="card-body">
                <div className="row">
                    <div className="col-md-5">{<FighterBox fighter={props.fight.redAthlete} corner="red" />}</div>
                    <div className="col-md-2 text-center align-self-center">
                        <DetailedVersus />
                    </div>
                    <div className="col-md-5">{<FighterBox fighter={props.fight.blueAthlete} corner="blue" />}</div>
                </div>
            </div>
        </div>
    );
};

export default FightView;
