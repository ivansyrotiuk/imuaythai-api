import React from 'react';
import DetailedVersus from './DetailedVersus';
import FighterVersusBox from './FighterVersusBox';

export const FightersBox = props => {
    const { fight } = props;
    const redWon = fight.redAthlete && fight.winnerId === fight.redAthlete.id;
    const blueWon = fight.blueAthlete && fight.winnerId === fight.blueAthlete.id;
    return (
        <div className="row">
            <div className="col-md-5">
                {<FighterVersusBox fighter={fight.redAthlete} winner={redWon} corner="red" />}
            </div>
            <div className="col-md-2 text-center align-self-center">
                <DetailedVersus />
            </div>
            <div className="col-md-5">
                {<FighterVersusBox fighter={fight.blueAthlete} winner={blueWon} corner="blue" />}
            </div>
        </div>
    );
};

export default FightersBox;
