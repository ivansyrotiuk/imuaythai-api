import React, { Component } from 'react';
import CreateFightsDiagram from '../../views/Fight/CreateFightsDiagram'
import { fetchFights } from '../../actions/FightActions';
import { connect } from 'react-redux';

class CreateFightsDiagramContainer extends Component {

    componentWillMount() {
        if (!this.props.fights.length) {
            this.props.fetchFights();
        }
    }

    render() {
        return (
            <CreateFightsDiagram fights={ this.props.fights } />
            );
    }
}
const mapStateToProps = (state, ownProps) => {
    return {
        fights: state.Fight.games
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchFights: () => {
            dispatch(fetchFights());
        },


    }
}

CreateFightsDiagramContainer = connect(mapStateToProps, mapDispatchToProps)(CreateFightsDiagramContainer)
export default CreateFightsDiagramContainer;