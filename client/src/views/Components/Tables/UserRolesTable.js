import React from 'react'
import TablePage from "../TablePage"

const UserRolesTable = (props) => {

  const mappedUserRoles = props.userRoles.map((role, i) => <tr key={ i }>
                                                             <td>
                                                               { role.roleName }
                                                             </td>
                                                             <td>
                                                               { role.status === "Pending" && <span className="badge badge-warning">{ role.status }</span> }
                                                               { role.status === "Accepted" && <span className="badge badge-success">{ role.status }</span> }
                                                               { role.status === "Rejected" &&
                                                                 <div>
                                                                   <span className="badge badge-danger">{ role.status }</span>
                                                                   { props.userRoles.findIndex(r => r.roleId == role.roleId && r.status !== "Rejected") === -1 &&
                                                                     <button className="btn btn-xs btn-link pull-right" onClick={ () => props.requestRoleAgain(role) }>
                                                                       <i className="fa fa-repeat fa-lg text-success" aria-hidden="true"></i>
                                                                     </button> }
                                                                 </div> }
                                                             </td>
                                                             <td>
                                                               { role.acceptationDate }
                                                             </td>
                                                             <td>
                                                               { role.acceptedByUserName }
                                                             </td>
                                                           </tr>)
  const headers = <tr>
                    <th>Role</th>
                    <th>Status</th>
                    <th>Acceptation date</th>
                    <th>Accepted by</th>
                  </tr>;

  const footer = <button className="btn btn-primary pull-right" onClick={ props.addRole }>Add new role request</button>;

  return <TablePage caption="Roles statuses" headers={ headers } content={ mappedUserRoles } footer={ footer } />;
}

export default UserRolesTable;