import React from 'react';
import Avatar from 'react-avatar';

export const JudgeCard = props => {
    const { judge, caption, icon } = props;
    const judgeName = judge && judge.firstname + ' ' + judge.surname;
    const gym = judge && judge.gymName;
    const country = judge && judge.countryName;
    const judgeInfo = gym + ', ' + country;
    return (
        <div className="col-md-4 col-sm-4 col-lg-2">
            <div className="card">
                <div className="card-header">
                    {icon} <strong>{caption}</strong>
                </div>
                <div className="card-block">
                    <div className="row">
                        <Avatar className="mx-auto" name={judgeName} round={true} />
                    </div>
                    <div className="row mt-3">
                        <div className="col h6 text-center">{judgeName}</div>
                    </div>
                    <div className="row">
                        <div className="col h6 text-center text-muted">{judgeInfo}</div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default JudgeCard;
