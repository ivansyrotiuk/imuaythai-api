import React, { Component } from 'react';
import { host } from "../../../global"
import { connect } from "react-redux"
import axios from "axios";
import LoadButton from "../../Components/Buttons/LoadButton";
import Spinner from "../../Components/Spinners/Spinner"
import RoundsDataForm from './RoundsDataForm'

class RoundsDetailsPage extends Component {
  constructor(props) {
    super(props);
    this.onSubmit = this.handleSubmit.bind(this);
    this.fetchRound = this.fetchRound.bind(this);
    this.state = {
      fetching: true
    };

  }
  componentWillMount() {
    this.fetchRound(this.props.match.params.id);
  }

  fetchRound(id) {
    this.setState();

    var self = this;
    axios
      .get(host + "api/dictionaries/rounds/" + id)
      .then((response) => {
        self.setState({
          ...self.state,
          fetching: false,
          round: response.data
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
      .post(host + 'api/dictionaries/rounds/save', values)
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

    const {round, fetching, error} = this.state;
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
                <strong>Round</strong>
              </div>
              <div className="card-block">
                <RoundsDataForm initialValues={ round } onSubmit={ this.onSubmit } />
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

export default connect(mapStateToProps, mapDispatchToProps)(RoundsDetailsPage)