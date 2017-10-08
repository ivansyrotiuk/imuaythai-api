import moment from "moment";
import React from "react";
import Versus from "./Versus";
import RedFighterDropTargetDecorator from "../dnd/RedFighterDropTargetDecorator";
import BlueFighterDropTargetDecorator from "../dnd/BlueFighterDropTargetDecorator";

const FighterMoveListItem = props => {
    return (
        <div className="card">
            <div className="card-body">
                <div className="row">
                    <div className="col-md-5">
                        <RedFighterDropTargetDecorator fight={props.fight} fighter={props.fight.redAthlete} number={props.number} />
                    </div>
                    <div className="col-md-2 align-self-center text-center">
                        <Versus /> Apr. start time:
                        {" " + moment(props.fight.startDate).format("YYYY-MM-DD HH:mm")} Ring: <strong>{" " + props.fight.ring}</strong>
                        <i className="fa fa-external-link btn btn-link" aria-hidden="true" onClick={props.openFight} />
                    </div>
                    <div className="col-md-5">
                        <BlueFighterDropTargetDecorator fight={props.fight} fighter={props.fight.blueAthlete} number={props.number} />
                    </div>
                </div>
            </div>
        </div>
    );
};

export default FighterMoveListItem;
