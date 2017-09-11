import moment from 'moment'
import React from 'react'
import ExtendedVersus from './ExtendedVersus'
import BlueFighterOverview from './BlueFighterOverview'
import RedFighterOverview from './RedFighterOverview'

const FightOverview = (props) => {

  return <div className="card">
           <div className="card-body">
             <div className="row">
               <div className="col-md-5">
                 { <RedFighterOverview fighter={ props.fight.redAthlete } /> }
               </div>
               <div className="col-md-2 text-center align-self-center">
                 <ExtendedVersus/>
               </div>
               <div className="col-md-5">
                 { <BlueFighterOverview fighter={ props.fight.blueAthlete } /> }
               </div>
             </div>
           </div>
         </div>
}

export default FightOverview