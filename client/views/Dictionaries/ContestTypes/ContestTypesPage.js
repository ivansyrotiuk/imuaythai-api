import React, {Component} from 'react';
import {host} from "../../../global"
import {saveType, fetchTypes, deleteType} from "../../../actions/Dictionaries/ContestTypesActions"
import RemoveButton from "../../Components/Buttons/RemoveButton"
import EditButton from "../../Components/Buttons/EditButton"
import { Link } from 'react-router-dom'
import {connect} from "react-redux"
import axios from "axios";

@connect((store) => {
  return {types: store.ContestTypes.types, fetching: store.ContestTypes.fetching, fetched: store.ContestTypes.fetched};
})
export default class ContestTypesPage extends Component {
  constructor(props) {
    super(props);
    this.fetchTypes();
  }

  fetchTypes() {
    this
      .props
      .dispatch(fetchTypes())
  }

  deleteType(id) {
    this
      .props
      .dispatch(deleteType(id))
  }

  removeType(id) {
    var self = this;
    axios
      .post(host + 'api/contest/types/remove', {Id: id})
      .then(function (response) {
        self.deleteType(response.data)
      })
      .catch(function (error) {
        console.log(error);
      });
  }

  render() {

    const {types, fetching} = this.props;
    const mappedTypes = types.map((type, i) => <tr key={i}>
      <td>{type.id}</td>
      <td>{type.name}</td>
      <td>
        <Link to={"/contest/types/" + type.id} ><EditButton id={type.id}/></Link>&nbsp;
        <RemoveButton id={type.id} click={this.removeType.bind(this, type.id)}/>
      </td>
    </tr>);

    return (
        <div className="animated fadeIn">
          <div className="row">
            <div className="col-12">
              <div className="card">
                <div className="card-header">
                  <strong>Types</strong>
                  <div class="pull-right">
                  <Link to={"/contest/types/new"} ><button type="button" className="btn btn-primary">Create</button></Link>
                  </div>
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
                      {mappedTypes}
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