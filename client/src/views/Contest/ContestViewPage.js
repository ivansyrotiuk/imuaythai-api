import React, { Component } from 'react'
import moment from 'moment'
import Page from '../Components/Page'
import EditButton from '../Components/Buttons/EditButton'
import ContestInfoCard from './ContestInfoCard'
import ContestRequestsCard from './ContestRequestsCard'
import { Route, Link } from 'react-router-dom';

class ContestViewPage extends Component {
    render() {
        const {contest} = this.props;
        if (!contest) {
            return <div></div>
        }

        return <div className="animated fadeIn">
                 <div className="row">
                   <div className="col-12">
                     <ContestInfoCard contest={ contest } editClick={ this.props.editClick } />
                     <ContestRequestsCard contest={ contest } />
                   </div>
                 </div>
               </div>
    }
}

export default ContestViewPage