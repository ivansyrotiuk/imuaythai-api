import React from 'react'
import RedFighter from './RedFighter'
import BlueFighter from './BlueFighter'
import Versus from './Versus'
import { DropTarget } from 'react-dnd';
import { collect, fighterTarget } from './FighterDragTarget'
import dragTypes from './dragTypes'

export const RedFighterDropTargetDecorator = (props) => {
    const {isOver, canDrop, connectDropTarget} = props;

    return connectDropTarget(
        <div>
          <RedFighter fight={ props.fight } fighter={ props.fight.redAthlete } number={ props.number } />
        </div>
    )
}

export default DropTarget(dragTypes.FIGHTER, fighterTarget, collect)(RedFighterDropTargetDecorator);