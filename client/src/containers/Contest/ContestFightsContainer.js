import React, { Component } from "react";
import { connect } from "react-redux";
import ContestFightsView from "../../views/Contest/ContestFightsView";
import Spinner from "../../views/Components/Spinners/Spinner";
import { fetchContestFights, tossupJudges, scheduleFights } from "../../actions/ContestActions";
import { dismissNotifications } from "../../actions/NotificationActions";
export class ContestFightsContainer extends Component {
    componentWillMount() {
        var id = this.props.match.params.id;
        this.props.fetchFights(id);
    }

    render() {
        const contestId = this.props.match.params.id;
        const { fetching, fights, tossupJudges, scheduleFights, tossingup, scheduling } = this.props;
        if (fetching) {
            return <Spinner />;
        }

        return (
            <ContestFightsView
                fights={fights}
                tossupJudgesClick={tossupJudges.bind(this, contestId)}
                scheduleFightsClick={scheduleFights.bind(this, contestId)}
                tossingup={tossingup}
                scheduling={scheduling}
            />
        );
    }

    componentWillUnmount() {
        this.props.dismissNotifications();
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
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
        }
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(ContestFightsContainer);
