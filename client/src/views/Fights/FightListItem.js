import React from 'react'
import Versus from './Versus'
import RedFighterDropTargetDecorator from './RedFighterDropTargetDecorator'
import BlueFighterDropTargetDecorator from './BlueFighterDropTargetDecorator'

const FightListItem = (props) => {

  return <div className="card">
           <div className="card-body">
             <div className="row">
               <div className="col-md-5">
                 <RedFighterDropTargetDecorator fight={ props.fight } fighter={ props.fight.redAthlete } number={ props.number } />
               </div>
               <div className="col-md-2 align-self-center ">
                 <Versus/>
               </div>
               <div className="col-md-5">
                 <BlueFighterDropTargetDecorator fight={ props.fight } fighter={ props.fight.blueAthlete } number={ props.number } />
               </div>
             </div>
           </div>
         </div>
}

export default FightListItem