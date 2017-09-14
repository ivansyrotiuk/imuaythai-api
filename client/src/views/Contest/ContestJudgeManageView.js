import React from "react";
import {
    MainJudgeTargetDecorator,
    RegularJudgeTargetDecorator,
    RefereeTargetDecorator,
    TimeKeepperTargetDecorator,
    AcceptedJudgeTargetDecorator
} from "./JudgeDropTargetDecorator";
import HTML5Backend from "react-dnd-html5-backend";
import { DragDropContext } from "react-dnd";
import * as judgeTypes from "../../common/contestJudgeTypes";
import Page from "../Components/Page";
export const ContestJudgeManageView = props => {
    const { judgeRequests, tossingup } = props;

    const acceptedJudges = judgeRequests.filter(r => r.judgeType == null);
    const mainJudges = judgeRequests.filter(r => r.judgeType == judgeTypes.CONTEST_MAIN_JUDGE);
    const reqularJudges = judgeRequests.filter(r => r.judgeType == judgeTypes.CONTEST_REGULAR_JUDGE);
    const referies = judgeRequests.filter(r => r.judgeType == judgeTypes.CONTEST_REFEREE);
    const timeKeeppers = judgeRequests.filter(r => r.judgeType == judgeTypes.CONTEST_TIME_KEEPPER);

    const content = (
        <div>
            <div className="row">
                <div className="col">
                    <AcceptedJudgeTargetDecorator header="Accepted judges" judgeRequests={acceptedJudges} />
                </div>
            </div>
            <div className="row">
                <div className="col">
                    <MainJudgeTargetDecorator header="Main judges" judgeRequests={mainJudges} />
                </div>
                <div className="col">
                    <RegularJudgeTargetDecorator header="Reqular judges" judgeRequests={reqularJudges} />
                </div>
                <div className="col">
                    <RefereeTargetDecorator header="Referees" judgeRequests={referies} />
                </div>
                <div className="col">
                    <TimeKeepperTargetDecorator header="Time keeppers" judgeRequests={timeKeeppers} />
                </div>
            </div>
        </div>
    );

    const header = <strong>Judge management</strong>;
    return <Page header={header} content={content} />;
};

export default DragDropContext(HTML5Backend)(ContestJudgeManageView);
