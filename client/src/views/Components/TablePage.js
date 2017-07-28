import React from 'react'
import Page from "./Page"

export const TablePage = (props) => {
  const colsCount = props.colsCount === undefined ? "col-12" : props.colsCount;
  const table = <table className="table">
                  <thead>
                    { props.headers }
                  </thead>
                  <tbody>
                    { props.content }
                  </tbody>
                </table>

  const header = <strong>{ props.caption }</strong>
  const content = <div>
                    { table }
                    { props.footer }
                  </div>


  return <Page header={ header } content={ content } />
}

export default TablePage