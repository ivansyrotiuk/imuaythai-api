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
import CommonUserDataForm from "./Forms/CommonUserDataForm";
import { userHasRole } from '../../auth/auth';
import 'react-datepicker/dist/react-datepicker.css';


class FighterEditPage extends Component {
    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.dispatchFetchFighter = this.dispatchFetchFighter.bind(this);
        this.state = { fetching: true };
    }

    componentWillMount() {
        const fighterId = this.props.match.params.id;

        this.dispatchFetchFighter(fighterId);

        if (this.props.countries === undefined ||
            this.props.countries.length === 0) {
            this.props.fetchCountries();
        }
      
    }

    dispatchFetchFighter(fighterId) {
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

    handleSubmit(values) {
        var self = this;
        return axios
            .post(host + 'api/users/save', values)
            .then(function (response) {
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

        const userHasRole = this.state.fighter.roles.find(r => r !== "") !== undefined;

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
                                    onSubmit={this.handleSubmit} />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}


const mapStateToProps = (state, ownProps) => {
    return {
       countries: state.Countries.countries, 
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchCountries: () => {
            dispatch(fetchCountries());
        },
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(FighterEditPage)