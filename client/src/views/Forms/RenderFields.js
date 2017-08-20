import React from 'react'

export const RenderField = ({input, label, type, meta: {touched, error}}) => (
    <div>
      <label>
        { label }
      </label>
      <div className="form-group">
        <input {...input} type={ type } placeholder={ label } className="form-control" />
      </div>
    </div>
)