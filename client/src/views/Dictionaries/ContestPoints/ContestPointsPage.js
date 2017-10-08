import React, { Component } from 'react';
import { host } from "../../../global"
import { savePoint, fetchPoints, deletePoint } from "../../../actions/Dictionaries/ContestPointsActions"
import RemoveButton from "../../Components/Buttons/RemoveButton"
import EditButton from "../../Components/Buttons/EditButton"
import AddButton from "../../Components/Buttons/AddButton"
import { Link } from 'react-router-dom'
import { connect } from "react-redux"
import axios from "axios";
import Spinner from "../../Components/Spinners/Spinner"

class ContestPointsPage extends Component {
  constructor(props) {
    super(props);
    this.props.fetchPoints();
  }

  removePoint(id) {
    var self = this;
    axios
      .post(host + 'api/dictionaries/points/remove', {
        Id: id
      })
      .then(function(response) {
        self.props.deletePoint(response.data)
      })
      .catch(function(error) {
        console.log(error);
      });
  }

  render() {

    const {points, fetching} = this.props;
    if (fetching) {
      return <Spinner />
    }
    const mappedPoints = points.map((point, i) => <tr key={ i }>
                                                    <td>
                                                      { point.id }
                                                    </td>
                                                    <td>
                                                      { point.contestRange.name + ' ' + point.contestType.name }
                                                    </td>
                                                    <td>
                                                      { point.points }
                                                    </td>
                                                    <td>
                                                      <Link to={ "/dictionaries/points/" + point.id }>
                                                      <EditButton id={ point.id } />
                                                      </Link>
                                                      <RemoveButton id={ point.id } click={ this.removePoint.bind(this, point.id) } />
                                                    </td>
                                                  </tr>);


    return (

      <div className="animated fadeIn">
        <div className="row">
          <div className="col-12">
            <div className="card">
              <div className="card-header">
                <strong>Points</strong>
                <div className="pull-right">
                  <Link to={ "/dictionaries/points/new" }>
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
                      <th>Points</th>
                      <th>Action</th>
                    </tr>
                  </thead>
                  <tbody>
                    { mappedPoints }
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
    points: state.ContestPoints.points,
    fetching: state.ContestPoints.fetching,
    fetched: state.ContestPoints.fetched
  }
}

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    fetchPoints: () => {
      dispatch(fetchPoints())
    },

    deletePoint: (id) => {
      dispatch(deletePoint(id))
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(ContestPointsPage)