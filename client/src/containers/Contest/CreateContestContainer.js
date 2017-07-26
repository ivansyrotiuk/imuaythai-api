import React, { Component } from 'react';
import CreateContestPage from '../../views/Contest/CreateContestPage';
import { connect } from 'react-redux';
import { fetchCountries } from "../../actions/CountriesActions";
import { fetchTypes } from "../../actions/Dictionaries/ContestTypesActions";
class CreateContestContainer extends Component {
    componentWillMount() {
        if (!this.props.countries.length) {
            this.props.fetchCountries();
        }
        if (!this.props.contestTypes.length) {
            this.props.fetchContestTypes();
        }
    }
    render() {

        return (
            <CreateContestPage countries={ this.props.countries } contestTypes={ this.props.contestTypes } />
            );
    }
}


const mapStateToProps = (state, ownProps) => {
    return {
        countries: state.Countries.countries,
        contestTypes: state.ContestTypes.types
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchCountries: () => {
            dispatch(fetchCountries());
        },
        fetchContestTypes: () => {
            dispatch(fetchTypes())
        }
    }
}

CreateContestContainer = connect(mapStateToProps, mapDispatchToProps)(CreateContestContainer)
export default CreateContestContainer;