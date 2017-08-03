import React, { Component } from 'react'
import { connect } from 'react-redux'
import ContestViewPage from '../../views/Contest/ContestViewPage'
import Spinner from '../../views/Components/Spinners/Spinner'
import { fetchContest, fetchContestCandidates, addContestRequest, cancelContestRequest, saveContestRequest, fetchContestRequests, acceptContestRequest, rejectContestRequest, removeContestRequest } from '../../actions/ContestActions'
import { fetchContestRoles } from '../../actions/RolesActions'


class ContestViewPageContainer extends Component {
    constructor(props) {
        super(props);
        this.editContest = this.editContest.bind(this);
        this.addRequest = this.addRequest.bind(this);
    }

    componentWillMount() {
        var id = this.props.match.params.id;
        this.props.fetchContest(id);
        this.props.fetchContestCandidates();
        this.props.fetchContestRoles();
        this.props.fetchContestRequests(id);
    }

    editContest() {
        this.props.history.push(this.props.match.url + '/edit');
    }

    addRequest() {
        const request = {
            contestId: this.props.contest.id
        }
        this.props.addContestRequest(request);
    }

    render() {
        const {contest, fetching, roles, candidates, requests, singleRequest, showRequestForm, acceptContestRequest, rejectContestRequest, removeContestRequest} = this.props;
        if (fetching) {
            return <Spinner/>
        }
        return <ContestViewPage contest={ contest } candidates={ candidates } roles={ roles } requests={ requests } singleRequest={ singleRequest }
                 showRequestForm={ showRequestForm } editContest={ this.editContest } addRequest={ this.addRequest } saveRequest={ this.props.saveContestRequest } cancelRequest={ this.props.cancelContestRequest }
                 acceptContestRequest={ acceptContestRequest } rejectContestRequest={ rejectContestRequest } removeContestRequest={ removeContestRequest } />
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        contest: state.Contest.singleContest,
        fetching: state.Contest.fetching,
        roles: state.Roles.contestRoles,
        candidates: state.Contest.candidates,
        requests: state.Contest.requests,
        showRequestForm: state.Contest.showRequestForm,
        singleRequest: state.Contest.singleRequest,
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchContest: (id) => {
            dispatch(fetchContest(id))
        },
        fetchContestRoles: () => {
            dispatch(fetchContestRoles())
        },
        fetchContestRequests: (contestId) => {
            dispatch(fetchContestRequests(contestId))
        },
        fetchContestCandidates: () => {
            dispatch(fetchContestCandidates())
        },
        addContestRequest: (request) => {
            dispatch(addContestRequest(request))
        },
        cancelContestRequest: () => {
            dispatch(cancelContestRequest())
        },
        saveContestRequest: (request) => {
            return dispatch(saveContestRequest(request))
        },
        acceptContestRequest: (request) => {
            dispatch(acceptContestRequest(request))
        },
        rejectContestRequest: (request) => {
            dispatch(rejectContestRequest(request))
        },
        removeContestRequest: (request) => {
            dispatch(removeContestRequest(request))
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(ContestViewPageContainer)