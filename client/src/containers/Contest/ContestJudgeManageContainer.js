import React, { Component } from 'react'
import { connect } from 'react-redux'
import ContestJudgeManageView from '../../views/Contest/ContestJudgeManageView'
import Spinner from '../../views/Components/Spinners/Spinner'
import { fetchContestJudges } from '../../actions/ContestActions'

export class ContestJudgeManageContainer extends Component {

    componentWillMount() {
        var id = this.props.match.params.id;
        this.props.fetchContestJudges(id);
    }

    render() {
        const {judges, fetching} = this.props;
        if (fetching) {
            return <Spinner />
        }

        return <ContestJudgeManageView judges={ judges } />
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        judges: state.Contest.judges
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchContestJudges: (contestId) => {
            dispatch(fetchContestJudges(contestId))
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(ContestJudgeManageContainer)