import React, {Component} from 'react';
import {connect} from "react-redux";
import axios from "axios";
import moment from 'moment';
import { TabContent, TabPane, Nav, NavItem, NavLink } from 'reactstrap';
import classnames from 'classnames';
import DatePicker from 'react-datepicker';
import {host} from "../../global"
import Spinner from "../Components/Spinners/Spinner";
import {fetchFighter, saveFighter} from "../../actions/UsersActions";
import CommonUserDataForm from "./Forms/CommonUserDataForm"
import 'react-datepicker/dist/react-datepicker.css';

@connect((store) => {
    return {fighter: store.SingleFighter.fighter, fetching: store.SingleFighter.fetching, fetched: store.SingleFighter.fetched};
})
export default class FighterEditPage extends Component {
    constructor(props) {
        super(props);
        this.onSubmit = this.handleSubmit.bind(this);
        this.state = {activeTab: 'common'};
        this.dispatchFetchFighter();
    }


    dispatchFetchFighter() {
        const fighterId = this.props.match.params.id;
        this
            .props
            .dispatch(fetchFighter(fighterId))
    }

    dispatchSaveFighter(fighter) {
        this.props
            .dispatch(saveFighter(fighter))
    }

    handleSubmit(values) {
       
        var self = this;

        axios
            .post(host + 'api/users/save', values)
            .then(function (response) {
                self.dispatchSaveFighter(response.data)
            })
            .catch(function (error) {
                self.props.history.push('/500');
            });
    }

    render() {

        const {fetching, fetched} = this.props;
        
        if (fetching) {
            return (<Spinner />);
        }
        if (!fetched && this.state.fighter == undefined) {
            return (<div></div>);
        }

        return (
            <div className="animated fadeIn">
                <div className="row">
                    <div className="col-12">
                        <div className="card">
                            <div className="card-header">
                                <strong>Fighter</strong>
                            </div>
                            <div className="card-block">
                                <CommonUserDataForm initialValues={this.props.fighter} onSubmit={this.onSubmit}/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}