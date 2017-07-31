import React, { Component } from 'react';
import CreateContestPage from '../../views/Contest/CreateContestPage';
import { connect } from 'react-redux';
import { fetchCountries } from "../../actions/CountriesActions";
import { fetchTypes } from "../../actions/Dictionaries/ContestTypesActions";
import { fetchContest, saveContest } from '../../actions/ContestActions';

class ContestEditContainer extends Component {

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

    }
    render() {
        const initialValues = {
            date: new Date(),
            endRegisterDate: new Date()
        }

        return (
            <CreateContestPage countries={ this.props.countries } contestTypes={ this.props.contestTypes } onSubmit={ this.props.onSubmit } initialValues={ initialValues } />
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
            dispatch(saveContest(values));
        },
        getContestType: (id) => {

        }
    }
}

ContestEditContainer = connect(mapStateToProps, mapDispatchToProps)(ContestEditContainer)
export default ContestEditContainer;