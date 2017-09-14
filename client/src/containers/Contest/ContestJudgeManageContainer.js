import React, { Component } from "react";
import { connect } from "react-redux";
import ContestJudgeManageView from "../../views/Contest/ContestJudgeManageView";
import Spinner from "../../views/Components/Spinners/Spinner";
import { fetchContestJudges } from "../../actions/ContestActions";
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

export class ContestJudgeManageContainer extends Component {
    componentWillMount() {
        var id = this.props.match.params.id;
        this.props.fetchContestJudges(id);
    }

    render() {
        const { judgeRequests, fetching, allocating, tossingup } = this.props;
        if (fetching) {
            return <Spinner />;
        }

        return (
            <Loader show={allocating} message={<Spinner />} messageStyle={messageStyle}>
                <ContestJudgeManageView judgeRequests={judgeRequests} tossingup={tossingup} />
            </Loader>
        );
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        judgeRequests: state.Contest.judgeRequests,
        allocating: state.Contest.allocating,
        fetching: state.Contest.fetching
    };
};

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchContestJudges: contestId => {
            dispatch(fetchContestJudges(contestId));
        }
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(ContestJudgeManageContainer);
