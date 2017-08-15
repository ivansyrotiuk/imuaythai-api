import React, { Component } from 'react';
import { connect } from "react-redux";
import Spinner from "../../views/Components/Spinners/Spinner";
import CommonUserDataForm from "../../views/Users/CommonUserDataForm";
import { saveFighter, fetchUser, saveUser } from "../../actions/UsersActions";
import { fetchGyms } from "../../actions/InstitutionsActions"
import { fetchCountries } from "../../actions/CountriesActions";
import { userHasRole } from '../../auth/auth';
import Page from "../../views/Components/Page"

class UserEditPageContainer extends Component {
    componentWillMount() {
        const userId = this.props.userId;

        this.props.fetchUser(userId);

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
        const {fetching, saved} = this.props;

        if (fetching) {
            return (<Spinner/>);
        }

        if (!fetching && this.props.user == undefined) {
            return (
                <div></div>
                );
        }

        const userHasRole = this.props.user.roles.find(r => r !== "") !== undefined;

        const header = <strong>Fighter</strong>;
        const content = <CommonUserDataForm initialValues={ this.props.user } countries={ this.props.countries } gyms={ this.props.gyms } onSubmit={ this.props.saveUser } />;
        return <Page header={ header } content={ content } />
    }
}


const mapStateToProps = (state, ownProps) => {
    return {
        countries: state.Countries.countries,
        gyms: state.Institutions.gyms,
        user: state.SingleUser.user,
        fetching: state.SingleUser.fetching,
        saved: state.SingleUser.saved,
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

export default connect(mapStateToProps, mapDispatchToProps)(UserEditPageContainer)