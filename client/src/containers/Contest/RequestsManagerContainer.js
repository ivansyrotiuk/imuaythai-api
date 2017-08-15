import React, { Component } from 'react'
import { connect } from 'react-redux'
import ContestRequestsManager from '../../views/Contest/ContestRequestsManager'
import Spinner from '../../views/Components/Spinners/Spinner'
import { fetchContest, addContestRequest, fetchContestRequests, acceptContestRequest, rejectContestRequest } from '../../actions/ContestActions'

class RequestsManagerContainer extends Component {

  componentWillMount() {
    var id = this.props.match.params.id;
    this.props.fetchContestRequests(id);
  }

  render() {
    const {fetching, contest, requests, acceptContestRequest, rejectContestRequest} = this.props;
    if (fetching) {
      return <Spinner />
    }

    return <div className="animated fadeIn">
             <div className="row">
               <div className="col-12">
                 <div className="card">
                   <div className="card-header">
                     <strong>Requests</strong>
                   </div>
                   <div className="card-block">
                     <ContestRequestsManager requests={ requests } acceptContestRequest={ acceptContestRequest } rejectContestRequest={ rejectContestRequest } />
                   </div>
                 </div>
               </div>
             </div>
           </div>


  }
}

const mapStateToProps = (state, ownProps) => {
  return {
    fetching: state.Contest.fetching,
    requests: state.Contest.requests,
    user: state.Account.user
  }
}

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    fetchContestRequests: (contestId) => {
      dispatch(fetchContestRequests(contestId))
    },
    acceptContestRequest: (request) => {
      dispatch(acceptContestRequest(request))
    },
    rejectContestRequest: (request) => {
      dispatch(rejectContestRequest(request))
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(RequestsManagerContainer)