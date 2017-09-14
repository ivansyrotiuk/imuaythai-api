import React, { Component } from 'react'
import { connect } from 'react-redux'
import ContestViewPage from '../../views/Contest/ContestViewPage'
import Spinner from '../../views/Components/Spinners/Spinner'
import { fetchContest, fetchContestCandidates, addContestRequest, cancelContestRequest, saveContestRequest, fetchContestRequests, acceptContestRequest, rejectContestRequest, removeContestRequest } from '../../actions/ContestActions'
import { fetchContestRoles } from '../../actions/RolesActions'
import { SubmissionError } from 'redux-form'
import { CONTEST_FIGHTER, CONTEST_JUDGE, CONTEST_DOCTOR } from '../../common/contestRoleTypes'
import { CONTEST_REQUEST_PENDING, CONTEST_REQUEST_ACCEPTED, CONTEST_REQUEST_REJECTED } from '../../common/contestRequestStatuses'


class ContestViewPageContainer extends Component {
    constructor(props) {
        super(props);
        this.editContest = this.editContest.bind(this);
        this.pendingRequestsClick = this.pendingRequestsClick.bind(this);
        this.addRequestsClick = this.addRequestsClick.bind(this);
        this.contestCategoriesClick = this.contestCategoriesClick.bind(this);
        this.manageJudgesClick = this.manageJudgesClick.bind(this);
        this.contestFightsClick = this.contestFightsClick.bind(this);
    }

    componentWillMount() {
        var id = this.props.match.params.id;

        this.props.fetchContest(id);
        this.props.fetchContestRequests(id);
    }

    editContest() {
        this.props.history.push(this.props.match.url + '/edit');
    }

    pendingRequestsClick() {
        this.props.history.push(this.props.match.url + '/requests');
    }

    addRequestsClick() {
        this.props.history.push(this.props.match.url + '/institution_requests');
    }

    contestCategoriesClick() {
        this.props.history.push(this.props.match.url + '/categories');
    }

    manageJudgesClick() {
        this.props.history.push(this.props.match.url + '/judges');
    }

    contestFightsClick() {
        this.props.history.push(this.props.match.url + '/fights');
    }

    render() {
        const {contest, fetching, roles, candidates, requests, singleRequest, showRequestForm, acceptContestRequest, rejectContestRequest, removeContestRequest} = this.props;
        if (fetching) {
            return <Spinner/>
        }

        const fightersRequests = requests.filter(r => r.type === CONTEST_FIGHTER && r.status == CONTEST_REQUEST_ACCEPTED)
        const judgesRequests = requests.filter(r => r.type === CONTEST_JUDGE && r.status == CONTEST_REQUEST_ACCEPTED)
        const doctorsRequests = requests.filter(r => r.type === CONTEST_DOCTOR && r.status == CONTEST_REQUEST_ACCEPTED)
        const pendingRequests = requests.filter(r => r.status == CONTEST_REQUEST_PENDING)

        return <ContestViewPage contest={ contest } pendingRequests={ pendingRequests } doctorsRequests={ doctorsRequests } judgesRequests={ judgesRequests } fightersRequests={ fightersRequests }
                 editContest={ this.editContest } addRequestsClick={ this.addRequestsClick } pendingRequestsClick={ this.pendingRequestsClick } contestCategoriesClick={ this.contestCategoriesClick } manageJudgesClick={ this.manageJudgesClick }
                 contestFightsClick={ this.contestFightsClick } />

    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        contest: state.Contest.singleContest,
        fetching: state.Contest.fetching,
        requests: state.Contest.requests,
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchContest: (id) => {
            dispatch(fetchContest(id))
        },
        fetchContestRequests: (contestId) => {
            dispatch(fetchContestRequests(contestId))
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(ContestViewPageContainer)