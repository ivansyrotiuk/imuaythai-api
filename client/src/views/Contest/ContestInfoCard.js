import React from 'react'
import EditButton from '../Components/Buttons/EditButton'
import moment from 'moment'

export const ContestInfoCard = (props) => {
  const {contest, editContest} = props;

  return (
    <div className="card">
      <div className="card-header">
        <strong>Contest</strong>
        <div className="pull-right">
          <EditButton click={ editContest } />
        </div>
      </div>
      <div className="card-block">
        <div className="row">
          <div className="col-md-3">
            <img src="/img/contest_poster.jpg" className="img-thumbnail" />
          </div>
          <div className="col-md-9">
            <div className="row">
              <p className="h1">
                { contest.name }
              </p>
            </div>
            <div className="row form-group">
              <h3>{ contest.country.name }, { moment(contest.date).format('YYYY.DD.MM') } - { moment(contest.date).add('days', contest.duration).format('YYYY.DD.MM') }</h3>
            </div>
            <div className="row">
              <h6>{ contest.city }, { contest.address }</h6>
            </div>
            <div className="row">
              <h6>Organizator: { contest.institution.name }</h6>
            </div>
            <div className="row form-group">
              <h6>Website: <a href={ contest.website } target="_blank">{ contest.website }</a></h6>
            </div>
            <div className="row form-group">
              { contest.facebook && <a href={ contest.facebook } target="_blank">
                                      <button type="button" className="btn  btn-facebook">
                                        <span>Facebook</span>
                                      </button> </a> }
              { contest.twitter && <a href={ contest.twitter } target="_blank">
                                     <button type="button" className="btn  btn-twitter">
                                       <span>Twitter</span>
                                     </button> </a> }
              { contest.instagram && <a href={ contest.instagram } target="_blank">
                                       <button type="button" className="btn btn-instagram">
                                         <span>Instagram</span>
                                       </button> </a> }
              { contest.vk && <a href={ contest.vk } target="_blank">
                                <button type="button" className="btn  btn-vk">
                                  <span>VK</span>
                                </button>
                              </a> }
            </div>
            <div className="row">
              <div className="h6">Registration statistic</div>
            </div>
            <div className="row">
              <div className="col-sm-2">
                <div className="callout callout-info">
                  <small className="text-muted">Fighters</small>
                  <br/>
                  <strong className="h4">78</strong>
                </div>
              </div>
              <div className="col-sm-2">
                <div className="callout callout-success">
                  <small className="text-muted">Judges</small>
                  <br/>
                  <strong className="h4">15</strong>
                </div>
              </div>
              <div className="col-sm-2">
                <div className="callout callout-danger">
                  <small className="text-muted">Doctors</small>
                  <br/>
                  <strong className="h4">7</strong>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}

export default ContestInfoCard