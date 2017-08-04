import React, { Component } from 'react';
import RemoveButton from "../../../views/Components/Buttons/RemoveButton"
import EditButton from "../../../views/Components/Buttons/EditButton"
import AddButton from "../../../views/Components/Buttons/AddButton"
import PreviewButton from "../../../views/Components/Buttons/PreviewButton"
import Spinner from "../../../views/Components/Spinners/Spinner"
import TablePage from "../../../views/Components/TablePage"
import { Link } from 'react-router-dom'
import { connect } from "react-redux"
import { fetchContinentalFederations, deleteInstitution } from "../../../actions/InstitutionsActions"

class ContinentalFederationsPageContainer extends Component {
  constructor(props) {
    super(props);
    this.addFederation = this.addFederation.bind(this);
  }

  componentWillMount() {
    this.props.fetchFederations();
  }

  addFederation() {
    this.props.history.push('/institutions/continental/add');
  }

  render() {
    const {federations, fetching} = this.props;

    if (fetching) {
      return <Spinner />
    }

    const pageHeader = <div><strong>Continental federations</strong>
                         <div className="pull-right">
                           <AddButton click={ this.addFederation } tip={ "Add Federation" } />
                         </div>
                       </div>;

    const mappedFederations = federations.map((federation, i) => <tr key={ i }>
                                                                   <td>
                                                                     <Link to={ "/institutions/continental/" + federation.id }>
                                                                     { federation.id }
                                                                     </Link>
                                                                   </td>
                                                                   <td>
                                                                     { federation.name }
                                                                   </td>
                                                                   <td>Europe</td>
                                                                   <td>
                                                                     <div className="row">
                                                                       <div className="col-4">
                                                                         <Link to={ "/institutions/continental/" + federation.id }>
                                                                         <PreviewButton id={ federation.id } />
                                                                         </Link>
                                                                       </div>
                                                                       <div className="col-4">
                                                                         <Link to={ "/institutions/continental/edit/" + federation.id }>
                                                                         <EditButton id={ federation.id } />
                                                                         </Link>
                                                                       </div>
                                                                       <div className="col-4">
                                                                         <RemoveButton id={ federation.id } click={ this.props.deleteFederation.bind(this, federation.id) } />
                                                                       </div>
                                                                     </div>
                                                                   </td>
                                                                 </tr>);

    const headers = <tr>
                      <th className="col-1">Id</th>
                      <th className="col-5">Name</th>
                      <th className="col-3">Continent</th>
                      <th className="col-2 text-center">Actions</th>
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

export default connect(mapStateToProps, mapDispatchToProps)(ContinentalFederationsPageContainer)