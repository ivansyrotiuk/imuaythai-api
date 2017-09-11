import React from 'react'
import BlueFighter from './BlueFighter'
import { DropTarget } from 'react-dnd';
import { collect, fighterTarget } from './FighterDragTarget'
import dragTypes from './dragTypes'

export const BlueFighterDropTargetDecorator = (props) => {
    const {isOver, canDrop, connectDropTarget} = props;

    return connectDropTarget(
        <div>
          <BlueFighter fight={ props.fight } fighter={ props.fight.blueAthlete } number={ props.number } />
        </div>
    )
}

export default DropTarget(dragTypes.FIGHTER, fighterTarget, collect)(BlueFighterDropTargetDecorator);