import React, {Component} from 'react';
import {connect} from "react-redux";
import Spinner from "../Components/Spinners/Spinner";
import CommonUserDataForm from "./Forms/CommonUserDataForm";
import {saveFighter, fetchUser, saveUser} from "../../actions/UsersActions";
import {fetchCountries} from "../../actions/CountriesActions";
import { userHasRole } from '../../auth/auth';

class UserEditPage extends Component {
    componentWillMount() {
        const userId = this.props.match.params.id;

        this.props.fetchUser(userId);

        if (this.props.countries === undefined ||
            this.props.countries.length === 0) {
            this.props.fetchCountries();
        }
    }

    render() {
        const {fetching, saving, saved} = this.props;

        if (fetching) {
            return (<Spinner/>);
        }

        if (!fetching && this.props.user == undefined) {
            return (
                <div></div>
            );
        }

        const userHasRole = this.props.user.roles.find(r => r !== "") !== undefined;

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
                                    initialValues={this.props.user}
                                    countries={this.props.countries}
                                    onSubmit={this.props.saveUser} />
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
       user: state.SingleUser.user,
       fetching: state.SingleUser.fetching,
       saving: state.SingleUser.saving,
       saved: state.SingleUser.saved,
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchCountries: () => {
            dispatch(fetchCountries());
        },
        fetchUser: (id) =>{
            dispatch(fetchUser(id));
        },
        saveUser: (user) =>{
            return dispatch(saveUser(user));
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(UserEditPage)