import React, { Component } from 'react';
import { host } from "../../global"
import { saveGym, fetchGyms, deleteGym } from "../../actions/GymsActions"
import { connect } from "react-redux"
import axios from "axios";
import CommonGymDataForm from "./Forms/CommonGymDataForm"

@connect((store) => {
  return { gyms: store.Gyms.gyms, fetching: store.Gyms.fetching, fetched: store.Gyms.fetched };
})
export default class GymDetailsPage extends Component {
  constructor(props) {
    super(props);
    this.onSubmit = this
      .handleSubmit
      .bind(this);
  }

  saveGym(gym) {
    this
      .props
      .dispatch(saveGym(gym))
  }

  deleteGym(id) {
    this
      .props
      .dispatch(deleteGym(id))
  }

  handleSubmit(e) {
    e.preventDefault();
    var self = this;

    axios
      .post(host + 'api/gyms/save', {
        Id: this.refs.id.value,
        Name: this.refs.name.value
      })
      .then(function (response) {
        self.saveGym(response.data)
      })
      .catch(function (error) {
        console.log(error);
      });
  }

  removeGym(id) {
    var self = this;
    axios
      .post(host + 'api/gyms/remove', { Id: id })
      .then(function (response) {
        self.deleteGym(response.data)
      })
      .catch(function (error) {
        console.log(error);
      });
  }

  render() {

    const { gyms, fetching } = this.props;

    return (
      <div className="animated fadeIn">
        <div className="row">
          <div className="col-12">
            <div className="card">
              <div className="card-header">
                <strong>Gym</strong>
              </div>
              <div className="card-block">
                <CommonGymDataForm initialValues={this.props.gym} onSubmit={this.onSubmit} />


              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}