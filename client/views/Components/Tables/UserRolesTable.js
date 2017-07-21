import React from 'react'

let UserRolesTable = (props) => {

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
                    <th>Username</th>
                    <th>Date registered</th>
                    <th>Role</th>
                    <th>Status</th>
                  </tr>
                </thead>
                <tbody></tbody>
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