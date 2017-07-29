import React, { Component } from 'react';
import RemoveButton from "../Components/Buttons/RemoveButton"
import EditButton from "../Components/Buttons/EditButton"
import AddButton from "../Components/Buttons/AddButton"
import Spinner from "../Components/Spinners/Spinner"
import TablePage from "../Components/TablePage"
import { Link } from 'react-router-dom'
import { connect } from "react-redux"
import { fetchContinentalFederations, deleteInstitution } from "../../actions/InstitutionsActions"

class ContinentalFederationsPage extends Component {
  constructor(props) {
    super(props);
    this.addFederation = this.addFederation.bind(this);
  }

  componentWillMount() {
    this.props.fetchFederations();
  }

  addFederation() {
    this.props.history.push('/institutions/add/continental');
  }

  render() {
    const {federations, fetching} = this.props;

    if (fetching) {
      return <Spinner />
    }

    const pageHeader = <div><strong>Continental federations</strong>
                         <div className="pull-right">
                           <AddButton click={ this.addFederation } />
                         </div>
                       </div>;

    const mappedFederations = federations.map((federation, i) => <tr key={ i }>
                                                                   <td>
                                                                     { federation.id }
                                                                   </td>
                                                                   <td>
                                                                     { federation.name }
                                                                   </td>
                                                                   <td>
                                                                     <Link to={ "/institutions/" + federation.id }>
                                                                     <EditButton id={ federation.id } />
                                                                     </Link>
                                                                     <RemoveButton id={ federation.id } click={ this.props.deleteFederation.bind(this, federation.id) } />
                                                                   </td>
                                                                 </tr>);

    const headers = <tr>
                      <th>Id</th>
                      <th className="col-10">Name</th>
                      <th>Action</th>
                    </tr>

    return <TablePage pageHeader={ pageHeader } headers={ headers } content={ mappedFederations } />;
  }
}


const mapStateToProps = (state, ownProps) => {
  return {
    federations: state.Institutions.continentalFederations,
    fetching: state.Institutions.fetching,
    fetched: state.Institutions.fetched
  }
}

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    fetchFederations: () => {
      dispatch(fetchContinentalFederations())
    },
    deleteFederation: (id) => {
      return dispatch(deleteInstitution(id));
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(ContinentalFederationsPage)