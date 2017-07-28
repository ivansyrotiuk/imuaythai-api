import React, { Component } from 'react';
import { Link } from 'react-router-dom'
import { connect } from "react-redux"
import UserAvatar from 'react-user-avatar'
import RemoveButton from "../../Components/Buttons/RemoveButton"
import EditButton from "../../Components/Buttons/EditButton"
import PreviewButton from "../../Components/Buttons/PreviewButton"
import Spinner from "../../Components/Spinners/Spinner"
import TablePage from "../../Components/TablePage"
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
    const headers = <tr>
                      <th></th>
                      <th>Name</th>
                      <th>Country</th>
                      <th>Action</th>
                    </tr>;


    return <TablePage caption="Coaches" headers={ headers } content={ mappedCoaches } />;
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