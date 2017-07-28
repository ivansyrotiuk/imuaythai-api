import React from 'react'

export const TablePage = (props) => {
    const colsCount = props.colsCount === undefined ? "col-12" : props.colsCount;
    return (
        <div className="animated fadeIn">
          <div className="row">
            <div className={ colsCount }>
              <div className="card">
                <div className="card-header">
                  <strong>{ props.caption }</strong>
                </div>
                <div className="card-block">
                  <table className="table">
                    <thead>
                      { props.headers }
                    </thead>
                    <tbody>
                      { props.content }
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
          </div>
        </div>
    )
}

export default TablePage