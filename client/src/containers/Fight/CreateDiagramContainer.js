import React, { Component } from 'react';
import CreateFightsDiagram from '../../views/Fight/CreateFightsDiagram'
import { fetchFights } from '../../actions/FightActions';
import { connect } from 'react-redux';
import Spinner from '../../views/Components/Spinners/Spinner'

class CreateFightsDiagramContainer extends Component {

    componentWillMount() {
        if (!this.props.fights.length) {
            this.props.fetchFights();
        }
    }

    render() {
        return (
            <div>
              { this.props.fetching ? <Spinner/> : <CreateFightsDiagram fights={ this.props.fights } fetching={ this.props.fetching } /> }
            </div>

            );
    }
}
const mapStateToProps = (state, ownProps) => {
    return {
        fights: state.Fight.games,
        fetching: state.Fight.fetching
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