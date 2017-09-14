import React, { Component } from "react";
import { connect } from "react-redux";
import ContestFightsView from "../../views/Contest/ContestFightsView";
import Spinner from "../../views/Components/Spinners/Spinner";
import { fetchContestFights } from "../../actions/ContestActions";

export class ContestFightsContainer extends Component {
  componentWillMount() {
    var id = this.props.match.params.id;
    this.props.fetchFights(id);
  }

  render() {
    const { fetching, fights } = this.props;
    if (fetching) {
      return <Spinner />;
    }

    return <ContestFightsView fights={fights} />;
  }
}

const mapStateToProps = (state, ownProps) => {
  return {
    fights: state.Contest.fights,
    fetching: state.Contest.fetching
  };
};

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    fetchFights: contestId => {
      dispatch(fetchContestFights(contestId));
    }
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(
  ContestFightsContainer
);
