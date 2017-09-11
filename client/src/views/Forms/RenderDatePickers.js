import React from 'react'
import Datetime from 'react-datetime';
import moment from 'moment'
import 'react-datetime/css/react-datetime.css'

export const RenderDatePicker = props => {
  if (!props.input.value._isAMomentObject) {
    props.input.value = moment.utc(props.input.value)
  }
  return <div>
           <label>
             { props.label }
           </label>
           <div className="form-group">
             <Datetime {...props.input} dateFormat="YYYY-MM-DD" timeFormat="" />
           </div>
         </div>
}

export const RenderTimePicker = props => {
  if (!props.input.value._isAMomentObject) {
    const momentDate = moment(props.input.value);
    const offset = momentDate.utcOffset();
    props.input.value = momentDate.add('minutes', offset);
  }
  return <div>
           <label>
             { props.label }
           </label>
           <div className="form-group">
             <Datetime utc={ true } {...props.input} dateFormat="" timeFormat="HH:mm" />
           </div>
         </div>
}