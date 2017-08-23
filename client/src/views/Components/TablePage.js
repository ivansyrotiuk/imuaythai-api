import React from 'react'
import Page from "./Page"

export const TablePage = (props) => {
  const colsCount = props.colsCount === undefined ? "col-12" : props.colsCount;
  const table = <table className="table table-hover mb-0 hidden-sm-down">
                  <thead>
                    { props.headers }
                  </thead>
                  <tbody>
                    { props.content }
                  </tbody>
                </table>

  const header = props.pageHeader === undefined ? <strong>{ props.caption }</strong> : props.pageHeader;

  const content = <div>
                    { table }
                    { props.footer }
                  </div>




  return <Page header={ header } content={ content } colsCount={ colsCount } />
}

export default TablePage