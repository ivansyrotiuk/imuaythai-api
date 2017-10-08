import React from "react";

import JudgeCard from "./JudgeCard";
export const JudgesBox = props => {
    const { judges, mainJudge, referee, timeKeeper } = props;
    const judgeIcon = <i className="fa fa-gavel text-muted" aria-hidden="true" />;
    const mainJudgeIcon = <i className="fa fa-gavel text-primary" aria-hidden="true" />;
    const refereeIcon = <i className="fa fa-male text-muted" aria-hidden="true" />;
    const timeKeeperIcon = <i className="fa fa-clock-o text-muted" aria-hidden="true" />;

    const mappedJudges = judges.map((judge, key) => <JudgeCard key={key} judge={judge} caption="Judge" icon={judgeIcon} />);

    return (
        <div className="row">
            <JudgeCard judge={mainJudge} caption="Main judge" icon={mainJudgeIcon} />
            {mappedJudges}
            <JudgeCard judge={referee} caption="Referee" icon={refereeIcon} />
            <JudgeCard judge={timeKeeper} caption="Time keeper" icon={timeKeeperIcon} />
        </div>
    );
};

export default JudgesBox;
