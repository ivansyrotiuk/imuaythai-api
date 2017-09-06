import React from 'react'
import UserAvatar from 'react-user-avatar'
import { DragSource } from 'react-dnd';
import { collect, fighterSource } from './FighterDragSource'
import dragTypes from '../../common/dragTypes'

export const BlueFighter = (props) => {
  const {fighter, number} = props;

  const {isDragging, connectDragSource} = props;


  return connectDragSource(

    <div className="row ">
      <div className="col-md-2 align-self-center">
        <div className="row justify-content-end">
          <UserAvatar size="50" name={ fighter.firstname + ' ' + fighter.surname } />
        </div>
      </div>
      <div className="col-md-8">
        <div>
          { fighter.id == undefined && <h4 className="card-title">The winner of previous fight</h4> }
          { fighter.id && <h4 className="card-title">{ fighter.firstname + ' ' + fighter.surname }</h4> }
          { fighter.id && <h6 className="card-subtitle mb-2 text-muted">{ fighter.gymName || 'No gym' }, { fighter.countryName }</h6> }
          <p className="card-text">
            <i className="fa fa-envelope" aria-hidden="true"></i>
            { ' ' + fighter.email }
          </p>
        </div>
      </div>
      <div className="col-md-2">
        <div className="bg-primary" style={ { color: 'white', width: '100%', height: '100%' } }>
          <h2 className="text-center">{ number }</h2>
          <p className="text-center">Blue corner</p>
        </div>
      </div>
    </div>
  )
}

export default DragSource(dragTypes.FIGHTER, fighterSource, collect)(BlueFighter);