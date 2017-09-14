import React, { Component } from 'react'
import moment from 'moment'
import Page from '../Components/Page'
import AddButton from '../Components/Buttons/AddButton'
import EditButton from '../Components/Buttons/EditButton'
import ContestInfoCard from './ContestInfoCard'
import AcceptedContestRequests from './AcceptedContestRequests'
import ContestRequestForm from './ContestRequestForm'
import { Route, Link, NavLink } from 'react-router-dom';

class ContestViewPage extends Component {
  render() {
    const {contest, pendingRequests, doctorsRequests, judgesRequests, fightersRequests, addRequestsClick, editContest, pendingRequestsClick, contestCategoriesClick, manageJudgesClick, contestFightsClick} = this.props;
    if (!contest) {
      return <div></div>
    }


    return <div className="animated fadeIn">
             <div className="row">
               <div className="col-12">
                 <ContestInfoCard contest={ contest } editContest={ editContest } addRequestsClick={ addRequestsClick } pendingRequestsClick={ pendingRequestsClick } contestCategoriesClick={ contestCategoriesClick }
                   manageJudgesClick={ manageJudgesClick } contestFightsClick={ contestFightsClick } fightersCount={ fightersRequests.length } judgesCount={ judgesRequests.length } doctorsCount={ doctorsRequests.length }
                   pendingCount={ pendingRequests.length } />
               </div>
             </div>
             <div className="row">
               <div className="col-12">
                 <div className="card">
                   <div className="card-header">
                     <strong>Requests</strong>
                   </div>
                   <div className="card-block">
                     <AcceptedContestRequests fightersRequests={ fightersRequests } judgesRequests={ judgesRequests } doctorsRequests={ doctorsRequests } />
                   </div>
                 </div>
               </div>
             </div>
           </div>
  }
}

export default ContestViewPage