import React, {Component} from 'react';
import { connect } from "react-redux";
import CreateUserView from "../../views/Users/CreateUserView";
import {fetchCountryGyms} from "../../actions/InstitutionsActions";
import {fetchCountries} from "../../actions/CountriesActions";
import {fetchRoles} from "../../actions/RolesActions";
import {createUser} from "../../actions/UsersActions";

class CreateUserContainer extends Component{
    componentWillMount() {
        this.props.fetchRoles();
        this.props.fetchCountries();
    }

    handleCountryChange(event) {
        const countryId = event.target.value;
        this.props.fetchGyms(countryId);
    }

    render(){
        return <CreateUserView {...this.props} countryChange={this.handleCountryChange.bind(this)}/>
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        gyms: state.Institutions.countryGyms,
        countries: state.Countries.countries,
        roles: state.Roles.roles
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
