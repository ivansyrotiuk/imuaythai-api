import React, { Component } from 'react';
import { connect } from "react-redux"
import { fetchGyms, deleteInstitution } from "../../../actions/InstitutionsActions"
import Spinner from "../../../views/Components/Spinners/Spinner"
import FederationsListView from "../../../views/Institutions/FederationsListView";

class GymsPageContainer extends Component {
    constructor(props) {
        super(props);
        this.handleAddFederationClick = this.handleAddFederationClick.bind(this);
        this.handlePreviewFederationClick = this.handlePreviewFederationClick.bind(this);
        this.handleEditFederationClick = this.handleEditFederationClick.bind(this);
        this.handleDeleteFederationClick = this.handleDeleteFederationClick.bind(this);
    }

    componentWillMount() {
        this.props.fetchGyms();
    }

    handleAddFederationClick() {
        this.props.history.push('/institutions/gyms/add');
    }

    handlePreviewFederationClick(id) {
        this.props.history.push("/institutions/gyms/" + id);
    }

    handleEditFederationClick(id) {
        this.props.history.push("/institutions/gyms/edit/" + id);
    }

    handleDeleteFederationClick(id) {
        this.props.deleteGym(id);
    }

    get viewTitle(){
        return "Gyms";
    }

    get viewActions(){
        return {
            addClick: this.handleAddFederationClick,
            previewClick: this.handlePreviewFederationClick,
            editClick: this.handleEditFederationClick,
            deleteClick: this.handleDeleteFederationClick
        };
    }

    render() {
        const {gyms, fetching} = this.props;

        if (fetching) {
            return <Spinner/>
        }

        return <FederationsListView title={this.viewTitle} federations={gyms} actions={this.viewActions}/>
    }
}

const mapStateToProps = (state, ownProps) => {
  return {
    gyms: state.Institutions.gyms,
    fetching: state.Institutions.fetching,
    fetched: state.Institutions.fetched,
    danger: false
  }
}

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    fetchGyms: () => {
      dispatch(fetchGyms())
    },
    deleteGym: (id) => {
      return dispatch(deleteInstitution(id));
    }
  }
};

export default connect(mapStateToProps, mapDispatchToProps)(GymsPageContainer)