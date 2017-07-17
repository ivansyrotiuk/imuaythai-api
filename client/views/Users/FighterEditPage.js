import React, {Component} from 'react';
import {connect} from "react-redux";
import axios from "axios";
import moment from 'moment';
import {TabContent, TabPane, Nav, NavItem, NavLink} from 'reactstrap';
import classnames from 'classnames';
import DatePicker from 'react-datepicker';
import {host} from "../../global"
import Spinner from "../Components/Spinners/Spinner";
import {saveFighter} from "../../actions/UsersActions";
import {fetchCountries} from "../../actions/CountriesActions";
import CommonUserDataForm from "./Forms/CommonUserDataForm"
import 'react-datepicker/dist/react-datepicker.css';

@connect((store) => {
    return {countries: store.Countries.countries};
})
export default class FighterEditPage extends Component {
    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.dispatchFetchFighter = this.dispatchFetchFighter.bind(this);
        this.state = {fetching: true};
    }

    componentWillMount() {
        this.dispatchFetchFighter();
        this.dispatchFetchCountries();
    }

    dispatchFetchFighter() {
        const fighterId = this.props.match.params.id;

        var self = this;
      
        axios
            .get(host + "api/users/fighters/" + fighterId)
            .then((response) => {
                self.setState({fetching: false, fighter: response.data});
            })
            .catch((err) => {
                self.setState({fetching: false, error: err});
            });
    }

    dispatchFetchCountries() {
        if (this.props.countries.length == 0) {
            this.props.dispatch(fetchCountries());
        }
    }

    dispatchSaveFighter(fighter) {
        this.props.dispatch(saveFighter(fighter))
    }

    handleSubmit(values) {
        var self = this;

        return axios
            .post(host + 'api/users/save', values)
            .then(function (response) {
                self.dispatchSaveFighter(response.data);
                self.props.history.goBack();
            })
            .catch(function (error) {
                self.props.history.push('/500');
            });
    }

    render() {

        const {fetching} = this.state;

        if (fetching) {
            return (<Spinner/>);
        }
        if (!fetching && this.state.fighter == undefined) {
            return (
                <div></div>
            );
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
                                <CommonUserDataForm
                                    initialValues={this.state.fighter}
                                    countries={this.props.countries}
                                    onSubmit={this.handleSubmit}/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}