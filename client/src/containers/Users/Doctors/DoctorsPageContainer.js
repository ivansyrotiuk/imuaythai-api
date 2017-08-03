import React, { Component } from 'react';
import { Link } from 'react-router-dom'
import { connect } from "react-redux"
import UserAvatar from 'react-user-avatar'
import RemoveButton from "../../../views/Components/Buttons/RemoveButton"
import EditButton from "../../../views/Components/Buttons/EditButton"
import PreviewButton from "../../../views/Components/Buttons/PreviewButton"
import Spinner from "../../../views/Components/Spinners/Spinner"
import TablePage from "../../../views/Components/TablePage"
import { fetchDoctors, deleteUser } from "../../../actions/UsersActions"

class DoctorsPageContainer extends Component {
  componentWillMount() {
    this.props.fetchDoctors();
  }

  render() {
    const {doctors, fetching} = this.props;

    if (fetching) {
      return <Spinner />
    }

    const mappedDoctors = doctors.map((doctor, i) => <tr key={ i }>
                                                       <td className="col-md-1">
                                                         <UserAvatar size="40" name={ doctor.firstname + ' ' + doctor.surname } />
                                                       </td>
                                                       <td className="col-md-7">
                                                         { doctor.firstname + ' ' + doctor.surname }
                                                       </td>
                                                       <td className="col-md-2">
                                                         { doctor.countryName }
                                                       </td>
                                                       <td className="col-md-2">
                                                         <Link to={ "/users/" + doctor.id }>
                                                         <PreviewButton id={ doctor.id } />
                                                         </Link>
                                                         <Link to={ "/users/" + doctor.id + "/edit" }>
                                                         <EditButton id={ doctor.id } />
                                                         </Link>
                                                         <RemoveButton id={ doctor.id } click={ this.props.deleteUser.bind(this, doctor.id) } />
                                                       </td>
                                                     </tr>);

    const headers = <tr>
                      <th></th>
                      <th>Name</th>
                      <th>Country</th>
                      <th>Action</th>
                    </tr>;



    return <TablePage caption="Doctors" headers={ headers } content={ mappedDoctors } />;
  }
}

const mapStateToProps = (state, ownProps) => {
  return {
    doctors: state.Users.doctors,
    fetching: state.Users.fetching,
    fetched: state.Users.fetched
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    fetchDoctors: () => {
      dispatch(fetchDoctors());
    },
    deleteUser: (id) => {
      dispatch(deleteUser(id));
    }
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(DoctorsPageContainer);