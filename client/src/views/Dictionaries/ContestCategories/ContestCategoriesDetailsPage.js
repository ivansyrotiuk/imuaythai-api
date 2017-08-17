import React, { Component } from 'react';
import { host } from "../../../global"
import { connect } from "react-redux"
import axios from "axios";
import LoadButton from "../../Components/Buttons/LoadButton";
import Spinner from "../../Components/Spinners/Spinner"
import ContestCategoriesDataForm from './ContestCategoriesDataForm'
import { fetchPoints } from "../../../actions/Dictionaries/ContestPointsActions"
import { fetchStructures } from "../../../actions/Dictionaries/StructuresActions"

class ContestCategoriesDetailsPage extends Component {
  constructor(props) {
    super(props);
    this.onSubmit = this.handleSubmit.bind(this);
    this.fetchContestCategory = this.fetchContestCategory.bind(this);
    this.state = {
      fetching: true
    };

  }
  componentWillMount() {
    this.dispatchFetchContestPoints();
    this.dispatchFetchStructures();
    this.fetchContestCategory(this.props.match.params.id);
  }
  dispatchFetchContestPoints() {
    if (this.props.points.length == 0) {
      this.props.fetchPoints();
    }
  }

  dispatchFetchStructures() {
    if (this.props.structures.length == 0) {
      this.props.fetchStructures();
    }
  }
  fetchContestCategory(id) {
    this.setState();

    var self = this;
    axios
      .get(host + "api/dictionaries/categories/" + id)
      .then((response) => {
        self.setState({
          ...self.state,
          fetching: false,
          category: response.data
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

  handleSubmit(values) {
    var self = this;

    axios
      .post(host + 'api/dictionaries/categories/save', values)
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

    const {category, fetching, error} = this.state;
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
                <strong>Contest category</strong>
              </div>
              <div className="card-block">
                <ContestCategoriesDataForm initialValues={ category } points={ this.props.points } structures={ this.props.structures } onSubmit={ this.onSubmit } />
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
    points: state.ContestPoints.points,
    structures: state.Structures.structures
  }
}

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    fetchPoints: () => {
      dispatch(fetchPoints())
    },

    fetchStructures: () => {
      dispatch(fetchStructures())
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(ContestCategoriesDetailsPage)