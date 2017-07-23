import React from 'react'

let RolesRequestsTable = (props) => {

    const mappedUserRoles = props.roleRequests.map((request, i) => <tr key={ i }>
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
                                                                         { request.accepting ? <i class="fa fa-spinner fa-pulse fa-1x fa-fw"></i> : <i class="fa fa-thumbs-o-up" aria-hidden="true"></i> }
                                                                       </button>
                                                                     </td>
                                                                     <td>
                                                                       <button className="btn btn-danger" onClick={ () => props.rejectClick(request) }>
                                                                         { request.rejecting ? <i class="fa fa-spinner fa-pulse fa-1x fa-fw"></i> :  <i class="fa fa-thumbs-o-down" aria-hidden="true"></i> }
                                                                        </button>
                                                                     </td>
                                                                   </tr>);

    return (
        <div className="animated fadeIn">
          <div className="row">
            <div className="col-lg-12">
              <div className="card">
                <div className="card-header">
                  <i className="fa fa-align-justify"></i> Roles statuses
                </div>
                <div className="card-block">
                  <table className="table table-bordered table-striped table-sm">
                    <thead>
                      <tr>
                        <th>User</th>
                        <th>Role</th>
                        <th>Status</th>
                        <th>Accept</th>
                        <th>Reject</th>
                      </tr>
                    </thead>
                    <tbody>
                      { mappedUserRoles }
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
          </div>
        </div>
    )
}

export default RolesRequestsTable;