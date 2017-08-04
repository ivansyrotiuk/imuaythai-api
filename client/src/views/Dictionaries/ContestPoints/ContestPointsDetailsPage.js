import React, { Component } from 'react';
import { host } from "../../../global"
import { connect } from "react-redux"
import axios from "axios";
import LoadButton from "../../Components/Buttons/LoadButton";
import SimpleDictionaryDataForm from "../SimpleDictionaryDataForm";
import Spinner from "../../Components/Spinners/Spinner"
import { fetchRanges } from "../../../actions/Dictionaries/ContestRangesActions"
import { fetchTypes } from "../../../actions/Dictionaries/ContestTypesActions"
import ContestPointDataForm from './ContestPointDataForm'

class ContestPointsDetailsPage extends Component {
  constructor(props) {
    super(props);
    this.onSubmit = this.handleSubmit.bind(this);
    this.fetchPoint = this.fetchPoint.bind(this);
    this.state = {
      fetching: true
    };

  }
  componentWillMount() {
    this.dispatchFetchTypes();
    this.dispatchFetchRanges();
    this.fetchPoint(this.props.match.params.id);
  }

  fetchPoint(id) {
    this.setState();

    var self = this;
    axios
      .get(host + "api/dictionaries/points/" + id)
      .then((response) => {
        self.setState({
          ...self.state,
          fetching: false,
          point: response.data
        });
      })
      .catch((err) => {
        self.setState({
          ...self.state,
          fetching: false,
          error: err
        });
      })
  }

  dispatchFetchTypes() {
    if (this.props.types.length == 0) {
      this.props.fetchTypes();
    }
  }

  dispatchFetchRanges() {
    if (this.props.ranges.length == 0) {
      this.props.fetchRanges();
    }
  }

  handleSubmit(values) {
    var self = this;

    axios
      .post(host + 'api/dictionaries/points/save', values)
      .then(function(response) {
        self
          .props
          .history
          .goBack();
      })
      .catch(function(error) {
        self
          .props
          .history
          .push('/500');
        console.log(error);
      });
  }

  render() {

    const {point, fetching, error} = this.state;
    if (fetching)
      return <Spinner />
    if (error != null)
      return (
      this.props.history.push('/500')
      );

    return (
      <div className="animated fadeIn">
        <div className="row">
          <div className="col-12">
            <div className="card">
              <div className="card-header">
                <strong>Points</strong>
              </div>
              <div className="card-block">
                <ContestPointDataForm ranges={ this.props.ranges } types={ this.props.types } initialValues={ point } onSubmit={ this.onSubmit } />
              </div>
            </div>
          </div>
        </div>
      </div>
      );
  }
}

const mapStateToProps = (state, ownProps) => {
  return {
    types: state.ContestTypes.types,
    ranges: state.ContestRanges.ranges
  }
}

const mapDispatchToProps = (dispatch, ownProps) => {
  return {

    fetchTypes: () => {
      dispatch(fetchTypes())
    },

    fetchRanges: () => {
      dispatch(fetchRanges())
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(ContestPointsDetailsPage)