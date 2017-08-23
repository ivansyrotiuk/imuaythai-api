import React, { Component } from 'react';
import ActionButtonGroup from "../../../views/Components/Buttons/ActionButtonGroup"
import AddButton from "../../../views/Components/Buttons/AddButton"
import Spinner from "../../../views/Components/Spinners/Spinner"
import TablePage from "../../../views/Components/TablePage"
import { Link } from 'react-router-dom'
import { connect } from "react-redux"
import { fetchNationalFederations, deleteInstitution } from "../../../actions/InstitutionsActions"


class NationalFederationsPageContainer extends Component {
  constructor(props) {
    super(props);
    this.addFederation = this.addFederation.bind(this);
  }

  componentWillMount() {
    this.props.fetchFederations();
  }

  addFederation() {
    this.props.history.push('/institutions/national/add');
  }

  render() {
    const {federations, fetching} = this.props;


    if (fetching) {
      return <Spinner />
    }

    const pageHeader = <div><strong>National federations</strong>
                         <div className="pull-right">
                           <AddButton click={ this.addFederation } tip={ "Add federation" } />
                         </div>
                       </div>;

    const mappedFederations = federations.map((federation, i) => <tr key={ i }>
                                                                   <td>
                                                                     <Link to={ "/institutions/national/" + federation.id }>
                                                                     { federation.id }
                                                                     </Link>
                                                                   </td>
                                                                   <td>
                                                                     { federation.name }
                                                                   </td>
                                                                   <td>
                                                                     <ActionButtonGroup previewClick={ () => this.props.history.push("/institutions/national/" + federation.id) } editClick={ () => this.props.history.push("/institutions/national/edit/" + federation.id) } deleteClick={ this.props.deleteFederation.bind(this, federation.id) } />
                                                                   </td>
                                                                 </tr>);

    const headers = <tr>
                      <th className="col-1">Id</th>
                      <th className="col-8">Name</th>
                      <th className="col-3 text-center">Action</th>
                    </tr>

    return <TablePage pageHeader={ pageHeader } headers={ headers } content={ mappedFederations } />;
  }
}


const mapStateToProps = (state, ownProps) => {
  return {
    federations: state.Institutions.nationalFederations,
    fetching: state.Institutions.fetching,
    fetched: state.Institutions.fetched
  }
}

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    fetchFederations: () => {
      dispatch(fetchNationalFederations())
    },
    deleteFederation: (id) => {
      return dispatch(deleteInstitution(id));
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(NationalFederationsPageContainer)