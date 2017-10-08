import React from "react";
import RedFighter from "../List/RedFighter";
import BlueFighter from "../List/BlueFighter";
import { DropTarget } from "react-dnd";
import { dropTargetCollect, fighterTarget } from "./FighterDragTarget";
import { collectDragSource, fighterSource } from "./FighterDragSource";
import dragTypes from "../../../common/dragTypes";
import { DragSource } from "react-dnd";

let RedFighterDropTargetDecorator = props => {
    const { isOver, canDrop, connectDropTarget, connectDragSource } = props;

    return connectDropTarget(
        connectDragSource(
            <div>
                <RedFighter fight={props.fight} fighter={props.fight.redAthlete} number={props.number} />
            </div>
        )
    );
};

RedFighterDropTargetDecorator = DragSource(dragTypes.FIGHTER, fighterSource, collectDragSource)(RedFighterDropTargetDecorator);

RedFighterDropTargetDecorator = DropTarget(dragTypes.FIGHTER, fighterTarget, dropTargetCollect)(RedFighterDropTargetDecorator);

export default RedFighterDropTargetDecorator;
