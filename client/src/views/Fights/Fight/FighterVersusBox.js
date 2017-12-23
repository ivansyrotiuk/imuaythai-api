import React from 'react';
import moment from 'moment';
import CornerBox from './CornerBox';
import Avatar from 'react-avatar';

export const FighterVersusBox = props => {
    const { fighter, corner, winner } = props;
    const row = corner === 'blue' ? 'row flex-row-reverse' : 'row';
    const fighterColumn = corner === 'blue' ? 'coltext-left align-self-center' : 'col text-right align-self-center';

    const khan =
        (fighter && fighter.khanLevel) !== null ? (
            <h6 className="card-title">{fighter.khanLevel.name}</h6>
        ) : (
            <h6 className="card-title">-</h6>
        );

    const fighterName = fighter && fighter.firstname + ' ' + fighter.surname;

    return (
        <div className={row}>
            <div className="col-auto">
                <CornerBox color={corner}>
                    <div className="row h-100">
                        <div className="col-12 align-self-center p-5">
                            <Avatar name={fighterName} color="#FFF" fgColor="#000" round={true} />
                        </div>
                    </div>
                </CornerBox>
            </div>

            <div className={fighterColumn}>
                {!fighter && <h3 className="card-title">The winner of previous fight</h3>}
                {fighter && <h3 className="card-title">{fighterName}</h3>}
                {fighter && (
                    <h6 className="card-subtitle mb-2 text-muted">
                        {fighter.gymName || 'No gym'}, {fighter.countryName}
                    </h6>
                )}

                {fighter.id && <h6 className="card-title">{fighter.age}</h6>}
                {fighter.id && <h6 className="card-title">{fighter.won}</h6>}
                {fighter.id && <h6 className="card-title">{fighter.lost}</h6>}
                {khan}
                {winner && <h6 className="text-danger">Winner</h6>}
            </div>
        </div>
    );
};

export default FighterVersusBox;
