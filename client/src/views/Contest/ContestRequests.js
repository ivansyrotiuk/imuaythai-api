import React, { Component } from 'react'
import { TabContent, TabPane, Nav, NavItem, NavLink } from 'reactstrap';
import { Route, Link } from 'react-router-dom';
import classnames from 'classnames';
import moment from 'moment'
import Page from '../Components/Page'
import EditButton from '../Components/Buttons/EditButton'
import ContestInfoCard from './ContestInfoCard'


class ContestRequests extends Component {
  constructor(props) {
    super(props);

    this.toggle = this.toggle.bind(this);
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
  render() {
    const {contest} = this.props;
    return (
      <div>
        <Nav tabs>
          <NavItem>
            <NavLink className={ classnames({
                                   active: this.state.activeTab === '1'
                                 }) } onClick={ () => {
                                                                                                                                                                          this.toggle('1');
                                                                                                                                                                        } }>
              <i className="fa fa-user"></i> Fighters  <span className="badge badge-pill badge-primary">78</span>
            </NavLink>
          </NavItem>
          <NavItem>
            <NavLink className={ classnames({
                                   active: this.state.activeTab === '2'
                                 }) } onClick={ () => {
                                                                                                                                                                          this.toggle('2');
                                                                                                                                                                        } }>
              <i className="fa fa-gavel"></i> Judges <span className="badge badge-pill badge-success">15</span>
            </NavLink>
          </NavItem>
          <NavItem>
            <NavLink className={ classnames({
                                   active: this.state.activeTab === '3'
                                 }) } onClick={ () => {
                                                                                                                                                                          this.toggle('3');
                                                                                                                                                                        } }>
              <i className="fa fa-user-md"></i> Doctors <span className="badge badge-pill badge-danger"> 7</span>
            </NavLink>
          </NavItem>
        </Nav>
        <TabContent activeTab={ this.state.activeTab }>
          <TabPane tabId="1">
            <table className="table table-hover mb-0 hidden-sm-down">
              <thead>
                <tr>
                  <th className="col-2">Name</th>
                  <th className="col-2">Gym</th>
                  <th className="col-1">City</th>
                  <th className="col-2">Country</th>
                  <th className="col-2">Category</th>
                  <th>Status</th>
                  <th>Accepted by</th>
                  <th>Actions</th>
                </tr>
              </thead>
              <tbody>
              </tbody>
            </table>
          </TabPane>
          <TabPane tabId="2">
            <table className="table table-hover mb-0 hidden-sm-down">
              <thead>
                <tr>
                  <th className="col-2">Name</th>
                  <th className="col-2">Gym</th>
                  <th className="col-1">City</th>
                  <th className="col-2">Country</th>
                  <th>Status</th>
                  <th>Accepted by</th>
                  <th>Actions</th>
                </tr>
              </thead>
              <tbody>
              </tbody>
            </table>
          </TabPane>
          <TabPane tabId="3">
            <table className="table table-hover mb-0 hidden-sm-down">
              <thead>
                <tr>
                  <th className="col-2">Name</th>
                  <th className="col-2">Gym</th>
                  <th className="col-1">City</th>
                  <th className="col-2">Country</th>
                  <th>Status</th>
                  <th>Accepted by</th>
                  <th>Actions</th>
                </tr>
              </thead>
              <tbody>
              </tbody>
            </table>
          </TabPane>
        </TabContent>
      </div>
    )
  }
}

export default ContestRequests