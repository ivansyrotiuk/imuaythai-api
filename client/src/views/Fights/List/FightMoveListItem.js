import moment from "moment";
import React from "react";
import Versus from "./Versus";
import RedFighter from "./RedFighter";
import BlueFighter from "./BlueFighter";
import { DropTarget, DragSource } from "react-dnd";
import { collect, fighterTarget } from "../dnd/FighterDragTarget";
import dragTypes from "../../../common/dragTypes";
import { findDOMNode } from "react-dom";

const listItemSource = {
    beginDrag(props) {
        return {
            ...props,
            index: props.number - 1
        };
    }
};

const listItemTarget = {
    canDrop(props, monitor) {
        const sourceItem = monitor.getItem();
        const targetItem = props;
        return sourceItem.fight.ring === targetItem.fight.ring;
    },

    hover(props, monitor, component) {
        const sourceItem = monitor.getItem();
        const targetItem = props;

        const dragIndex = sourceItem.index;
        const hoverIndex = targetItem.number - 1;

        if (sourceItem.fight.ring != targetItem.fight.ring) {
            return;
        }

        // Don't replace items with themselves
        if (dragIndex === hoverIndex) {
            return;
        }

        // Determine rectangle on screen
        const hoverBoundingRect = findDOMNode(component).getBoundingClientRect();

        // Get vertical middle
        const hoverMiddleY = (hoverBoundingRect.bottom - hoverBoundingRect.top) / 2;

        // Determine mouse position
        const clientOffset = monitor.getClientOffset();

        // Get pixels to the top
        const hoverClientY = clientOffset.y - hoverBoundingRect.top;

        // Only perform the move when the mouse has crossed half of the items height
        // When dragging downwards, only move when the cursor is below 50%
        // When dragging upwards, only move when the cursor is above 50%

        // Dragging downwards
        if (dragIndex < hoverIndex && hoverClientY < hoverMiddleY) {
            return;
        }

        // Dragging upwards
        if (dragIndex > hoverIndex && hoverClientY > hoverMiddleY) {
            return;
        }

        // Time to actually perform the action
        const fightDragging = {
            sourceFightId: sourceItem.fight.id,
            targetFightId: targetItem.fight.id
        };

        props.dragFight(fightDragging);
        // Note: we're mutating the monitor item here!
        // Generally it's better to avoid mutations,
        // but it's good here for the sake of performance
        // to avoid expensive index searches.
        sourceItem.index = hoverIndex;
        sourceItem.target = targetItem;
    },

    drop(props, monitor, component) {
        if (monitor.didDrop()) {
            // If you want, you can check whether some nested
            // target already handled drop
            return;
        }

        const draggedItem = monitor.getItem();
        const targetItem = draggedItem.target;
        if (targetItem == undefined) {
            return;
        }

        // Obtain the dragged item
        const item = monitor.getItem();

        const movingParams = {
            sourceFightId: draggedItem.fight.id,
            targetFightId: targetItem.fight.id
        };

        targetItem.moveFight(movingParams);

        return {
            moved: true
        };
    }
};

const FightMoveListItem = props => {
    const { connectDragSource, connectDropTarget, isOver, canDrop, openFight } = props;
    const style = { opacity: isOver && canDrop ? 0 : 1 };

    return connectDragSource(
        connectDropTarget(
            <div className="card" style={style}>
                <div className="card-body">
                    <div className="row">
                        <div className="col-md-5">
                            <RedFighter fight={props.fight} fighter={props.fight.redAthlete} number={props.number} />
                        </div>
                        <div className="col-md-2 align-self-center text-center">
                            <Versus /> Apr. start time:
                            {" " + moment(props.fight.startDate).format("YYYY-MM-DD HH:mm")} Ring: <strong>{" " + props.fight.ring}</strong>
                            <i className="fa fa-external-link btn btn-link" aria-hidden="true" onClick={openFight} />
                        </div>
                        <div className="col-md-5">
                            <BlueFighter fight={props.fight} fighter={props.fight.blueAthlete} number={props.number} />
                        </div>
                    </div>
                </div>
            </div>
        )
    );
};

const dropTargetCollect = (connect, monitor) => ({
    connectDropTarget: connect.dropTarget(),
    isOver: monitor.isOver(),
    canDrop: monitor.canDrop()
});

const dragSourceCollect = (connect, monitor) => {
    return {
        connectDragSource: connect.dragSource(),
        isDragging: monitor.isDragging()
    };
};

export default DropTarget(dragTypes.FIGHT, listItemTarget, dropTargetCollect)(DragSource(dragTypes.FIGHT, listItemSource, dragSourceCollect)(FightMoveListItem));
