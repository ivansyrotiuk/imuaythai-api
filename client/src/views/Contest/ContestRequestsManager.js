import React, {Component} from 'react'
import {TabContent, TabPane, Nav, NavItem, NavLink} from 'reactstrap';
import classnames from 'classnames';
import {CONTEST_FIGHTER, CONTEST_JUDGE, CONTEST_DOCTOR} from '../../common/contestRoleTypes'
import RequestsTable from "../../components/Contest/Requests/RequestsTable";

class ContestRequestsManager extends Component {
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
        const {requests, acceptContestRequest, rejectContestRequest} = this.props;

        const fightersRequests = requests.filter(r => r.type === CONTEST_FIGHTER);
        const judgesRequests = requests.filter(r => r.type === CONTEST_JUDGE);
        const doctorsRequests = requests.filter(r => r.type === CONTEST_DOCTOR);

        const actions = {
            accept: acceptContestRequest,
            reject: rejectContestRequest
        };

        return (
            <div>
                <Nav tabs>
                    <NavItem>
                        <NavLink className={classnames({
                            active: this.state.activeTab === '1'
                        })} onClick={() => {
                            this.toggle('1');
                        }}>
                            <i className="fa fa-user"></i> Fighters <span
                            className="badge badge-pill badge-primary"> {fightersRequests.length}</span>
                        </NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink className={classnames({
                            active: this.state.activeTab === '2'
                        })} onClick={() => {
                            this.toggle('2');
                        }}>
                            <i className="fa fa-gavel"></i> Judges <span
                            className="badge badge-pill badge-success"> {judgesRequests.length}</span>
                        </NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink className={classnames({
                            active: this.state.activeTab === '3'
                        })} onClick={() => {
                            this.toggle('3');
                        }}>
                            <i className="fa fa-user-md"></i> Doctors <span
                            className="badge badge-pill badge-danger"> {doctorsRequests.length}</span>
                        </NavLink>
                    </NavItem>
                </Nav>
                <TabContent activeTab={this.state.activeTab}>
                    <TabPane tabId="1">
                        <div className="h6">Requests:</div>
                        <RequestsTable requests={fightersRequests} actions={actions}/>
                    </TabPane>
                    <TabPane tabId="2">
                        <RequestsTable requests={judgesRequests} actions={actions}/>
                    </TabPane>
                    <TabPane tabId="3">
                        <RequestsTable requests={doctorsRequests} actions={actions}/>
                    </TabPane>
                </TabContent>
            </div>
        )
    }
}

export default ContestRequestsManager