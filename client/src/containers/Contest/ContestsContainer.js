import React, { Component } from 'react';
import { connect } from 'react-redux'
import ContestsPage from '../../views/Contest/ContestsPage'
import Spinner from '../../views/Components/Spinners/Spinner'
import { fetchConstests } from '../../actions/ContestActions'

class ContestsContainer extends Component {
    constructor(props) {
        super(props);
        this.addContest = this.addContest.bind(this);
    }

    componentWillMount() {
        this.props.fetchConstests();
    }

    addContest() {
        this.props.history.push('/contests/add');
    }

    render() {
        const {contests, fetching} = this.props;
        if (fetching) {
            return <Spinner />
        }

        return <ContestsPage contests={ contests } addContestClick={ this.addContest } />
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        contests: state.Contest.contests,
        fetching: state.Contest.fetching
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchConstests: () => {
            dispatch(fetchConstests())
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(ContestsContainer)