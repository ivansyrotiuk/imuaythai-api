import React from 'react'

export const ContestJudgeManageView = (props) => {
    const mappedJudge = props.judges.map((judge, index) => <div>
                                                             { index }
                                                           </div>)
    return (
        <div>
          <div className="row">
            <div className="col-md-3">
              <div className="card card-inverse card-primary">
                <div className="card-header">Main judges</div>
                <div className="card-block">
                  <h4 className="card-title">Primary card title</h4>
                  <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                </div>
              </div>
            </div>
            <div className="col-md-3">
              <div className="card bg-light mb-3">
                <div className="card-header">Reqular</div>
                <div className="card-block">
                  <h4 className="card-title">Primary card title</h4>
                  <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                </div>
              </div>
            </div>
            <div className="col-md-3">
              <div className="card bg-light mb-3">
                <div className="card-header">Referees</div>
                <div className="card-block">
                  <h4 className="card-title">Primary card title</h4>
                  <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                </div>
              </div>
            </div>
            <div className="col-md-3">
              <div className="card bg-light  mb-3">
                <div className="card-header">Time keeppers</div>
                <div className="card-block">
                  <h4 className="card-title">Primary card title</h4>
                  <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                </div>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-md-12">
              <div className="card bg-light  mb-3">
                <div className="card-header">Accepted judges</div>
                <div className="card-block">
                  <h4 className="card-title">Primary card title</h4>
                  <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                </div>
              </div>
            </div>
          </div>
        </div>
    )
}

export default ContestJudgeManageView