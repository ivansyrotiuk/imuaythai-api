import React from 'react'

export const ExtendedVersus = (props) => {
    return (
        <div className="col-md-12 align-self-center">
          { <h1><strong>VS</strong></h1> }
          { <h6 className="card-subtitle mb-2 text-muted"> Country</h6> }
          { <h4 className="card-title">Age </h4> }
          { <h4 className="card-title"> Won </h4> }
          { <h4 className="card-title"> Lost </h4> }
          { <h4 className="card-title">Khan</h4> }
        </div>
    )
}

export default ExtendedVersus