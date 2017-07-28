import React, { Component } from 'react';
import { Table } from 'reactstrap'
import RemoveButton from '../Components/Buttons/RemoveButton'
import EditButton from '../Components/Buttons/EditButton'
import { Link } from 'react-router-dom'
class ContestsPage extends Component {
    render() {
        return (
            <div>
              <div className="row mb-2">
                <div className="col-md-4">
                  <h1> Contests</h1>
                </div>
                <div className="col-md-1 offset-md-7">
                  <Link to="/contests/add" className="btn btn-primary">Create</Link>
                </div>
              </div>
              <Table hover>
                <thead>
                  <tr>
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
                </thead>
                <tbody>
                  <tr>
                    <td>
                      1
                    </td>
                    <td>
                      test contest
                    </td>
                    <td>
                      <EditButton/>
                      <RemoveButton/>
                    </td>
                  </tr>
                  <tr>
                    <td>
                      2
                    </td>
                    <td>
                      test contest
                    </td>
                    <td>
                      <EditButton/>
                      <RemoveButton/>
                    </td>
                  </tr>
                  <tr>
                    <td>
                      3
                    </td>
                    <td>
                      test contest
                    </td>
                    <td>
                      <Link to="/contests/1/edit">
                      <EditButton/>
                      </Link>
                      <RemoveButton/>
                    </td>
                  </tr>
                </tbody>
              </Table>
            </div>
            );
    }
}

export default ContestsPage;