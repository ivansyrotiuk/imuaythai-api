import React, { Component } from 'react';
import { host } from "../../global"
import { saveInstitution, fetchInstitution } from "../../actions/InstitutionsActions"
import { connect } from "react-redux"
import axios from "axios";
import Spinner from "../Components/Spinners/Spinner"
import InstitutionDataForm from "./Forms/InstitutionDataForm"
import Page from "../Components/Page"

class InstitutionEditPage extends Component {

  componentWillMount() {
    const id = this.props.match.params.id;
    this.props.fetchInstitution(id);
  }

  render() {
    const {institution, fetching} = this.props;

    if (fetching) {
      return (<Spinner/>);
    }

    const header = <strong>Gym</strong>;
    const content = <InstitutionDataForm initialValues={ this.props.institution } onSubmit={ this.props.saveInstitution } />;
    return <Page header={ header } content={ content } />;
  }
}


const mapStateToProps = (state, ownProps) => {
  return {
    institution: state.SingleInstitution.institution,
    fetching: state.SingleInstitution.fetching,
    fetched: state.SingleInstitution.fetched
  }
}

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    fetchInstitution: (id) => {
      dispatch(fetchInstitution(id));
    },
    saveInstitution: (institution) => {
      return dispatch(saveInstitution(institution));
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(InstitutionEditPage)