import React, { Component } from 'react'
import { connect } from 'react-redux'
import FinishRegisterPage from '../../views/Register/FinishRegisterPage'
import Spinner from '../../views/Components/Spinners/Spinner'
import { fetchCountries } from '../../actions/CountriesActions'
import { fetchPublicRoles } from '../../actions/RolesActions'
import { setRequestedRole } from '../../actions/UserRolesActions'
import { fetchCountryGyms } from '../../actions/InstitutionsActions'
import { finishRegister } from '../../actions/AccountActions'
import { saveState } from '../../localStorage'
import { SubmissionError } from 'redux-form'
import jwtDecode from 'jwt-decode';

class FinishRegisterContainer extends Component {
    constructor(props) {
        super(props);
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

    onCountryChange(event) {
        const countryId = event.target.value;
        this.props.fetchCountryGyms(countryId);
    }

    render() {
        const {countries, roles, countryGyms, fetchingCountries, fetchingRoles, fetchingGyms, user, authToken} = this.props;

        if (fetchingCountries || fetchingRoles) {
            return <Spinner />
        }

        if (user.roles.find(r => r !== "") !== undefined) {
            const authAccount = {
                authToken: this.props.authToken,
                user: jwtDecode(this.props.authToken)
            }
            saveState(authAccount)
            this.props.history.push('/');
        }


        return <FinishRegisterPage countries={ countries } roles={ roles } fetchingGyms={ fetchingGyms } gyms={ countryGyms } onSubmit={ this.props.finishRegister }
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
        fetchingGyms: state.Institutions.fetching,
        authToken: state.Account.authToken,
        user: state.Account.user
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
        },
        finishRegister: (finishData) => {
            if (!finishData.countryId) {
                throw new SubmissionError({
                    _error: 'Please, select your country'
                })
            }
            if (!finishData.roleId) {
                throw new SubmissionError({
                    _error: 'Please, your user role'
                })
            }
            if (finishData.ownGym && !finishData.gymName) {
                throw new SubmissionError({
                    _error: 'Please, enter your gym name'
                })
            }
            if (!finishData.ownGym && !finishData.institutionId) {
                throw new SubmissionError({
                    _error: 'Please, select your gym'
                })
            }
            return dispatch(finishRegister(finishData));
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(FinishRegisterContainer)