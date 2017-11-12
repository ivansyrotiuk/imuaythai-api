import React, { Component } from 'react'
import { TabContent, TabPane, Nav, NavItem, NavLink } from 'reactstrap';
import { Route, Link } from 'react-router-dom';
import classnames from 'classnames';
import moment from 'moment'
import Page from '../Components/Page'
import EditButton from '../Components/Buttons/EditButton'
import AcceptButton from '../Components/Buttons/AcceptButton'
import RejectButton from '../Components/Buttons/RejectButton'
import RemoveButton from '../Components/Buttons/RemoveButton'
import ContestInfoCard from './ContestInfoCard'
import { CONTEST_FIGHTER, CONTEST_JUDGE, CONTEST_DOCTOR } from '../../common/contestRoleTypes'
import { CONTEST_REQUEST_PENDING, CONTEST_REQUEST_ACCEPTED, CONTEST_REQUEST_REJECTED } from '../../common/contestRequestStatuses'

class ContestInstitutionRequests extends Component {
  constructor(props) {
    super(props);

    this.toggle = this.toggle.bind(this);
    this.mapRequest = this.mapRequest.bind(this);
    this.state = {
      activeTab: '1'
    };
  }

  toggle(tab) {
    if (this.state.activeTab !== tab) {
      this.setState({
        activeTab: tab
      });
    }
  }

  mapRequest(request, i) {
    const {removeContestRequest} = this.props;

    return <tr key={ i }>
             <td className="col-2">
               { request.userName }
             </td>
             <td className="col-2">
               { request.institutionName }
             </td>
             <td className="col-1">
               { request.user && request.user.city }
             </td>
             <td className="col-2">
               { request.user && request.user.countryName }
             </td>
             { request.contestCategoryId && <td>
                                              { request.contestCategoryName }
                                            </td> }
             <td>
               { request.status === CONTEST_REQUEST_PENDING && <span className="badge badge-warning">Pending</span> }
               { request.status === CONTEST_REQUEST_ACCEPTED && <span className="badge badge-success">Accepted</span> }
               { request.status === CONTEST_REQUEST_REJECTED && <span className="badge badge-danger">Rejected</span> }
             </td>
             <td>
               { request.acceptedByUserName }
             </td>
             <td>
               <RemoveButton removing={ request.removing } click={ () => removeContestRequest(request) } />
             </td>
           </tr>
  }

  render() {
    const {contest, requests, acceptContestRequest, rejectContestRequest} = this.props;

    const mappedFightersRequests = requests.filter(r => r.type === CONTEST_FIGHTER)
      .map((request, i) => this.mapRequest(request, i, acceptContestRequest, rejectContestRequest))

    const mappedJudgesRequests = requests.filter(r => r.type === CONTEST_JUDGE)
      .map((request, i) => this.mapRequest(request, i, acceptContestRequest, rejectContestRequest))

    const mappedDoctorsRequests = requests.filter(r => r.type === CONTEST_DOCTOR)
      .map((request, i) => this.mapRequest(request, i, acceptContestRequest, rejectContestRequest))

    return (
      <div>
        <Nav tabs>
          <NavItem>
            <NavLink className={ classnames({
                                   active: this.state.activeTab === '1'
                                 }) } onClick={ () => {
                                                                                                                                                                          this.toggle('1');
                                                                                                                                                                        } }>
              <i className="fa fa-user"></i> Fighters  <span className="badge badge-pill badge-primary"> { mappedFightersRequests.length }</span>
            </NavLink>
          </NavItem>
          <NavItem>
            <NavLink className={ classnames({
                                   active: this.state.activeTab === '2'
                                 }) } onClick={ () => {
                                                                                                                                                                          this.toggle('2');
                                                                                                                                                                        } }>
              <i className="fa fa-gavel"></i> Judges <span className="badge badge-pill badge-success"> { mappedJudgesRequests.length }</span>
            </NavLink>
          </NavItem>
          <NavItem>
            <NavLink className={ classnames({
                                   active: this.state.activeTab === '3'
                                 }) } onClick={ () => {
                                                                                                                                                                          this.toggle('3');
                                                                                                                                                                        } }>
              <i className="fa fa-user-md"></i> Doctors <span className="badge badge-pill badge-danger"> { mappedDoctorsRequests.length }</span>
            </NavLink>
          </NavItem>
        </Nav>
        <TabContent activeTab={ this.state.activeTab }>
          <TabPane tabId="1">
            <div className="h6">Pending requests:</div>
            <table className="table table-hover mb-0 hidden-sm-down">
              <thead>
                <tr>
                  <th className="col-2">Name</th>
                  <th>Gym</th>
                  <th>City</th>
                  <th>Country</th>
                  <th>Category</th>
                  <th>Status</th>
                  <th>Accepted by</th>
                  <th className="text-center">Actions</th>
                </tr>
              </thead>
              <tbody>
                { mappedFightersRequests }
              </tbody>
            </table>
          </TabPane>
          <TabPane tabId="2">
            <table className="table table-hover mb-0 hidden-sm-down">
              <thead>
                <tr>
                  <th className="col-2">Name</th>
                  <th>Gym</th>
                  <th>City</th>
                  <th>Country</th>
                  <th>Status</th>
                  <th>Accepted by</th>
                  <th className="text-center">Actions</th>
                </tr>
              </thead>
              <tbody>
                { mappedJudgesRequests }
              </tbody>
            </table>
          </TabPane>
          <TabPane tabId="3">
            <table className="table table-hover mb-0 hidden-sm-down">
              <thead>
                <tr>
                  <th className="col-2">Name</th>
                  <th>Gym</th>
                  <th>City</th>
                  <th>Country</th>
                  <th>Status</th>
                  <th>Accepted by</th>
                  <th className="text-center">Actions</th>
                </tr>
              </thead>
              <tbody>
                { mappedDoctorsRequests }
              </tbody>
            </table>
          </TabPane>
        </TabContent>
      </div>
    )
  }
}

export default ContestInstitutionRequests