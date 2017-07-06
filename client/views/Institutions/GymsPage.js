import React, {Component} from 'react';
import {host} from "../../global"
import {saveGym, fetchGyms, deleteGym} from "../../actions/GymsActions"
import RemoveButton from "./RemoveButton"
import EditButton from "./EditButton"
import { Link } from 'react-router-dom'
import {connect} from "react-redux"
import axios from "axios";

@connect((store) => {
  return {gyms: store.Gyms.gyms, fetching: store.Gyms.fetching, fetched: store.Gyms.fetched};
})
export default class GymsPage extends Component {
  constructor(props) {
    super(props);
    this.fetchGyms();
  }

  fetchGyms() {
    this
      .props
      .dispatch(fetchGyms())
  }

  deleteGym(id) {
    this
      .props
      .dispatch(deleteGym(id))
  }

  removeGym(id) {
    var self = this;
    axios
      .post(host + 'api/gyms/remove', {Id: id})
      .then(function (response) {
        self.deleteGym(response.data)
      })
      .catch(function (error) {
        console.log(error);
      });
  }

  render() {

    const {gyms, fetching} = this.props;
    const mappedGyms = gyms.map((gym, i) => <tr key={i}>
      <td>{gym.id}</td>
      <td>{gym.name}</td>
      <td>
        <Link to={"/gyms/" + gym.id} ><EditButton id={gym.id}/></Link>&nbsp;
        <RemoveButton id={gym.id} click={this.removeGym.bind(this, gym.id)}/>
      </td>
    </tr>);

    return (
        <div className="animated fadeIn">
          <div className="row">
            <div className="col-12">
              <div className="card">
                <div className="card-header">
                  <strong>Gyms</strong>
                </div>
                <div className="card-block">
                  <table className="table">
                    <thead>
                      <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Action</th>
                      </tr>
                    </thead>
                    <tbody>
                      {mappedGyms}
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
          </div>
        </div>
    );
  }
}