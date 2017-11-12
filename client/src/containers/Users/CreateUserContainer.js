import React, {Component} from 'react';
import {connect} from "react-redux";
import Loader from "react-loader-advanced"
import CreateUserView from "../../views/Users/CreateUserView";
import {fetchCountryGyms} from "../../actions/InstitutionsActions";
import {fetchCountries} from "../../actions/CountriesActions";
import {fetchRoles} from "../../actions/RolesActions";
import {createUser} from "../../actions/UsersActions";
import Spinner from "../../views/Components/Spinners/Spinner";

class CreateUserContainer extends Component {
    componentWillMount() {
        this.props.fetchRoles();
        this.props.fetchCountries();
    }

    handleCountryChange(event) {
        const countryId = event.target.value;
        this.props.fetchGyms(countryId);
    }

    render() {
        if (this.props.fetching){
            return <Spinner/>;
        }

        return (<Loader show={this.props.fetchingGyms} message={<Spinner/>} >
                    <CreateUserView {...this.props} countryChange={this.handleCountryChange.bind(this)}/>
                </Loader>);
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        gyms: state.Institutions.countryGyms,
        countries: state.Countries.countries,
        roles: state.Roles.roles,
        fetching: state.Countries.fetching || state.Roles.fetching,
        fetchingGyms: state.Institutions.fetching
    };
};

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchGyms: (countryId) => dispatch(fetchCountryGyms(countryId)),
        fetchCountries: () => dispatch(fetchCountries()),
        fetchRoles: () => dispatch(fetchRoles()),
        onSubmit: (user) => dispatch(createUser(user)),
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(CreateUserContainer);
