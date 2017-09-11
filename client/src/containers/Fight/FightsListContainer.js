import React, { Component } from 'react'
import { connect } from 'react-redux'
import FightsListView from '../../views/Fights/FightsListView'
import Spinner from '../../views/Components/Spinners/Spinner'
import { fetchContestFights } from '../../actions/FightActions'
import Loader from 'react-loader-advanced';

const messageStyle = {
    margin: 'auto',
    width: '50%'
}

const messageStyle2 = {
    position: 'fixed',
    top: '50%',
    left: '55%',
    transform: 'translate(-50%, -50%)',
    transform: '-webkit-translate(-50%, -50%)',
    transform: '-moz-translate(-50%, -50%)',
    transform: '-ms-translate(-50%, -50%)',
}

class FightsListContainer extends Component {
    componentWillMount() {
        const {contestId, categoryId} = this.props.match.params;
        this.props.fetchContestFights(contestId, categoryId);
    }

    render() {
        const {fetching, moving, fights} = this.props
        if (this.props.fetching) {
            return <Spinner />
        }

        return <Loader show={ moving } message={ <Spinner /> } messageStyle={ messageStyle2 }>
                 <FightsListView fights={ fights } />
               </Loader>
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        fights: state.Fights.contestCategoryFights,
        fetching: state.Fights.fetching,
        moving: state.Fights.moving
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