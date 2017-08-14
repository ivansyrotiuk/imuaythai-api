import React from 'react'
import { Table } from 'reactstrap';
import RemoveButton from "../Components/Buttons/RemoveButton";
import moment from 'moment'
import { Field, reduxForm, FieldArray, formValueSelector } from 'redux-form';
import { connect } from 'react-redux';
import Datetime from 'react-datetime';
import { createRingAvailability } from '../../common/contestConstructors'

const renderField = ({input, label, type, meta: {touched, error}}) => (
  <div>
    <label>
      { label }
    </label>
    <div className="form-group">
      <input {...input} type={ type } placeholder={ label } className="form-control" />
    </div>
  </div>
)

const renderDatePicker = props => {
  if (!props.input.value._isAMomentObject) {
    props.input.value = moment.utc(props.input.value)
  }
  return <div>
           <label>
             { props.label }
           </label>
           <div className="form-group">
             <Datetime {...props.input} dateFormat="" timeFormat="HH:mm" />
           </div>
         </div>
}


const ringsCountChange = (fields, e) => {
  const ringsArray = ['A', 'B', 'C'];
  const ringsCount = e.target.value;

  for (let i = 0; i < ringsCount - fields.length; i++) {
    const contestDay = fields.get(0).from;
    const ringName = ringsArray[fields.length];
    const ringAvailability = createRingAvailability(contestDay, ringName);
    fields.push(ringAvailability);
  }

  for (let i = 0; i < fields.length - e.target.value; i++) {
    fields.pop();
  }

}



const renderRingAvailability = ({fields}) => <div>
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
                                                                                       <Field name={ `${member}.from` } type="text" component={ renderDatePicker } label="From" />
                                                                                     </div>
                                                                                     <div className="col-md-4">
                                                                                       <Field name={ `${member}.to` } type="text" component={ renderDatePicker } label="To" />
                                                                                     </div>
                                                                                   </div>) }
                                                 </div>
                                               </div>
                                             </div>





class RenderContestRings extends React.Component {
  constructor(props) {
    super(props);
    this.renderRings = this.renderRings.bind(this);
    this.removeLast = this.removeLast.bind(this);
  }


  renderRings(rings) {
    if (rings === undefined) {
      return;
    }
    for (let i = 0; i < rings.length; i++)
      this.props.fields.push(rings[i]);
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