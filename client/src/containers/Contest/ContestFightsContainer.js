import React, { Component } from "react";
import { connect } from "react-redux";
import ContestFightsView from "../../views/Contest/ContestFightsView";
import Spinner from "../../views/Components/Spinners/Spinner";
import { fetchContestFights, tossupJudges, scheduleFights } from "../../actions/ContestActions";
import { dismissNotifications } from "../../actions/NotificationActions";
import { moveFight, dragFight } from "../../actions/FightActions";
import Loader from "react-loader-advanced";

const messageStyle = {
    position: "fixed",
    top: "50%",
    left: "55%",
    transform: "translate(-50%, -50%)",
    transform: "-webkit-translate(-50%, -50%)",
    transform: "-moz-translate(-50%, -50%)",
    transform: "-ms-translate(-50%, -50%)"
};

export class ContestFightsContainer extends Component {
    componentWillMount() {
        var id = this.props.match.params.id;
        this.props.fetchFights(id);
    }

    render() {
        const contestId = this.props.match.params.id;
        const { fetching, fights, tossupJudges, scheduleFights, moveFight, dragFight, tossingup, scheduling, moving } = this.props;
        if (fetching) {
            return <Spinner />;
        }

        return (
            <Loader show={moving} message={<Spinner />} messageStyle={messageStyle}>
                <ContestFightsView
                    fights={fights}
                    tossupJudgesClick={tossupJudges.bind(this, contestId)}
                    scheduleFightsClick={scheduleFights.bind(this, contestId)}
                    moveFight={moveFight}
                    dragFight={dragFight}
                    tossingup={tossingup}
                    scheduling={scheduling}
                />
            </Loader>
        );
    }

    componentWillUnmount() {
        this.props.dismissNotifications();
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        moving: state.Fights.fightMoving,
        fights: state.Contest.fights,
        fetching: state.Contest.fetching,
        tossingup: state.Contest.tossingup,
        scheduling: state.Contest.scheduling
    };
};

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchFights: contestId => {
            dispatch(fetchContestFights(contestId));
        },
        tossupJudges: contestId => {
            dispatch(tossupJudges(contestId));
        },
        scheduleFights: contestId => {
            dispatch(scheduleFights(contestId));
        },
        dismissNotifications: () => {
            dispatch(dismissNotifications());
        },
        moveFight: fightMoving => {
            dispatch(moveFight(fightMoving));
        },
        dragFight: fightDragging => {
            dispatch(dragFight(fightDragging));
        }
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(ContestFightsContainer);
