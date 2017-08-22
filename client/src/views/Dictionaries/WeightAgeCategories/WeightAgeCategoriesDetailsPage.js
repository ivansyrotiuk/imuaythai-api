import React, { Component } from 'react';
import { host } from "../../../global"
import { connect } from "react-redux"
import axios from "axios";
import LoadButton from "../../Components/Buttons/LoadButton";
import Spinner from "../../Components/Spinners/Spinner"
import WeightCategoriesDataForm from './WeightCategoriesDataForm'

class WeightAgeCategoriesDetailsPage extends Component {
  constructor(props) {
    super(props);
    this.onSubmit = this.handleSubmit.bind(this);
    this.fetchWeightCategory = this.fetchWeightCategory.bind(this);
    this.state = {
      fetching: true
    };

  }
  componentWillMount() {
    this.fetchWeightCategory(this.props.match.params.id);
  }

  fetchWeightCategory(id) {
    this.setState();

    var self = this;
    axios
      .get(host + "api/dictionaries/weightcategories/" + id)
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
      .post(host + 'api/dictionaries/weightcategories/save', values)
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
                <strong>Weight category</strong>
              </div>
              <div className="card-block">
                <WeightCategoriesDataForm initialValues={ category } onSubmit={ this.onSubmit } />
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

  }
}

const mapDispatchToProps = (dispatch, ownProps) => {
  return {

  }
}

export default connect(mapStateToProps, mapDispatchToProps)(WeightAgeCategoriesDetailsPage)