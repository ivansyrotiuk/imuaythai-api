import React from 'react'

export const AddButton = (props) => {
    return (
        <div>
          <button type="button" className="btn btn-link btn-sm" onClick={ props.click }><i className="fa fa-plus fa-1x" aria-hidden="true"> </i>
          </button>
        </div>
    )
}

export default AddButton