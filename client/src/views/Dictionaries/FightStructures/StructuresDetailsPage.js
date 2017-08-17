import React, { Component } from 'react';
import { host } from "../../../global"
import { connect } from "react-redux"
import axios from "axios";
import LoadButton from "../../Components/Buttons/LoadButton";
import Spinner from "../../Components/Spinners/Spinner"
import StructuresDataForm from './StructuresDataForm'
import { fetchWeightCategories } from "../../../actions/Dictionaries/WeightCategoriesActions"
import { fetchRounds } from "../../../actions/Dictionaries/RoundsActions"
class StructuresDetailsPage extends Component {
  constructor(props) {
    super(props);
    this.onSubmit = this.handleSubmit.bind(this);
    this.fetchStructure = this.fetchStructure.bind(this);
    this.state = {
      fetching: true
    };

  }
  componentWillMount() {
    this.dispatchFetchWeightCategories();
    this.dispatchFetchRounds();
    this.fetchStructure(this.props.match.params.id);
  }

  fetchStructure(id) {
    this.setState();

    var self = this;
    axios
      .get(host + "api/dictionaries/structures/" + id)
      .then((response) => {
        self.setState({
          ...self.state,
          fetching: false,
          structure: response.data
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

  dispatchFetchWeightCategories() {
    if (this.props.categories.length == 0) {
      this.props.fetchWeightCategories();
    }
  }

  dispatchFetchRounds() {
    if (this.props.rounds.length == 0) {
      this.props.fetchRounds();
    }
  }

  handleSubmit(values) {
    var self = this;

    axios
      .post(host + 'api/dictionaries/structures/save', values)
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

    const {structure, fetching, error} = this.state;
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
                <strong>Fight structure</strong>
              </div>
              <div className="card-block">
                <StructuresDataForm rounds={ this.props.rounds } categories={ this.props.categories } initialValues={ structure } onSubmit={ this.onSubmit } />
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
    categories: state.WeightCategories.categories,
    rounds: state.Rounds.rounds
  }
}

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    fetchWeightCategories: () => {
      dispatch(fetchWeightCategories())
    },

    fetchRounds: () => {
      dispatch(fetchRounds())
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(StructuresDetailsPage)