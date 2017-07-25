import React, { Component } from 'react';
import CreateContestPage from '../../views/Contest/CreateContestPage';
import { connect } from 'react-redux';
import { fetchCountries } from "../../actions/CountriesActions";
class CreateContestContainer extends Component {
    componentWillMount() {
        if (!this.props.countries.length) {
            this.props.fetchCountries();
        }
    }
    render() {

        return (
            <CreateContestPage countries={ this.props.countries } />
            );
    }
}


const mapStateToProps = (state, ownProps) => {
    return {
        countries: state.Countries.countries,
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchCountries: () => {
            dispatch(fetchCountries());
        },
    }
}

CreateContestContainer = connect(mapStateToProps, mapDispatchToProps)(CreateContestContainer)
export default CreateContestContainer;