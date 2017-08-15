import React, { Component } from 'react'
import { TabContent, TabPane, Nav, NavItem, NavLink } from 'reactstrap';
import { Route, Link } from 'react-router-dom';
import classnames from 'classnames';
import EditButton from '../Components/Buttons/EditButton'
import AcceptButton from '../Components/Buttons/AcceptButton'
import RejectButton from '../Components/Buttons/RejectButton'
import RemoveButton from '../Components/Buttons/RemoveButton'

class AcceptedContestRequests extends Component {
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
    return <tr key={ i }>
             <td className="col-2">
               { request.userName }
             </td>
             <td className="col-2">
               { request.institutionName }
             </td>
             <td className="col-2">
               { request.user.countryName }
             </td>
             { request.contestCategoryId && <td>
                                              { request.contestCategoryName }
                                            </td> }
             <td>
               { request.acceptedByUserName }
             </td>
           </tr>
  }

  render() {
    const {contest, doctorsRequests, judgesRequests, fightersRequests} = this.props;

    const mappedFightersRequests = fightersRequests.map((request, i) => this.mapRequest(request, i))
    const mappedJudgesRequests = judgesRequests.map((request, i) => this.mapRequest(request, i))
    const mappedDoctorsRequests = doctorsRequests.map((request, i) => this.mapRequest(request, i))

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
                  <th>Name</th>
                  <th>Gym</th>
                  <th>Country</th>
                  <th>Category</th>
                  <th>Accepted by</th>
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
                  <th>Name</th>
                  <th>Gym</th>
                  <th>Country</th>
                  <th>Accepted by</th>
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
                  <th>Name</th>
                  <th>Gym</th>
                  <th>Country</th>
                  <th>Accepted by</th>
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

export default AcceptedContestRequests