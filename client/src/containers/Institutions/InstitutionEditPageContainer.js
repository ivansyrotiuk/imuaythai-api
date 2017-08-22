import React, { Component } from 'react';
import { saveInstitution, addInstitution, resetInstitution, fetchInstitution } from "../../actions/InstitutionsActions"
import institutionTypes from "./institutionTypes"
import { fetchCountries } from "../../actions/CountriesActions";
import { connect } from "react-redux"
import axios from "axios";
import Spinner from "../../views/Components/Spinners/Spinner"
import InstitutionDataForm from "../../views/Institutions/InstitutionDataForm"
import Page from "../../views/Components/Page"
class InstitutionEditPageContainer extends Component {
  componentWillMount() {
    const id = this.props.match.params.id;
    if (id) {
      this.props.fetchInstitution(id);
    }

    const type = this.props.match.params.type;

    if (type) {
      this.props.addInstitution(type);
    }

    if (this.props.countries === undefined ||
      this.props.countries.length === 0) {
      this.props.fetchCountries();
    }
  }

  componentDidUpdate() {
    if (this.props.saved) {
      this.props.resetInstitution();
      this.props.history.goBack();
    }
  }

  render() {
    const {institution, fetching, saved} = this.props;

    if (fetching) {
      return (<Spinner />);
    }

    const type = this.props.match.params.type;
    const header = <strong>Add { type } </strong>;


    const content = <InstitutionDataForm initialValues={ this.props.institution } onSubmit={ this.props.saveInstitution } countries={ this.props.countries } />;

    return <Page header={ header } content={ content } />;

  }
}


const mapStateToProps = (state, ownProps) => {
  return {
    institution: state.SingleInstitution.institution,
    countries: state.Countries.countries,
    fetching: state.SingleInstitution.fetching,
    fetched: state.SingleInstitution.fetched,
    saved: state.SingleInstitution.saved
  }
}

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    fetchCountries: () => {
      dispatch(fetchCountries());
    },
    fetchInstitution: (id) => {
      dispatch(fetchInstitution(id));
    },
    addInstitution: (type) => {

      const institutionType = institutionTypes[type];
      dispatch(addInstitution(institutionType));
    },
    saveInstitution: (institution) => {
      return dispatch(saveInstitution(institution));
    },
    resetInstitution: () => {
      dispatch(resetInstitution())
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(InstitutionEditPageContainer)