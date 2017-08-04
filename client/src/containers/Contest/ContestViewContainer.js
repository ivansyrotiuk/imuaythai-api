import React, { Component } from 'react'
import { connect } from 'react-redux'
import ContestViewPage from '../../views/Contest/ContestViewPage'
import Spinner from '../../views/Components/Spinners/Spinner'
import { fetchContest, fetchContestCandidates, addContestRequest, cancelContestRequest, saveContestRequest, fetchContestRequests, acceptContestRequest, rejectContestRequest, removeContestRequest } from '../../actions/ContestActions'
import { fetchContestRoles } from '../../actions/RolesActions'
import { SubmissionError } from 'redux-form'
import { CONTEST_FIGHTER } from '../../common/contestRoleTypes'

class ContestViewPageContainer extends Component {
    constructor(props) {
        super(props);
        this.editContest = this.editContest.bind(this);
        this.pendingRequestsClick = this.pendingRequestsClick.bind(this);
        this.addRequestsClick = this.addRequestsClick.bind(this);
    }

    componentWillMount() {
        var id = this.props.match.params.id;
        if (!this.props.contest || this.props.contest.id != id) {
            this.props.fetchContest(id);
            this.props.fetchContestRequests(id);
        }

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

    render() {
        const {contest, user, fetching, roles, candidates, requests, singleRequest, showRequestForm, acceptContestRequest, rejectContestRequest, removeContestRequest} = this.props;
        if (fetching) {
            return <Spinner/>
        }

        const showAcceptReject = user.roles.find(r => r === "Admin" || r === "Gym" || r === "NationalFederation" || r === "WorldFederation" || r === "ContinentalFederation") != undefined &&
            contest && contest.institutionId == user.InstitutionId;


        return <ContestViewPage contest={ contest } requests={ requests } user={ user } editContest={ this.editContest } addRequestsClick={ this.addRequestsClick }
                 pendingRequestsClick={ this.pendingRequestsClick } />

    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        contest: state.Contest.singleContest,
        fetching: state.Contest.fetching,
        requests: state.Contest.requests,
        user: state.Account.user
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