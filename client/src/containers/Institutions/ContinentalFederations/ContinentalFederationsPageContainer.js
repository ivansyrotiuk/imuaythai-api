import React, { Component } from 'react';
import AddButton from "../../../views/Components/Buttons/AddButton"
import Spinner from "../../../views/Components/Spinners/Spinner"
import ActionButtonGroup from "../../../views/Components/Buttons/ActionButtonGroup"
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
                                                                     <ActionButtonGroup previewClick={ () => this.props.history.push("/institutions/continental/" + federation.id) } editClick={ () => this.props.history.push("/institutions/continental/edit/" + federation.id) } deleteClick={ this.props.deleteFederation.bind(this, federation.id) } />
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