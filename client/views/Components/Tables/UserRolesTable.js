import React from 'react'

let UserRolesTable = (props) => {

  const mappedUserRoles = props.userRoles.map((role, i) => <tr>
    <td>{role.roleName}</td>
    <td>
      {role.status === "Pending" && <span className="badge badge-warning">{role.status}</span>}
      {role.status === "Accepted" && <span className="badge badge-success">{role.status}</span>}
      {role.status === "Rejected" && <span className="badge badge-danger">{role.status}</span>}
    </td>
    <td>{role.acceptationDate}</td>
    <td>{role.acceptedByUserName}</td>
  </tr>)

  return (
    <div className="animated fadeIn">
      <div className="row">
        <div className="col-lg-12">
          <div className="card">
            <div className="card-header">
              <i className="fa fa-align-justify"></i>
              Roles statuses
            </div>
            <div className="card-block">
              <table className="table table-bordered table-striped table-sm">
                <thead>
                  <tr>
                    <th>Role</th>
                    <th>Status</th>
                    <th>Acceptation date</th>
                    <th>Accepted by</th>
                  </tr>
                </thead>
                <tbody>
                  {mappedUserRoles}
                </tbody>
              </table>
              <button className="btn btn-primary pull-right" onClick={props.addRoleClick}>Add new role request</button>
            </div>
          </div>

        </div>
      </div>
    </div>
  )
}

export default UserRolesTable;