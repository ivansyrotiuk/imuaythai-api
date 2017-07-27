import React, { Component } from 'react';
import CreateContestPage from '../../views/Contest/CreateContestPage';
import { connect } from 'react-redux';
import { fetchCountries } from "../../actions/CountriesActions";
import { fetchTypes } from "../../actions/Dictionaries/ContestTypesActions";
import { fetchContest, saveContest } from '../../actions/ContestActions';

class CreateContestContainer extends Component {
    componentWillMount() {
        var contestId = this.props.match.params;
        if (!this.props.countries.length) {
            this.props.fetchCountries();
        }
        if (!this.props.contestTypes.length) {
            this.props.fetchContestTypes();
        }
        if (contestId != undefined && contestId.id != undefined) {
            this.props.getContestType(contestId.id);
        }

        if (contestId != undefined) {
            this.props.getContestType(contestId.id);
        }
    }
    render() {

        return (
            <CreateContestPage countries={ this.props.countries } contestTypes={ this.props.contestTypes } onSubmit={ this.props.onSubmit } />
            );
    }
}


const mapStateToProps = (state, ownProps) => {
    return {
        countries: state.Countries.countries,
        contestTypes: state.ContestTypes.types,
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchCountries: () => {
            dispatch(fetchCountries());
        },
        fetchContestTypes: () => {
            dispatch(fetchTypes())
        },
        onSubmit: (values) => {
            dispatch(saveContest({
                name: values.name,
                date: values.date,
                address: values.address,
                duration: values.duration,
                ringsCount: values.ringsCount,
                city: values.city,
                countryId: values.countryId,
                allowUnassociated: values.allowUnassociated,
                website: values.website,
                facebook: values.facebook,
                vk: values.vk,
                twitter: values.twitter,
                instagram: values.instagram,
                contestCategories: values.contestCategories
            }));
        },
        getContestType: (id) => {

        }
    }
}

CreateContestContainer = connect(mapStateToProps, mapDispatchToProps)(CreateContestContainer)
export default CreateContestContainer;