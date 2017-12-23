import moment from 'moment';
import React from 'react';

import CornerBox from './CornerBox';
import Page from '../../Components/Page';
import PointsGrid from './PointsGrid/PointsGrid';
import JudgesBox from './JudgesBox';
import FightInfoBox from './FightInfoBox';
import FightersBox from './FightersBox';
import SectionTitle from '../../../components/Common/SectionTitle';
import WarningsGrid from './WarningsGrid/WarningsGrid';
const FightView = props => {
    const { fight } = props;
    const { roundsCount } = fight.structure.round;
    const { judges, mainJudge, referee, timeKeeper } = fight;
    const header = <strong>Fight #{fight.id}</strong>;

    const content = (
        <div>
            <FightInfoBox fight={fight} />
            <SectionTitle>Fighters</SectionTitle>
            <FightersBox fight={fight} />
            <SectionTitle>Points</SectionTitle>
            <PointsGrid points={fight.points} roundsCount={roundsCount} />
            <SectionTitle>Warnings and injuries</SectionTitle>
            <WarningsGrid points={fight.points} roundsCount={roundsCount} />
            <SectionTitle>Judges</SectionTitle>
            <JudgesBox judges={judges} mainJudge={mainJudge} referee={referee} timeKeeper={timeKeeper} />
        </div>
    );

    return <Page content={content} header={header} />;
};

export default FightView;
