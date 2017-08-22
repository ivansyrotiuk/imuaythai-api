import React, { Component } from 'react';
import { host } from "../../../global"
import { saveType, fetchTypes, deleteType } from "../../../actions/Dictionaries/SuspensionTypesActions"
import RemoveButton from "../../Components/Buttons/RemoveButton"
import EditButton from "../../Components/Buttons/EditButton"
import { Link } from 'react-router-dom'
import { connect } from "react-redux"
import axios from "axios";
import Spinner from "../../Components/Spinners/Spinner"

class SuspensionTypesPage extends Component {
    constructor(props) {
        super(props);
        this.props.fetchTypes();
    }



    removeType(id) {
        var self = this;
        axios
            .post(host + 'api/dictionaries/suspensions/remove', {
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

        const {suspensionTypes, fetching} = this.props;
        if (fetching) {
            return <Spinner />
        }
        const mappedTypes = suspensionTypes.map((type, i) => <tr key={ i }>
                                                               <td>
                                                                 { type.id }
                                                               </td>
                                                               <td>
                                                                 { type.name }
                                                               </td>
                                                               <td>
                                                                 <Link to={ "/dictionaries/suspensions/" + type.id }>
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
                      <strong>Suspension types</strong>
                      <div className="pull-right">
                        <Link to={ "/dictionaries/suspensions/new" }><i className="fa fa-plus-square-o" aria-hidden="true"> Create</i></Link>
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
        suspensionTypes: state.SuspensionTypes.suspensionTypes,
        fetching: state.SuspensionTypes.fetching,
        fetched: state.SuspensionTypes.fetched
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

export default connect(mapStateToProps, mapDispatchToProps)(SuspensionTypesPage)
