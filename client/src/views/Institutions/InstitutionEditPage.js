import React, { Component } from 'react';
import { saveInstitution, addInstitution, fetchInstitution } from "../../actions/InstitutionsActions"
import institutionTypes from "./institutionTypes"
import { fetchCountries } from "../../actions/CountriesActions";
import { connect } from "react-redux"
import axios from "axios";
import Spinner from "../Components/Spinners/Spinner"
import InstitutionDataForm from "./Forms/InstitutionDataForm"
import Page from "../Components/Page"
import { reset } from 'redux-form';

class InstitutionEditPage extends Component {
  constructor(props) {
    super(props);

  }

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

  render() {
    const {institution, fetching} = this.props;

    if (fetching) {
      return (<Spinner/>);
    }

    const header = <strong>Gym</strong>;
    const content = <InstitutionDataForm initialValues={ this.props.institution } onSubmit={ this.props.saveInstitution } countries={ this.props.countries } />;
    return <Page header={ header } content={ content } />;
  }
}


const mapStateToProps = (state, ownProps) => {
  return {
    countries: state.Countries.countries,
    institution: state.SingleInstitution.institution,
    fetching: state.SingleInstitution.fetching,
    fetched: state.SingleInstitution.fetched
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
      dispatch(reset("InstitutionDataForm"));

      const institutionType = institutionTypes[type];
      dispatch(addInstitution(institutionType));
    },
    saveInstitution: (institution) => {
      return dispatch(saveInstitution(institution));
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(InstitutionEditPage)