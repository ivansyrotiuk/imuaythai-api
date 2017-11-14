import React, {Component} from 'react';
import {Field, reduxForm, formValueSelector} from 'redux-form';
import {connect} from 'react-redux';
import {Alert} from 'reactstrap';
import {ROLE_TYPE_MAPPINGS, CONTEST_FIGHTER} from '../../../common/contestRoleTypes'


class ContestRequestForm extends Component {
    render() {
        const {error, selectedRoleType, handleSubmit, categories, onRoleChange, onCancel, pristine, submitting, roles, candidates} = this.props;

        const mappedRoleTypes = roles.map((role, i) => <option key={i} value={ROLE_TYPE_MAPPINGS[role.normalizedName]}>
                {role.name}
            </option>
        );

        const roleName = Object.keys(ROLE_TYPE_MAPPINGS).find(k => ROLE_TYPE_MAPPINGS[k] == selectedRoleType);
        const role = roles.find(r => r.normalizedName === roleName);

        const mappedCandidates = candidates.directCandidates
            .filter(candidate => selectedRoleType === undefined || role === undefined ||
                candidate.roles.find(r => r === role.id) !== undefined)
            .map((candidate, i) => <option key={i} value={candidate.id}>
                    {candidate.firstname + ' ' + candidate.surname}
                </option>
            );

        const mappedCategories = categories.map((category, i) => <option key={i} value={category.id}>
                {category.name}
            </option>
        );


        const categoresField = selectedRoleType == CONTEST_FIGHTER ? <div className="form-group row">
            <label className="col-md-3 form-control-label" htmlFor="text-input">Please the category</label>
            <div className="col-md-9">
                <Field name="contestCategoryId" className="form-control" component="select">
                    <option key={-1} value={null}>
                        -
                    </option>
                    {mappedCategories}
                </Field>
            </div>
        </div> : null;


        return (<div>
                {error && <Alert color="danger">
                    {error}
                </Alert>}
                <div className="h4">Add a fighter, a judge or a doctor to the contest</div>
                <form onSubmit={handleSubmit}>
                    <div className="form-group row">
                        <label className="col-md-3 form-control-label" htmlFor="text-input">Please select the user
                            type</label>
                        <div className="col-md-9">
                            <Field name="type" className="form-control" component="select" onChange={onRoleChange}>
                                <option key={-1} value="">
                                    -
                                </option>
                                {mappedRoleTypes}
                            </Field>
                        </div>
                    </div>
                    <div className="form-group row">
                        <label className="col-md-3 form-control-label" htmlFor="text-input">Please the user</label>
                        <div className="col-md-9">
                            <Field name="userId" className="form-control" component="select">
                                <option key={-1} value="">
                                    -
                                </option>
                                {mappedCandidates}
                            </Field>
                        </div>
                    </div>
                    {categoresField}
                    <button type="reset" className="btn btn-sm btn-danger pull-right" onClick={onCancel}><i
                        className="fa fa-ban"></i> Cancel
                    </button>
                    <button type="submit" disabled={pristine || submitting}
                            className="btn btn-sm btn-primary pull-right">
                        {submitting && <i className="fa fa-spinner fa-pulse fa-1x fa-fw"></i>} Save
                    </button>
                </form>
            </div>
        )
    }
}

const validate = values => {
    const errors = {}
    if (!values.type) {
        errors.username = 'Required'
    }

    return errors
}

const selector = formValueSelector('ContestRequestForm');

ContestRequestForm = reduxForm({
    form: 'ContestRequestForm',
    validate
})(ContestRequestForm);

ContestRequestForm = connect(
    state => {
        const selectedRoleType = selector(state, 'type')
        return {
            selectedRoleType
        }
    }
)(ContestRequestForm)

export default ContestRequestForm;
