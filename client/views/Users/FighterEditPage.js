import React, {Component} from 'react';
import {host} from "../../global"
import Spinner from "../Components/Spinners/Spinner";
import {fetchFighter, saveFighter} from "../../actions/UsersActions";
import CommonUserDataForm from "./Forms/CommonUserDataForm"
import {connect} from "react-redux";
import axios from "axios";
import { TabContent, TabPane, Nav, NavItem, NavLink } from 'reactstrap';
import classnames from 'classnames';
import DatePicker from 'react-datepicker';
import moment from 'moment';
import 'react-datepicker/dist/react-datepicker.css';

@connect((store) => {
    return {fighter: store.SingleFighter.fighter, fetching: store.SingleFighter.fetching, fetched: store.SingleFighter.fetched};
})
export default class FighterEditPage extends Component {
    constructor(props) {
        super(props);
        this.onSubmit = this.handleSubmit.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleBirthdateChange = this.handleBirthdateChange.bind(this);
        
       
        this.toggle = this.toggle.bind(this);
        this.state = {fighter: this.props.fighter, activeTab: 'common'};
        this.dispatchFetchFighter();
    }

    toggle(tab) {
        if (this.state.activeTab !== tab) {
            this.setState({
                activeTab: tab
            });
        }
    }

    dispatchFetchFighter() {
        const fighterId = this.props.match.params.id;
        this
            .props
            .dispatch(fetchFighter(fighterId))
    }

    saveFighter(fighter) {
        this.props
            .dispatch(saveFighter(fighter))
    }

    handleSubmit(e) {
        e.preventDefault();
        var self = this;

        axios
            .post(host + 'api/users/save', self.state.fighter)
            .then(function (response) {
                self.saveFighter(response.data)
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox'
            ? target.checked
            : target.value;
        
        const name = target.name;
        const fighter = this.state.fighter;

        fighter[target.name] = value;
        this.setState({fighter: fighter});
    }

    handleBirthdateChange(date){
        const fighter = this.state.fighter;
        fighter.birthdate = date;
        this.setState({fighter: fighter});
    }

    render() {

        const {fetching, fetched} = this.props;
        
        if (fetching) {
            return (<Spinner />);
        }
        if (!fetched && this.state.fighter == undefined) {
            return (<div></div>);
        }

        this.state.fighter = this.props.fighter;

        return (
            <div className="animated fadeIn">
                <div className="row">
                    <div className="col-12">
                        <div className="card">
                            <div className="card-header">
                                <strong>Fighter</strong>
                            </div>
                            <div className="card-block">
                             
                                    <Nav tabs>
                                    <NavItem>
                                        <NavLink className={classnames({ active: this.state.activeTab === 'common' })}
                                        onClick={() => { this.toggle('common'); }}>
                                            <i class="fa fa-id-card-o"></i> Common
                                        </NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink
                                        className={classnames({ active: this.state.activeTab === '2' })}
                                        onClick={() => { this.toggle('2'); }}
                                        >
                                        <i className="icon-basket-loaded"></i> Shoping cart
                                        </NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink
                                        className={classnames({ active: this.state.activeTab === '3' })}
                                        onClick={() => { this.toggle('3'); }}
                                        >
                                        <i className="icon-pie-chart"></i> Charts
                                        </NavLink>
                                    </NavItem>
                                    </Nav>
                                    <TabContent activeTab={this.state.activeTab}>
                                    <TabPane tabId="common">
                                        <CommonUserDataForm user={this.state.fighter} onSubmit={this.onSubmit}/>
                                    </TabPane>
                                    <TabPane tabId="2">
                                        2. Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                                    </TabPane>
                                    <TabPane tabId="3">
                                        2. Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                                    </TabPane>
                                    </TabContent>
                     
                               
                                
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        );
    }
}