import React, { Component } from 'react';
import RemoveButton from "../../../views/Components/Buttons/RemoveButton"
import EditButton from "../../../views/Components/Buttons/EditButton"
import AddButton from "../../../views/Components/Buttons/AddButton"
import Spinner from "../../../views/Components/Spinners/Spinner"
import TablePage from "../../../views/Components/TablePage"
import { Link } from 'react-router-dom'
import { connect } from "react-redux"
import { fetchWorldFederations, deleteInstitution } from "../../../actions/InstitutionsActions"
import ActionButtonGroup from "../../../views/Components/Buttons/ActionButtonGroup"

class WorldFederationsPageContainer extends Component {
  constructor(props) {
    super(props);
    this.addFederation = this.addFederation.bind(this);
  }

  componentWillMount() {
    this.props.fetchFederations();
  }
  addFederation() {
    this.props.history.push('/institutions/world/add');
  }

  render() {
    const {federations, fetching} = this.props;


    if (fetching) {
      return <Spinner />
    }

    const pageHeader = <div><strong>World federations</strong>
                         <div className="pull-right">
                           <AddButton click={ this.addFederation } tip={ "Add federation" } />
                         </div>
                       </div>;

    const mappedFederations = federations.map((federation, i) => <tr key={ i }>
                                                                   <td>
                                                                     <Link to={ "/institutions/world/" + federation.id }>
                                                                     { federation.id }
                                                                     </Link>
                                                                   </td>
                                                                   <td>
                                                                     { federation.name }
                                                                   </td>
                                                                   <td>
                                                                     <ActionButtonGroup previewClick={ () => this.props.history.push("/institutions/world/" + federation.id) } editClick={ () => this.props.history.push("/institutions/world/edit/" + federation.id) } deleteClick={ this.props.deleteFederation.bind(this, federation.id) } />
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
    federations: state.Institutions.worldFederations,
    fetching: state.Institutions.fetching,
    fetched: state.Institutions.fetched
  }
}

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    fetchFederations: () => {
      dispatch(fetchWorldFederations())
    },
    deleteFederation: (id) => {
      return dispatch(deleteInstitution(id));
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(WorldFederationsPageContainer)