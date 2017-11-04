import React, { Component } from 'react';
import { connect } from "react-redux";
import Spinner from "../../../views/Components/Spinners/Spinner";
import { fetchInstitution } from "../../../actions/InstitutionsActions";
import GymView from "../../../views/Institutions/GymView";

class GymViewPageContainer extends Component {

  componentWillMount() {
    const gymId = this.props.match.params.id;
    this.props.fetchInstitution(gymId);
  }

  goToEditPageClick() {
    const gymId = this.props.match.params.id;
    this.props.history.push("/institutions/gyms/edit/" + gymId);
  }

  render() {
    const {fetching, gym} = this.props;

    if (fetching || !gym) {
      return (<Spinner/>);
    }

    const actions = {
        goToEditPage : this.goToEditPageClick.bind(this)
    };

    return <GymView gym={gym} actions={actions}/>
  }
}

const mapStateToProps = (state, ownProps) => {
  return {
    gym: state.SingleInstitution.institution,
    fetching: state.SingleInstitution.fetching
  }
}

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    fetchInstitution: (id) => {
      dispatch(fetchInstitution(id));
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(GymViewPageContainer)