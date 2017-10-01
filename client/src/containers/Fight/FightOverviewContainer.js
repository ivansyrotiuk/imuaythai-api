import React, { Component } from 'react';
import FightOverview from '../../views/Fights/FightOverview/FightOverview'
import { fetchFight } from '../../actions/FightActions';
import { connect } from 'react-redux';
import Spinner from '../../views/Components/Spinners/Spinner'

class FightOverviewContainer extends Component {

    componentWillMount() {
        this.props.fetchFight(this.props.match.params.id);
    }

    render() {
        const {fightId} = this.props.match.params;
        const {fetching, fight} = this.props;

        if (fight == null) {
            return <Spinner />
        }

        return <FightOverview fight={ fight } />
    }
}
const mapStateToProps = (state, ownProps) => {
    return {
        fight: state.Fights.fight,
        fetching: state.Fights.fetching
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchFight: (fightId) => {
            dispatch(fetchFight(fightId));
        },
    }
}

FightOverviewContainer = connect(mapStateToProps, mapDispatchToProps)(FightOverviewContainer)
export default FightOverviewContainer;