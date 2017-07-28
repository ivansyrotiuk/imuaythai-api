import React from 'react'

export const Page = (props) => {
    const colsCount = props.colsCount === undefined ? "col-12" : props.colsCount;

    return (
        <div className="animated fadeIn">
          <div className="row">
            <div className={ colsCount }>
              <div className="card">
                <div className="card-header">
                  { props.header }
                </div>
                <div className="card-block">
                  { props.content }
                </div>
              </div>
            </div>
          </div>
        </div>
    )
}

export default Page