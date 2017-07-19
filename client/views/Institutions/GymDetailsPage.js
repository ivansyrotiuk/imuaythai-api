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
    this.onSubmit = this.handleSubmit.bind(this);
    this.dispatchFetchGym = this.dispatchFetchGym.bind(this);
    this.state = { fetching: true };
  }

     componentWillMount() {
        this.dispatchFetchGym();
    }

    dispatchFetchGym() {
        const gymId = this.props.match.params.id;

        var self = this;
      
        axios
            .get(host + "api/gyms/gym/" + gymId)
            .then((response) => {
                self.setState({...self.state, fetching: false, gym: response.data});
            })
            .catch((err) => {
                self.setState({...self.state, fetching: false, error: err});
            });
    }


    dispatchSaveGym(gym) {
        this.props.dispatch(saveGym(gym))
    }

    handleSubmit(values) {
        var self = this;

        axios
            .post(host + 'api/gyms/save', values)
            .then(function (response) {
                self.dispatchSaveGym(response.data)
            })
            .catch(function (error) {
                self.props.history.push('/500');
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
                <CommonGymDataForm initialValues={this.state.gym} onSubmit={this.onSubmit} />


              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}