import React from 'react'

export const AcceptButton = (props) => {
    return (
        <div className="btn btn-link pull-right" onClick={ props.click }>
          { !props.accepting && <i className="fa fa-thumbs-o-up text-primary" aria-hidden="true"></i> }
          { props.accepting && <i style={ { width: '12px' } } className="fa fa-spinner fa-pulse fa-1x fa-fw"></i> }
        </div>
    )
}

export default AcceptButton