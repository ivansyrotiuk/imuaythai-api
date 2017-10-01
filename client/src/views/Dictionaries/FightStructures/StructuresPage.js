import React, { Component } from 'react';
import { host } from "../../../global"
import { fetchStructures, deleteStructure } from "../../../actions/Dictionaries/StructuresActions"
import RemoveButton from "../../Components/Buttons/RemoveButton"
import EditButton from "../../Components/Buttons/EditButton"
import AddButton from "../../Components/Buttons/AddButton"
import { Link } from 'react-router-dom'
import { connect } from "react-redux"
import axios from "axios";
import Spinner from "../../Components/Spinners/Spinner"

class StructuresPage extends Component {
    constructor(props) {
        super(props);
        this.props.fetchStructures();
    }

    removeStructure(id) {
        var self = this;
        axios
            .post(host + 'api/dictionaries/structures/remove', {
                Id: id
            })
            .then(function(response) {
                self.props.deleteStructure(response.data)
            })
            .catch(function(error) {
                console.log(error);
            });
    }

    render() {

        const {structures, fetching} = this.props;
        if (fetching) {
            return <Spinner />
        }
        const mappedStructures = structures.map((structure, i) => <tr key={ i }>
                                                                    <td>
                                                                      { structure.id }
                                                                    </td>
                                                                    <td>
                                                                      { structure.weightAgeCategory.name }
                                                                    </td>
                                                                    <td>
                                                                      { structure.round.name }
                                                                    </td>
                                                                    <td>
                                                                      <Link to={ "/dictionaries/structures/" + structure.id }>
                                                                      <EditButton id={ structure.id } />
                                                                      </Link>
                                                                      <RemoveButton id={ structure.id } click={ this.removeStructure.bind(this, structure.id) } />
                                                                    </td>
                                                                  </tr>);


        return (

            <div className="animated fadeIn">
              <div className="row">
                <div className="col-12">
                  <div className="card">
                    <div className="card-header">
                      <strong>Fight structures</strong>
                      <div className="pull-right">
                        <Link to={ "/dictionaries/structures/new" }>
                        <AddButton/>
                        </Link>
                      </div>
                    </div>
                    <div className="card-block">
                      <table className="table">
                        <thead>
                          <tr>
                            <th>Id</th>
                            <th className="col-md-9">Weight category</th>
                            <th>Round type</th>
                            <th>Action</th>
                          </tr>
                        </thead>
                        <tbody>
                          { mappedStructures }
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
        structures: state.Structures.structures,
        fetching: state.Structures.fetching,
        fetched: state.Structures.fetched
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchStructures: () => {
            dispatch(fetchStructures())
        },

        deleteStructure: (id) => {
            dispatch(deleteStructure(id))
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(StructuresPage)