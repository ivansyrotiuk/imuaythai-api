import React, { Component } from "react";
import { connect } from "react-redux";
import MovableFightsView from "../../views/Fights/MovableFightsView";
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

export class MovableFightsContainer extends Component {
    componentWillMount() {
        var id = this.props.match.params.id;
        this.props.fetchFights(id);
    }

    openFight(fightId) {
        this.props.history.push("/fights/" + fightId);
    }

    render() {
        const contestId = this.props.match.params.id;
        const { fetching, fights, tossupJudges, scheduleFights, moveFight, dragFight, tossingup, scheduling, moving } = this.props;
        if (fetching) {
            return <Spinner />;
        }

        return (
            <Loader show={moving} message={<Spinner />} messageStyle={messageStyle}>
                <MovableFightsView
                    fights={fights}
                    tossupJudgesClick={tossupJudges.bind(this, contestId)}
                    scheduleFightsClick={scheduleFights.bind(this, contestId)}
                    moveFight={moveFight}
                    dragFight={dragFight}
                    tossingup={tossingup}
                    scheduling={scheduling}
                    openFight={this.openFight}
                    {...this.props}
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

export default connect(mapStateToProps, mapDispatchToProps)(MovableFightsContainer);
