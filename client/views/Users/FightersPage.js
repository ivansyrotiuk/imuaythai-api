import React, {Component} from 'react';
import {host} from "../../global"
import {fetchFighters, deleteFighter} from "../../actions/UsersActions"
import RemoveButton from "../Components/Buttons/RemoveButton"
import EditButton from "../Components/Buttons/EditButton"
import PreviewButton from "../Components/Buttons/PreviewButton"
import Spinner from "../Components/Spinners/Spinner"
import { Link } from 'react-router-dom'
import {connect} from "react-redux"
import axios from "axios";

@connect((store) => {
  return {fighters: store.Fighters.fighters, fetching: store.Fighters.fetching, fetched: store.Fighters.fetched};
})

export default class FightersPage extends Component {
  constructor(props) {
    super(props);
    this.dispatchFetchFighters();
  }

  dispatchFetchFighters() {
    this.props.dispatch(fetchFighters())
  }

  dispatchDeleteFighter(id) {
    this.props.dispatch(deleteFighter(id))
  }

  removeFighter(id) {
    var self = this;
    axios.post(host + 'api/users/remove', {Id: id})
      .then(function (response) {
        self.dispatchDeleteFighter(response.data)
      })
      .catch(function (error) {
        console.log(error);
      });
  }

  render() {
    const {fighters, fetching} = this.props;

    if (fetching){
      return <Spinner />
    }

    const mappedFighters = fighters.map((fighter, i) => 
      <tr key={i}>
        <td>{fighter.id}</td>
        <td>{fighter.firstname}</td>
        <td>{fighter.surname}</td>
        <td>
          <Link to={"/fighters/" + fighter.id} >
            <PreviewButton id={fighter.id}/>
          </Link>&nbsp;
          <Link to={"/fighters/" + fighter.id + "/edit"} >
            <EditButton id={fighter.id}/>
          </Link>&nbsp;
          <RemoveButton id={fighter.id} click={this.removeFighter.bind(this, fighter.id)}/>
        </td>
      </tr>);

    return (
        <div className="animated fadeIn">
          <div className="row">
            <div className="col-12">
              <div className="card">
                <div className="card-header">
                  <strong>Fighters</strong>
                </div>
                <div className="card-block">
                  <table className="table">
                    <thead>
                      <tr>
                        <th>Id</th>
                        <th>Firstname</th>
                        <th>Surname</th>
                        <th>Action</th>
                      </tr>
                    </thead>
                    <tbody>
                      {mappedFighters}
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