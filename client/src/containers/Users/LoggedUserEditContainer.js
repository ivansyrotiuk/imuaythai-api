import React, { Component } from 'react';
import { connect } from 'react-redux';
import { fetchUser, saveUser } from '../../actions/AccountActions'
import { fetchGyms } from "../../actions/InstitutionsActions"
import { fetchCountries } from "../../actions/CountriesActions";
import Page from "../../views/Components/Page";
import Spinner from "../../views/Components/Spinners/Spinner";
import CommonUserDataForm from "../../views/Users/CommonUserDataForm";

class LoggedUserEditContainer extends Component {
    componentWillMount() {

        if (!this.props.fetching && this.props.fetched)
            this.props.fetchUser(this.props.userId);

        if (this.props.countries === undefined ||
            this.props.countries.length === 0) {
            this.props.fetchCountries();
        }

        if (this.props.gyms === undefined ||
            this.props.gyms.length === 0) {
            this.props.fetchGyms();
        }
    }

    render() {
        const {fetching} = this.props;

        if (fetching) {
            return (<Spinner/>);
        }

        if (!fetching && this.props.user === undefined) {
            return (
                <div></div>
                );
        }

        const header = <strong>User</strong>;
        const content = <CommonUserDataForm initialValues={ this.props.user } countries={ this.props.countries } gyms={ this.props.gyms } onSubmit={ this.props.saveUser } imageUrl={ this.props.user.photo }
                        />;
        return <Page header={ header } content={ content } />
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        user: state.Account.loggedUser,
        countries: state.Countries.countries,
        gyms: state.Institutions.gyms,
        fetching: state.Account.fetchingUser,
        fetched: state.Account.fetchedUser,
    }
}


const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchCountries: () => {
            dispatch(fetchCountries());
        },
        fetchGyms: () => {
            dispatch(fetchGyms());
        },
        fetchUser: (id) => {
            dispatch(fetchUser(id));
        },
        saveUser: (user) => {
            return dispatch(saveUser(user));
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(LoggedUserEditContainer)