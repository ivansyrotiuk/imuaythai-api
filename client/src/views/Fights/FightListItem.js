import React from 'react'
import RedFighter from './RedFighter'
import BlueFighter from './BlueFighter'
import Versus from './Versus'
import { DropTarget } from 'react-dnd';
import { collect, fighterTarget } from './FighterDragTarget'
import dragTypes from './dragTypes'

export const FightListItem = (props) => {
  const {isOver, canDrop, connectDropTarget} = props;

  return connectDropTarget(
    <div className="card">
      <div className="card-body">
        <div className="row">
          <div className="col-md-5">
            <RedFighter fighter={ props.fight.redAthlete } number={ props.number } />
          </div>
          <div className="col-md-2 align-self-center ">
            <Versus/>
          </div>
          <div className="col-md-5">
            <BlueFighter fighter={ props.fight.blueAthlete } number={ props.number } />
          </div>
        </div>
      </div>
    </div>
  )
}

export default DropTarget(dragTypes.FIGHTER, fighterTarget, collect)(FightListItem);