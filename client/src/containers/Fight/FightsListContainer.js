import React, { Component } from 'react'
import { connect } from 'react-redux'
import FightsListView from '../../views/Fights/FightsListView'
import Spinner from '../../views/Components/Spinners/Spinner'
import { fetchContestFights } from '../../actions/FightActions'

class FightsListContainer extends Component {
    componentWillMount() {
        const {contestId, categoryId} = this.props.match.params;
        this.props.fetchContestFights(contestId, categoryId);
    }

    render() {
        const {fetching, fights} = this.props
        if (this.props.fetching) {
            return <Spinner />
        }

        return <FightsListView fights={ fights } />
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        fights: state.Fights.contestCategoryFights,
        fetching: state.Fights.fetching,
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchContestFights: (contestId, categoryId) => {
            dispatch(fetchContestFights(contestId, categoryId))
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(FightsListContainer)