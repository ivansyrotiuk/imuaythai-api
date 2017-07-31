import React, { Component } from 'react';
import CreateContestPage from '../../views/Contest/CreateContestPage';
import { connect } from 'react-redux';
import { fetchCountries } from "../../actions/CountriesActions";
import { fetchTypes } from "../../actions/Dictionaries/ContestTypesActions";
import { fetchRanges } from "../../actions/Dictionaries/ContestRangesActions";
import { fetchContestCategories } from "../../actions/Dictionaries/ContestCategoriesActions";
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
        if (!this.props.contestCategories.length) {
            this.props.fetchContestCategories();
        }
        if (!this.props.contestRanges.length) {
            this.props.fetchRanges();
        }
    }
    render() {
        const initialValues = {
            date: new Date(),
            endRegisterDate: new Date()
        }

        return (
            <CreateContestPage initialValues={ initialValues } countries={ this.props.countries } contestTypes={ this.props.contestTypes } contestRanges={ this.props.contestRanges } categories={ this.props.contestCategories }
              onSubmit={ this.props.onSubmit } />
            );
    }
}


const mapStateToProps = (state, ownProps) => {
    return {
        countries: state.Countries.countries,
        contestTypes: state.ContestTypes.types,
        contestCategories: state.ContestCategories.categories,
        contestRanges: state.ContestRanges.ranges
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
        fetchContestCategories: () => {
            dispatch(fetchContestCategories())
        },
        fetchRanges: () => {
            dispatch(fetchRanges())
        },
        onSubmit: (values) => {
            return dispatch(saveContest(values));
        },
    }
}

ContestEditContainer = connect(mapStateToProps, mapDispatchToProps)(ContestEditContainer)
export default ContestEditContainer;