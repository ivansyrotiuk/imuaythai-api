import React, { Component } from 'react';
import RemoveButton from "../Components/Buttons/RemoveButton"
import EditButton from "../Components/Buttons/EditButton"
import Spinner from "../Components/Spinners/Spinner"
import TablePage from "../Components/TablePage"
import { Link } from 'react-router-dom'
import { connect } from "react-redux"
import { fetchGyms, deleteInstitution } from "../../actions/InstitutionsActions"

class GymsPage extends Component {

  componentWillMount() {
    this.props.fetchGyms();
  }

  render() {
    const {gyms, fetching} = this.props;


    if (fetching) {
      return <Spinner />
    }

    const mappedGyms = gyms.map((gym, i) => <tr key={ i }>
                                              <td>
                                                { gym.id }
                                              </td>
                                              <td>
                                                { gym.name }
                                              </td>
                                              <td>
                                                <Link to={ "/gyms/" + gym.id }>
                                                <EditButton id={ gym.id } />
                                                </Link>
                                                <RemoveButton id={ gym.id } click={ this.props.deleteGym.bind(this, gym.id) } />
                                              </td>
                                            </tr>);

    const headers = <tr>
                      <th>Id</th>
                      <th className="col-9">Name</th>
                      <th>Action</th>
                    </tr>

    return <TablePage caption="Gyms" headers={ headers } content={ mappedGyms } />;
  }
}


const mapStateToProps = (state, ownProps) => {
  return {
    gyms: state.Gyms.gyms,
    fetching: state.Gyms.fetching,
    fetched: state.Gyms.fetched
  }
}

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    fetchGyms: () => {
      dispatch(fetchGyms())
    },
    deleteGym: (id) => {
      return dispatch(deleteInstitution(id));
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(GymsPage)