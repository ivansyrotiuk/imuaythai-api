import React, {Component} from 'react'
import {connect} from 'react-redux'
import * as contestActions from '../../actions/ContestActions'
import {fetchContestRoles} from '../../actions/RolesActions'
import {dismissError} from '../../actions/ErrorsActions'
import {SubmissionError} from 'redux-form'
import {CONTEST_FIGHTER} from '../../common/contestRoleTypes'
import ManageContestRequestView from "../../views/Contest/ManageContestRequestView";
import MyRequestsView from "../../views/Contest/MyRequestsView";

class RequestAddingContainer extends Component {
    constructor(props) {
        super(props);
        this.handleAddRequestClick = this.handleAddRequestClick.bind(this);
        this.handleSaveRequestClick = this.handleSaveRequestClick.bind(this);
    }

    componentWillMount() {
        const id = this.props.match.params.id;

        this.props.fetchContest(id);
        this.props.fetchContestRequests(id);
        this.props.fetchContestCandidates();
        this.props.fetchContestRoles();
    }

    handleAddRequestClick() {
        const request = {
            contestId: this.props.contest.id
        };
        this.props.addContestRequest(request);
    }

    handleSaveRequestClick(request){
        if (!request.type) {
            throw new SubmissionError({
                _error: 'Please, select your role type'
            })
        }
        if (!request.userId) {
            throw new SubmissionError({
                _error: 'Please, select a user'
            })
        }
        if (request.type === CONTEST_FIGHTER && !request.contestCategoryId) {
            throw new SubmissionError({
                _error: 'Please, select a category'
            })
        }

        this.props.saveContestRequest(request);
    }

    render() {
        const {contest, requests, roles, showRequestForm, candidates, request} = this.props;

        const actions = {
            addRequest: this.handleAddRequestClick,
            saveRequest: this.handleSaveRequestClick,
            editRequest: this.props.editContestRequest,
            cancelRequest: this.props.cancelContestRequest.bind(this),
            removeRequest: this.props.removeContestRequest
        };

        if (showRequestForm) {
            return <ManageContestRequestView request={request} roles={roles} candidates={candidates}
                                             categories={contest.contestCategories} actions={actions}/>
        }
        else {
            return <MyRequestsView requests={requests} actions={actions}/>
        }

    }

    componentWillUnmount() {
        this.props.dismissError();
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        contest: state.Contest.singleContest,
        fetching: state.Contest.fetching,
        roles: state.Roles.contestRoles,
        candidates: state.Contest.candidates,
        requests: state.Contest.institutionRequests,
        showRequestForm: state.Contest.showRequestForm,
        request: state.Contest.singleRequest,
    }
};

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchContest: (id) => {
            dispatch(contestActions.fetchContest(id))
        },
        fetchContestRoles: () => {
            dispatch(fetchContestRoles())
        },
        fetchContestRequests: (contestId) => {
            dispatch(contestActions.fetchInstitutionContestRequests(contestId))
        },
        fetchContestCandidates: () => {
            dispatch(contestActions.fetchContestCandidates())
        },
        addContestRequest: (request) => {
            dispatch(contestActions.addContestRequest(request))
        },
        cancelContestRequest: () => {
            dispatch(contestActions.cancelContestRequest())
        },
        saveContestRequest: (request) => {
            return dispatch(contestActions.saveContestRequest(request))
        },
        removeContestRequest: (request) => {
            dispatch(contestActions.removeContestRequest(request))
        },
        editContestRequest: request => {
            dispatch(contestActions.editContestRequest(request));
        },

        dismissError: () => {
            dispatch(dismissError())
        }
    }
};

export default connect(mapStateToProps, mapDispatchToProps)(RequestAddingContainer)