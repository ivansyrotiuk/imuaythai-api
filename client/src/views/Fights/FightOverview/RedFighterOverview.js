import React from 'react'
import UserAvatar from 'react-user-avatar'
import moment from 'moment'
export const RedFighterOverview = (props) => {
  const {fighter} = props;



  return (
    <div className="row ">
      <div className="col-md-3">
        <div className="bg-danger" style={ { color: 'white', width: '100%', height: '100%' } }>
          { /* <UserAvatar size="75" name={ fighter.firstname + ' ' + fighter.surname } /> */ }
        </div>
      </div>
      <div className="col-md-9 text-right align-self-center">
        { fighter.id == undefined && <h1 className="card-title">The winner of previous fight</h1> }
        { fighter.id && <h1 className="card-title">{ fighter.firstname + ' ' + fighter.surname }</h1> }
        { fighter.id && <h6 className="card-subtitle mb-2 text-muted">{ fighter.gymName || 'No gym' }, { fighter.countryName }</h6> }
        { fighter.id && <h4 className="card-title">{ moment(fighter.birthdate).format('YYYY-MM-DD') }</h4> }
        { fighter.id && <h4 className="card-title">{ fighter.won }</h4> }
        { fighter.id && <h4 className="card-title">{ fighter.lost }</h4> }
        { fighter.khanLevel.name == null && <h4 className="card-title"> '' </h4> }
        { fighter.khanLevel !== null && <h4 className="card-title">{ fighter.khanLevel.name }</h4> }
      </div>
    </div>)
}

export default RedFighterOverview;