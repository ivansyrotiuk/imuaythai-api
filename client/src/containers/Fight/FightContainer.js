import React, { Component } from "react";
import FightView from "../../views/Fights/Fight/FightView";
import { fetchFight } from "../../actions/FightActions";
import { connect } from "react-redux";
import Spinner from "../../views/Components/Spinners/Spinner";

class FightContainer extends Component {
    componentWillMount() {
        this.props.fetchFight(this.props.match.params.id);
    }

    render() {
        const { fightId } = this.props.match.params;
        const { fetching, fight } = this.props;

        if (fight == null) {
            return <Spinner />;
        }

        return <FightView fight={fight} />;
    }
}
const mapStateToProps = (state, ownProps) => {
    return {
        fight: state.Fights.fight,
        fetching: state.Fights.fetching
    };
};

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchFight: fightId => {
            dispatch(fetchFight(fightId));
        }
    };
};

FightContainer = connect(mapStateToProps, mapDispatchToProps)(FightContainer);
export default FightContainer;
