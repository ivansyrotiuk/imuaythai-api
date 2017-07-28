import React, {Component} from 'react';
import {host} from "../../../global"
import {connect} from "react-redux"
import axios from "axios";
import LoadButton from "../../Components/Buttons/LoadButton";
import SimpleDictionaryDataForm from "../SimpleDictionaryDataForm";
import Spinner from "../../Components/Spinners/Spinner"


export default class ContestRangesDetailsPage extends Component {
  constructor(props) {
    super(props);
    this.onSubmit = this.handleSubmit.bind(this);
    this.fetchRange = this.fetchRange.bind(this);
    this.state = {fetching: true};
    this.fetchRange(this.props.match.params.id);

  }

  fetchRange(id) {
    this.setState();

    var self = this;
    axios
      .get(host + "api/dictionaries/ranges/"+id)
      .then((response) => {
        self.setState({...self.state, fetching: false, range: response.data});
      })
      .catch((err) => {
        self.setState({...self.state, fetching: false, error: err});
      })
  }

  handleSubmit(values) {
    var self = this;

    axios
      .post(host + 'api/dictionaries/ranges/save', values)
      .then(function (response) {
        self
          .props
          .history
          .goBack();
      })
      .catch(function (error) {
        self
          .props
          .history
          .push('/500');
        console.log(error);
      });
  }

  render() {

    const {range, fetching, error} = this.state;
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
                <strong>Range</strong>
              </div>
                                          <div className="card-block">
                <SimpleDictionaryDataForm initialValues={range} onSubmit={this.onSubmit}/>
            </div>
             </div>
          </div>
        </div>
      </div>
    );
  }
}