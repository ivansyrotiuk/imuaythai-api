import React, { Component } from 'react';
import { host } from "../../../global"
import { saveRange, fetchRanges, deleteRange } from "../../../actions/Dictionaries/ContestRangesActions"
import RemoveButton from "../../Components/Buttons/RemoveButton"
import EditButton from "../../Components/Buttons/EditButton"
import AddButton from "../../Components/Buttons/AddButton"
import { Link } from 'react-router-dom'
import { connect } from "react-redux"
import axios from "axios";
import Spinner from "../../Components/Spinners/Spinner"

class ContestRangesPage extends Component {
    constructor(props) {
        super(props);
        this.props.fetchRanges();
    }



    removeRange(id) {
        var self = this;
        axios
            .post(host + 'api/dictionaries/ranges/remove', {
                Id: id
            })
            .then(function(response) {
                self.props.deleteRange(response.data)
            })
            .catch(function(error) {
                console.log(error);
            });
    }

    render() {

        const {ranges, fetching} = this.props;
        if (fetching) {
            return <Spinner />
        }
        const mappedRanges = ranges.map((range, i) => <tr key={ i }>
                                                        <td>
                                                          { range.id }
                                                        </td>
                                                        <td>
                                                          { range.name }
                                                        </td>
                                                        <td>
                                                          <Link to={ "/dictionaries/ranges/" + range.id }>
                                                          <EditButton id={ range.id } />
                                                          </Link>
                                                          <RemoveButton id={ range.id } click={ this.removeRange.bind(this, range.id) } />
                                                        </td>
                                                      </tr>);


        return (

            <div className="animated fadeIn">
              <div className="row">
                <div className="col-12">
                  <div className="card">
                    <div className="card-header">
                      <strong>Ranges</strong>
                      <div className="pull-right">
                        <Link to={ "/dictionaries/ranges/new" }>
                        <AddButton/>
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
                          { mappedRanges }
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
        ranges: state.ContestRanges.ranges,
        fetching: state.ContestRanges.fetching,
        fetched: state.ContestRanges.fetched
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchRanges: () => {
            dispatch(fetchRanges())
        },
        deleteRange: (id) => {
            dispatch(deleteRange(id))
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(ContestRangesPage)