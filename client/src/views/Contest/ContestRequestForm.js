import React, { Component } from 'react';
import { Field, reduxForm } from 'redux-form';

class ContestRequestForm extends Component {
  render() {
    const {handleSubmit, categories, onRoleChange, onCancel, pristine, submitting, roles, candidates} = this.props;
    const mappedRoles = roles.map((role, i) => <option key={ i } value={ role.id }>
                                                 { role.name }
                                               </option>
    );
    const mappedCandidates = candidates.directCandidates.map((candidate, i) => <option key={ i } value={ candidate.id }>
                                                                                 { candidate.firstname + ' ' + candidate.surname }
                                                                               </option>
    );
    const mappedCategories = categories.map((category, i) => <option key={ i } value={ category.id }>
                                                               { category.name + ' (' + category.contestRangeName + ' ' + category.contestTypeName + ' - ' + category.weightCategoryName + ')' }
                                                             </option>
    );
    return (<div>
              <div className="h4">Add a fighter, a judge or a doctor to the contest</div>
              <form onSubmit={ handleSubmit }>
                <div className="form-group row">
                  <label className="col-md-3 form-control-label" htmlFor="text-input">Please select the user type</label>
                  <div className="col-md-9">
                    <Field name="roleId" className="form-control" component="select" onChange={ onRoleChange }>
                      <option key={ -1 } value={ null }>
                        -
                      </option>
                      { mappedRoles }
                    </Field>
                  </div>
                </div>
                <div className="form-group row">
                  <label className="col-md-3 form-control-label" htmlFor="text-input">Please the user</label>
                  <div className="col-md-9">
                    <Field name="userId" className="form-control" component="select">
                      <option key={ -1 } value={ null }>
                        -
                      </option>
                      { mappedCandidates }
                    </Field>
                  </div>
                </div>
                <div className="form-group row">
                  <label className="col-md-3 form-control-label" htmlFor="text-input">Please the user</label>
                  <div className="col-md-9">
                    <Field name="categoryId" className="form-control" component="select">
                      <option key={ -1 } value={ null }>
                        -
                      </option>
                      { mappedCategories }
                    </Field>
                  </div>
                </div>
                <button type="reset" className="btn btn-sm btn-danger pull-right" onClick={ onCancel }><i className="fa fa-ban"></i> Cancel</button>
                <button type="submit" disabled={ pristine || submitting } className="btn btn-sm btn-primary pull-right">
                  { submitting && <i className="fa fa-spinner fa-pulse fa-1x fa-fw"></i> } Save
                </button>
              </form>
            </div>
    )
  }
}
export default reduxForm({
  form: 'ContestRequestForm'
})(ContestRequestForm);
