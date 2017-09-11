import React, { Component } from 'react'
import EditButton from '../Components/Buttons/EditButton'
import moment from 'moment'
import { userCanAcceptContestRequest, userCanAddContestRequest } from '../../auth/auth'

export default class ContestInfoCard extends Component {
  render() {
    const {contest, editContest, pendingRequestsClick, addRequestsClick, contestCategoriesClick, manageJudgesClick, fightersCount, judgesCount, doctorsCount, pendingCount} = this.props;

    const PendingRequestsButton = userCanAcceptContestRequest(() => <div className="col-sm-2">
                                                                      <div className="btn btn-warning btn-block" onClick={ pendingRequestsClick }>
                                                                        <div>Pending requests</div>
                                                                      </div>
                                                                    </div>)

    const ContestCategoriesButton = userCanAcceptContestRequest(() => <div className="col-sm-2">
                                                                        <div className="btn btn-success btn-block" onClick={ contestCategoriesClick }>
                                                                          <div>Categories</div>
                                                                        </div>
                                                                      </div>)

    const JudgesManageButton = userCanAcceptContestRequest(() => <div className="col-sm-2">
                                                                   <div className="btn btn-success btn-block" onClick={ manageJudgesClick }>
                                                                     <div>Manage judges</div>
                                                                   </div>
                                                                 </div>)

    const AddRequestsButton = userCanAddContestRequest(() => <div className="col-sm-2">
                                                               <div className="btn btn-primary btn-block" onClick={ addRequestsClick }>
                                                                 <div>Add request</div>
                                                               </div>
                                                             </div>)
    return (
      <div className="card">
        <div className="card-header">
          <strong>Contest</strong>
          <div className="pull-right">
            <EditButton click={ editContest } />
          </div>
        </div>
        <div className="card-block">
          <div className="row">
            <div className="col-md-3">
              <img src="/img/contest_poster.jpg" className="img-thumbnail" />
            </div>
            <div className="col-md-9">
              <div className="row">
                <p className="h1">
                  { contest.name }
                </p>
              </div>
              <div className="row form-group">
                <h3>{ contest.country && contest.country.name }, { moment(contest.date).format('YYYY.DD.MM') } - { moment(contest.date).add('days', contest.duration).format('YYYY.DD.MM') }</h3>
              </div>
              <div className="row">
                <h6>{ contest.city }, { contest.address }</h6>
              </div>
              <div className="row">
                <h6>Organizator: { contest.institution && contest.institution.name }</h6>
              </div>
              <div className="row form-group">
                <h6>Website: <a href={ contest.website } target="_blank">{ contest.website }</a></h6>
              </div>
              <div className="row form-group">
                { contest.facebook && <a href={ contest.facebook } target="_blank">
                                        <button type="button" className="btn  btn-facebook">
                                          <span>Facebook</span>
                                        </button> </a> }
                { contest.twitter && <a href={ contest.twitter } target="_blank">
                                       <button type="button" className="btn  btn-twitter">
                                         <span>Twitter</span>
                                       </button> </a> }
                { contest.instagram && <a href={ contest.instagram } target="_blank">
                                         <button type="button" className="btn btn-instagram">
                                           <span>Instagram</span>
                                         </button> </a> }
                { contest.vk && <a href={ contest.vk } target="_blank">
                                  <button type="button" className="btn  btn-vk">
                                    <span>VK</span>
                                  </button>
                                </a> }
              </div>
              <div className="row">
                <div className="h6">Registration statistic</div>
              </div>
              <div className="row">
                <div className="col-sm-3">
                  <div className="callout callout-warning">
                    <small className="text-muted">Pending requests</small>
                    <br/>
                    <strong className="h4">{ pendingCount }</strong>
                  </div>
                </div>
                <div className="col-sm-3">
                  <div className="callout callout-info">
                    <small className="text-muted">Fighters</small>
                    <br/>
                    <strong className="h4">{ fightersCount }</strong>
                  </div>
                </div>
                <div className="col-sm-3">
                  <div className="callout callout-success">
                    <small className="text-muted">Judges</small>
                    <br/>
                    <strong className="h4">{ judgesCount }</strong>
                  </div>
                </div>
                <div className="col-sm-3">
                  <div className="callout callout-danger">
                    <small className="text-muted">Doctors</small>
                    <br/>
                    <strong className="h4">{ doctorsCount }</strong>
                  </div>
                </div>
              </div>
              <div className="row">
                <ContestCategoriesButton/>
                <JudgesManageButton/>
                <PendingRequestsButton/>
                <AddRequestsButton />
              </div>
            </div>
          </div>
        </div>
      </div>
    )
  }
}