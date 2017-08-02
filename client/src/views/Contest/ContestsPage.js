import React, { Component } from 'react';
import { Table } from 'reactstrap'
import RemoveButton from '../Components/Buttons/RemoveButton'
import EditButton from '../Components/Buttons/EditButton'
import AddButton from '../Components/Buttons/AddButton'
import TablePage from '../Components/TablePage'
import { Link } from 'react-router-dom'

class ContestsPage extends Component {
  render() {

    const {contests} = this.props;

    const pageHeader = <div><strong>Contests</strong>
                         <div className="pull-right">
                           <AddButton click={ this.props.addContestClick } />
                         </div>
                       </div>;

    const headers = <tr>
                      <th className="col-md-1">
                        No.
                      </th>
                      <th className="col-md-10">
                        Contest name
                      </th>
                      <th className="col-md-1">
                        Action
                      </th>
                    </tr>

    const mappedContests = contests.map((contest, i) => <tr key={ i }>
                                                          <td>
                                                            { contest.id }
                                                          </td>
                                                          <td>
                                                            { contest.name }
                                                          </td>
                                                          <td>
                                                            <Link to={ "/contests/" + contest.id + "/edit" }>
                                                            <EditButton/>
                                                            </Link>
                                                            <RemoveButton/>
                                                          </td>
                                                        </tr>);

    return <TablePage pageHeader={ pageHeader } headers={ headers } content={ mappedContests } />
  }
}

export default ContestsPage;