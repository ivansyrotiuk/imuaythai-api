import React from 'react'

export const RejectButton = (props) => {
    return (
        <div className="btn btn-link pull-right" onClick={ props.click }>
          { !props.rejecting && <i className="fa fa-thumbs-o-down text-danger" aria-hidden="true"></i> }
          { props.rejecting && <i style={ { width: '12px' } } className="fa fa-spinner fa-pulse fa-1x fa-fw "></i> }
        </div>
    )
}

export default RejectButton