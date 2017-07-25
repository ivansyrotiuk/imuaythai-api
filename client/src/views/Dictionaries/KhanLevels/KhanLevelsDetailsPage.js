import React, {Component} from 'react';
import {host} from "../../../global"
import {connect} from "react-redux"
import axios from "axios";
import LoadButton from "../../Components/Buttons/LoadButton";
import KhanLevelDataForm from "./KhanLevelDataForm";
import Spinner from "../../Components/Spinners/Spinner"


export default class KhanLevelsDetailsPage extends Component {
  constructor(props) {
    super(props);
    this.onSubmit = this.handleSubmit.bind(this);
    this.fetchLevel = this.fetchLevel.bind(this);
    this.state = {fetching: true};
    this.fetchLevel(this.props.match.params.id);

  }

  fetchLevel(id) {
    this.setState();

    var self = this;
    axios
      .get(host + "api/dictionaries/levels/"+id)
      .then((response) => {
        self.setState({...self.state, fetching: false, level: response.data});
      })
      .catch((err) => {
        self.setState({...self.state, fetching: false, error: err});
      })
  }

  handleSubmit(values) {
    var self = this;

    axios
      .post(host + 'api/dictionaries/levels/save', values)
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

    const {level, fetching, error} = this.state;
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
                <strong>Khan level</strong>
              </div>
              <div className="card-block">
                <KhanLevelDataForm initialValues={level} onSubmit={this.onSubmit}/>
            </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}