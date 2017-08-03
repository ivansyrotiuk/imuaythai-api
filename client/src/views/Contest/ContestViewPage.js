import React, { Component } from 'react'
import moment from 'moment'
import Page from '../Components/Page'
import AddButton from '../Components/Buttons/AddButton'
import EditButton from '../Components/Buttons/EditButton'
import ContestInfoCard from './ContestInfoCard'
import ContestRequests from './ContestRequests'
import ContestRequestForm from './ContestRequestForm'
import { Route, Link } from 'react-router-dom';

class ContestViewPage extends Component {
  render() {
    const {contest, requests, roles, candidates, singleRequest, saveRequest, addRequest, editContest, cancelRequest, showRequestForm, acceptContestRequest, rejectContestRequest, removeContestRequest} = this.props;
    if (!contest) {
      return <div></div>
    }

    return <div className="animated fadeIn">
             <div className="row">
               <div className="col-12">
                 <ContestInfoCard contest={ contest } editContest={ editContest } />
               </div>
             </div>
             <div className="row">
               <div className="col-12">
                 <div className="card">
                   <div className="card-header">
                     <strong>Requests</strong>
                     { !showRequestForm && <div className="pull-right">
                                             <AddButton click={ addRequest } />
                                           </div> }
                   </div>
                   <div className="card-block">
                     { !showRequestForm && <ContestRequests contest={ contest } requests={ requests } acceptContestRequest={ acceptContestRequest } rejectContestRequest={ rejectContestRequest } removeContestRequest={ removeContestRequest }
                                           /> }
                     { !showRequestForm && <div className="btn btn-primary pull-right" onClick={ addRequest }><i className="fa fa-plus fa-1x" aria-hidden="true"> </i> Add</div> }
                     { showRequestForm && <ContestRequestForm onSubmit={ saveRequest } initialValues={ singleRequest } roles={ roles } candidates={ candidates } categories={ contest.contestCategories }
                                            onCancel={ cancelRequest } /> }
                   </div>
                 </div>
               </div>
             </div>
           </div>


  }
}

export default ContestViewPage