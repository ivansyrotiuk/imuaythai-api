import React, { Component } from 'react';
import { Link } from 'react-router-dom'
import { connect } from "react-redux"
import UserAvatar from 'react-user-avatar'
import RemoveButton from "../../Components/Buttons/RemoveButton"
import EditButton from "../../Components/Buttons/EditButton"
import PreviewButton from "../../Components/Buttons/PreviewButton"
import Spinner from "../../Components/Spinners/Spinner"
import { fetchCoaches, deleteUser } from "../../../actions/UsersActions"

class CoachesPage extends Component {
  componentWillMount() {
    this.props.fetchCoaches();
  }

  render() {
    const {coaches, fetching} = this.props;

    if (fetching) {
      return <Spinner />
    }

    const mappedCoaches = coaches.map((coach, i) => <tr key={ i }>
                                                          <td className="col-md-1">
                                                            <UserAvatar size="40" name={ coach.firstname + ' ' + coach.surname } />
                                                          </td>
                                                          <td className="col-md-7">
                                                            { coach.firstname + ' ' + coach.surname }
                                                          </td>
                                                          <td className="col-md-2">
                                                            { coach.countryName }
                                                          </td>
                                                          <td className="col-md-2">
                                                            <Link to={ "/users/" + coach.id }>
                                                            <PreviewButton id={ coach.id } />
                                                            </Link>
                                                            <Link to={ "/users/" + coach.id + "/edit" }>
                                                            <EditButton id={ coach.id } />
                                                            </Link>
                                                            <RemoveButton id={ coach.id } click={ this.props.deleteUser.bind(this, coach.id) } />
                                                          </td>
                                                        </tr>);

    return (
      <div className="animated fadeIn">
        <div className="row">
          <div className="col-12">
            <div className="card">
              <div className="card-header">
                <strong>Coaches</strong>
              </div>
              <div className="card-block">
                <table className="table">
                  <thead>
                    <tr>
                      <th></th>
                      <th>Name</th>
                      <th>Country</th>
                      <th>Action</th>
                    </tr>
                  </thead>
                  <tbody>
                    { mappedCoaches }
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
    coaches: state.Users.coaches,
    fetching: state.Users.fetching,
    fetched: state.Users.fetched
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    fetchCoaches: () => {
      dispatch(fetchCoaches());
    },
    deleteUser: (id) => {
      dispatch(deleteUser(id));
    }
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(CoachesPage);