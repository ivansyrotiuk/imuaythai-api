import React, { Component } from 'react';
import { host } from "../../../global"
import { fetchRounds, deleteRound } from "../../../actions/Dictionaries/RoundsActions"
import RemoveButton from "../../Components/Buttons/RemoveButton"
import EditButton from "../../Components/Buttons/EditButton"
import AddButton from "../../Components/Buttons/AddButton"
import { Link } from 'react-router-dom'
import { connect } from "react-redux"
import axios from "axios";
import Spinner from "../../Components/Spinners/Spinner"

class RoundsPage extends Component {
    constructor(props) {
        super(props);
        this.props.fetchRounds();
    }

    removeRound(id) {
        var self = this;
        axios
            .post(host + 'api/dictionaries/rounds/remove', {
                Id: id
            })
            .then(function(response) {
                self.props.deleteRound(response.data)
            })
            .catch(function(error) {
                console.log(error);
            });
    }

    render() {

        const {rounds, fetching} = this.props;
        if (fetching) {
            return <Spinner />
        }
        const mappedRounds = rounds.map((round, i) => <tr key={ i }>
                                                        <td>
                                                          { round.id }
                                                        </td>
                                                        <td>
                                                          { round.name }
                                                        </td>
                                                        <td>
                                                          { round.duration } s
                                                        </td>
                                                        <td>
                                                          { round.roundsCount }
                                                        </td>
                                                        <td>
                                                          { round.breakDuration } s
                                                        </td>
                                                        <td>
                                                          <Link to={ "/dictionaries/rounds/" + round.id }>
                                                          <EditButton id={ round.id } />
                                                          </Link>
                                                          <RemoveButton id={ round.id } click={ this.removeRound.bind(this, round.id) } />
                                                        </td>
                                                      </tr>);


        return (

            <div className="animated fadeIn">
              <div className="row">
                <div className="col-12">
                  <div className="card">
                    <div className="card-header">
                      <strong>Rounds</strong>
                      <div className="pull-right">
                        <Link to={ "/dictionaries/rounds/new" }>
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
                            <th>Round duration</th>
                            <th>Rounds count</th>
                            <th>Break duration</th>
                            <th>Action</th>
                          </tr>
                        </thead>
                        <tbody>
                          { mappedRounds }
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
        rounds: state.Rounds.rounds,
        fetching: state.Rounds.fetching,
        fetched: state.Rounds.fetched
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchRounds: () => {
            dispatch(fetchRounds())
        },

        deleteRound: (id) => {
            dispatch(deleteRound(id))
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(RoundsPage)