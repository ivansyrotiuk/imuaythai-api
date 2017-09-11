import React from 'react'
import Judge from './Judge'

export const JudgesListCard = (props) => {
  const {judgeRequests, header} = props;
  const mappedJudges = judgeRequests != undefined ? judgeRequests.map((judge, index) => <li key={ index } className="list-group-item">
                                                                                          <Judge judgeRequest={ judge } />
                                                                                        </li>) : undefined;

  return (
    <div className="card">
      <div className="card-header">
        { header }
      </div>
      <div className="card-block">
        <ul className="list-group">
          { mappedJudges }
        </ul>
      </div>
    </div>
  )
}
export default JudgesListCard;