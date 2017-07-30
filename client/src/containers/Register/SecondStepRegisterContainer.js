import React, { Component } from 'react'
import { connect } from 'react-redux'
import SecondStepRegister from '../../views/Register/SecondStepRegister'
import Spinner from '../../views/Components/Spinners/Spinner'
import { fetchCountries } from '../../actions/CountriesActions'
import { fetchPublicRoles } from '../../actions/RolesActions'
import { setRequestedRole } from '../../actions/UserRolesActions'
import { fetchCountryGyms } from '../../actions/InstitutionsActions'

class SecondStepRegisterContainer extends Component {
    constructor(props) {
        super(props);
        this.onSubmit = this.onSubmit.bind(this);
        this.onCountryChange = this.onCountryChange.bind(this);
    }

    componentWillMount() {
        if (this.props.countries.length === 0) {
            this.props.fetchCountries();
        }

        if (this.props.roles.length === 0) {
            this.props.fetchRoles();
        }
    }

    onSubmit() {}

    onCountryChange(event) {
        const countryId = event.target.value;
        this.props.fetchCountryGyms(countryId);
    }

    render() {
        const {countries, roles, countryGyms, fetchingCountries, fetchingRoles, fetchingGyms} = this.props;

        if (fetchingCountries || fetchingRoles) {
            return <Spinner />
        }


        return <SecondStepRegister countries={ countries } roles={ roles } fetchingGyms={ fetchingGyms } gyms={ countryGyms } onSubmit={ this.onSubmit }
                 onCountryChange={ this.onCountryChange } />
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        countries: state.Countries.countries,
        fetchingCountries: state.Countries.fetching,
        roles: state.Roles.publicRoles,
        fetchingRoles: state.Roles.fetching,
        countryGyms: state.Institutions.countryGyms,
        fetchingGyms: state.Institutions.fetching
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchCountries: () => {
            dispatch(fetchCountries())
        },
        fetchRoles: () => {
            dispatch(fetchPublicRoles());
        },
        fetchCountryGyms: (countryId) => {
            dispatch(fetchCountryGyms(countryId));
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(SecondStepRegisterContainer)