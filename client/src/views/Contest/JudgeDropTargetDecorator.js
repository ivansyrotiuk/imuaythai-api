import React from 'react'
import JudgesListCard from './JudgesListCard'
import { DropTarget } from 'react-dnd';
import { collect, mainJudgeTarget, regularJudgeTarget, refereeTarget, timeKeepperTarget, acceptedJudgeTarget } from './JudgeDropTarget'
import dragTypes from '../../common/dragTypes'

export const JudgeDropTargetDecorator = (props) => {
    const {isOver, canDrop, connectDropTarget} = props;

    return connectDropTarget(
        <div>
          <JudgesListCard {...props } />
        </div>
    )
}

export const AcceptedJudgeTargetDecorator = DropTarget(dragTypes.JUDGE, acceptedJudgeTarget, collect)(JudgeDropTargetDecorator);
export const MainJudgeTargetDecorator = DropTarget(dragTypes.JUDGE, mainJudgeTarget, collect)(JudgeDropTargetDecorator);
export const RegularJudgeTargetDecorator = DropTarget(dragTypes.JUDGE, regularJudgeTarget, collect)(JudgeDropTargetDecorator);
export const RefereeTargetDecorator = DropTarget(dragTypes.JUDGE, refereeTarget, collect)(JudgeDropTargetDecorator);
export const TimeKeepperTargetDecorator = DropTarget(dragTypes.JUDGE, timeKeepperTarget, collect)(JudgeDropTargetDecorator);