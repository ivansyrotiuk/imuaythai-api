import React from "react";
import RedFighter from "../List/RedFighter";
import BlueFighter from "../List/BlueFighter";
import { DropTarget } from "react-dnd";
import { dropTargetCollect, fighterTarget } from "./FighterDragTarget";
import { collectDragSource, fighterSource } from "./FighterDragSource";
import dragTypes from "../../../common/dragTypes";
import { DragSource } from "react-dnd";

let BlueFighterDropTargetDecorator = props => {
    const { isOver, canDrop, connectDropTarget, connectDragSource } = props;

    return connectDropTarget(
        connectDragSource(
            <div>
                <BlueFighter fight={props.fight} fighter={props.fight.blueAthlete} number={props.number} />
            </div>
        )
    );
};

BlueFighterDropTargetDecorator = DragSource(dragTypes.FIGHTER, fighterSource, collectDragSource)(BlueFighterDropTargetDecorator);

BlueFighterDropTargetDecorator = DropTarget(dragTypes.FIGHTER, fighterTarget, dropTargetCollect)(BlueFighterDropTargetDecorator);

export default BlueFighterDropTargetDecorator;
