import React from 'react'
import TablePage from "../TablePage"

let RolesRequestsTable = (props) => {

  const mapRequestToRow = (request, index) => {
    return <tr key={ index }>
             <td>
               { request.userName }
             </td>
             <td>
               { request.roleName }
             </td>
             <td>
               { request.status === "Pending" && <span className="badge badge-warning">{ request.status }</span> }
               { request.status === "Accepted" && <span className="badge badge-success">{ request.status }</span> }
               { request.status === "Rejected" && <span className="badge badge-danger">{ request.status }</span> }
             </td>
             <td>
               <button className="btn btn-primary" onClick={ () => props.acceptClick(request) }>
                 { request.accepting ? <i className="fa fa-spinner fa-pulse fa-1x fa-fw"></i> : <i className="fa fa-thumbs-o-up" aria-hidden="true"></i> }
               </button>
             </td>
             <td>
               <button className="btn btn-danger" onClick={ () => props.rejectClick(request) }>
                 { request.rejecting ? <i className="fa fa-spinner fa-pulse fa-1x fa-fw"></i> : <i className="fa fa-thumbs-o-down" aria-hidden="true"></i> }
               </button>
             </td>
           </tr>
  }


  const mappedUserRoles = props.roleRequests.map((request, i) => mapRequestToRow(request, i));

  const headers = <tr>
                    <th>User</th>
                    <th>Role</th>
                    <th>Status</th>
                    <th>Accept</th>
                    <th>Reject</th>
                  </tr>;

  return <TablePage caption="Roles statuses" headers={ headers } content={ mappedUserRoles } />;
}

export default RolesRequestsTable;