import React, { Component } from 'react';
import { host } from "../../../global"
import { saveType, fetchTypes, deleteType } from "../../../actions/Dictionaries/ContestTypesActions"
import RemoveButton from "../../Components/Buttons/RemoveButton"
import EditButton from "../../Components/Buttons/EditButton"
import AddButton from "../../Components/Buttons/AddButton"
import { Link } from 'react-router-dom'
import { connect } from "react-redux"
import axios from "axios";
import Spinner from "../../Components/Spinners/Spinner"

class ContestTypesPage extends Component {
  constructor(props) {
    super(props);
    this.props.fetchTypes();
  }



  removeType(id) {
    var self = this;
    axios
      .post(host + 'api/dictionaries/types/remove', {
        Id: id
      })
      .then(function(response) {
        self.props.deleteType(response.data)
      })
      .catch(function(error) {
        console.log(error);
      });
  }


  render() {

    const {types, fetching} = this.props;
    if (fetching) {
      return <Spinner />
    }
    const mappedTypes = types.map((type, i) => <tr key={ i }>
                                                 <td>
                                                   { type.id }
                                                 </td>
                                                 <td>
                                                   { type.name }
                                                 </td>
                                                 <td>
                                                   <Link to={ "/dictionaries/types/" + type.id }>
                                                   <EditButton id={ type.id } />
                                                   </Link>
                                                   <RemoveButton id={ type.id } click={ this.removeType.bind(this, type.id) } />
                                                 </td>
                                               </tr>);



    return (

      <div className="animated fadeIn">
        <div className="row">
          <div className="col-12">
            <div className="card">
              <div className="card-header">
                <strong>Types</strong>
                <div className="pull-right">
                  <Link to={ "/dictionaries/types/new" }>
                  <AddButton />
                  </Link>
                </div>
              </div>
              <div className="card-block">
                <table className="table">
                  <thead>
                    <tr>
                      <th>Id</th>
                      <th className="col-md-9">Name</th>
                      <th>Action</th>
                    </tr>
                  </thead>
                  <tbody>
                    { mappedTypes }
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

const mapStateToProps = (state, ownProps) => {
  return {
    types: state.ContestTypes.types,
    fetching: state.ContestTypes.fetching,
    fetched: state.ContestTypes.fetched
  }
}

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    fetchTypes: () => {
      dispatch(fetchTypes())
    },
    deleteType: (id) => {
      dispatch(deleteType(id))
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(ContestTypesPage)