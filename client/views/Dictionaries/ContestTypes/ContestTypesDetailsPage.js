import React, {Component} from 'react';
import {host} from "../../../global"
import {saveType, fetchType, deleteType} from "../../../actions/Dictionaries/SingleContestTypeActions"
import {connect} from "react-redux"
import axios from "axios";
import LoadButton from "../../Components/Buttons/LoadButton";

@connect((store) => {
  return {fetching: store.ContestTypes.fetching, fetched: store.SingleContestType.fetched, type:store.SingleContestType.type};
})
export default class ContestTypesDetailsPage extends Component {
  constructor(props) {
    super(props);
/*    this.onSubmit = this
      .handleSubmit
      .bind(this);*/
      this.fetchType(this.props.match.params.id);
  }
fetchType(id) {
    this
      .props
      .dispatch(fetchType(id))
}

  saveType(type) {
    this
      .props
      .dispatch(saveType(type))
  }


  deleteType(id) {
    this
      .props
      .dispatch(deleteType(id))
  }

  handleSubmit(e) {
    e.preventDefault();
    var self = this;

    axios
      .post(host + 'api/contest/types/save', {
        Id: this.refs.id.value,
        Name: this.refs.name.value
      })
      .then(function (response) {
        self.saveType(response.data)
      })
      .catch(function (error) {
        console.log(error);
      });
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
handleNameChange(event) {
this.props.type.name = event.target.value;
}

  render() {

    const {type, fetching, fetched, error} = this.props;
    if(!fetched && type == undefined)
      return(<LoadButton text = "Loading" loading = {fetching}/>);
    if(error!=null)
      return (<h1>error</h1>);
    const name = type.name;
    const id = type.id;
    return (
        <div className="animated fadeIn">
          <div className="row">
            <div className="col-12">
              <div className="card">
                <div className="card-header">
                  <strong>Type</strong>
                </div>
                <div className="card-block">

                    <form action="" method="post" encType="multipart/form-data" className="form-horizontal"  onSubmit={this.onSubmit}>
                        <div className="form-group row">
                        <label className="col-md-3 form-control-label" htmlFor="text-input">Id</label>
                        <div className="col-md-9">
                            <input type="text" id="gymId" name="text-input" className="form-control" placeholder="Text" ref="id" />
                            <span className="help-block">The id of a contest type</span>
                        </div>
                        </div>
                        <div className="form-group row">
                        <label className="col-md-3 form-control-label" htmlFor="text-input">Name</label>
                        <div className="col-md-9">
                            <input
                            type="text"
                            id="gymName"
                            name="text-input"
                            className="form-control"
                            placeholder="Text"
                            ref="name"
                            value={name} 
                            onChange={this.handleNameChange.bind(this)} 
                            />
                            <span className="help-block">The name of a contest type</span>
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