import React, {Component} from 'react';
import {host} from "../../global"
import {saveGym, fetchGyms, deleteGym} from "../../actions/GymsActions"
import {connect} from "react-redux"
import axios from "axios";

@connect((store) => {
  return {gyms: store.Gyms.gyms, fetching: store.Gyms.fetching, fetched: store.Gyms.fetched};
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
    
    return (
        <div className="animated fadeIn">
          <div className="row">
            <div className="col-12">
              <div className="card">
                <div className="card-header">
                  <strong>Gym</strong>
                </div>
                <div className="card-block">

                    <form action="" method="post" encType="multipart/form-data" className="form-horizontal"  onSubmit={this.onSubmit}>
                        <div className="form-group row">
                        <label className="col-md-3 form-control-label" htmlFor="text-input">Text Input</label>
                        <div className="col-md-9">
                            <input type="text" id="gymId" name="text-input" className="form-control" placeholder="Text" ref="id"/>
                            <span className="help-block">This is a help text</span>
                        </div>
                        </div>
                        <div className="form-group row">
                        <label className="col-md-3 form-control-label" htmlFor="text-input">Text Input</label>
                        <div className="col-md-9">
                            <input
                            type="text"
                            id="gymName"
                            name="text-input"
                            className="form-control"
                            placeholder="Text"
                            ref="name"/>
                            <span className="help-block">This is a help text</span>
                        </div>
                        </div>
                        <button type="button" type="submit" className="btn btn-primary">Save</button>
                    </form>

   
                </div>
              </div>
            </div>
          </div>
        </div>
    );
  }
}