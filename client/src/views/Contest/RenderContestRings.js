import React from 'react'
import moment from 'moment';
import { Field, reduxForm, FieldArray, formValueSelector } from 'redux-form';
import { RenderTimePicker } from '../Forms/RenderDatePickers'
import { createRingAvailability } from '../../common/contestConstructors'

const ringsCountChange = (fields, e) => {
  const ringsArray = ['A', 'B', 'C'];
  const ringsCount = e.target.value;

  for (let i = 0; i < ringsCount - fields.length; i++) {
    const contestDay = fields.get(0).from;
    const ringName = ringsArray[fields.length + i];
    const ringAvailability = createRingAvailability(contestDay, ringName);
    fields.push(ringAvailability);
  }

  for (let i = 0; i < fields.length - e.target.value; i++) {
    fields.pop();
  }

  for(let i = 0; i < fields.length; i++){
    fields.get(i).name = ringsArray[i];
  }

}

const renderRingAvailability = ({fields}) => {
  return <div>
           <div className="card card-accent-primary">
             <div className="card-block">
               <div className="row form-group justify-content-center">
                 <div className="col-md-6">
                   <h5>Contest day: { moment(fields.get(0).from).format('YYYY-MM-DD') }</h5>
                 </div>
                 <div className="col-md-12">
                 </div>
               </div>
               <div className="form-group row">
                 <label className="col-md-4 form-control-label align-self-center">Rings count:</label>
                 <div className="col-md-8">
                   <select type="select" className="form-control" onChange={ ringsCountChange.bind(this, fields) }>
                     <option value="1">1 (A)</option>
                     <option value="2">2 (A, B)</option>
                     <option value="3">3 (A, B, C)</option>
                   </select>
                 </div>
               </div>
               { fields.map((member, index) => <div key={ index } className="row">
                                                 <div className="col-md-4 align-self-center">
                                                   <h4>Ring: <strong>{ fields.get(index).name }</strong></h4>
                                                 </div>
                                                 <div className="col-md-4">
                                                   <Field name={ `${member}.from` } type="text" component={ RenderTimePicker } label="From" />
                                                 </div>
                                                 <div className="col-md-4">
                                                   <Field name={ `${member}.to` } type="text" component={ RenderTimePicker } label="To" />
                                                 </div>
                                               </div>) }
             </div>
           </div>
         </div>
}


class RenderContestRings extends React.Component {
  constructor(props) {
    super(props);
    this.removeLast = this.removeLast.bind(this);
  }

  addRing(ring) {
    if (ring === undefined) {
      return;
    }

    this.props.fields.push(ring);
  }

  removeLast() {
    this.props.fields.pop();
  }

  render() {
    const {fields} = this.props;
    return <div>
             { fields.map((member, index) => <div key={ index }>
                                               <FieldArray name={ `${member}.ringsAvilability` } component={ renderRingAvailability } />
                                             </div>) }
           </div>
  }
}

export default RenderContestRings