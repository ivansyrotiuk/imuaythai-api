import React, { Component } from 'react';
import ContestInfoCard from './ContestInfoCard';
import AcceptedContestRequests from './AcceptedContestRequests';
import Page from '../../components/Page/Page';
import PageHeader from '../../components/Page/PageHeader';
import Col from '../../components/Layout/Col';
import PageContent from '../../components/Page/PageContent';
import Right from '../../components/Common/Right';
import EditButton from '../Components/Buttons/EditButton';

class ContestViewPage extends Component {
    render() {
        const { contest, doctorsRequests, judgesRequests, fightersRequests, actions, statistics } = this.props;

        return (
            <Page>
                <PageHeader>
                    <strong>Contest</strong>
                    <Right>
                        <EditButton click={actions.editContestClick} />
                    </Right>
                </PageHeader>
                <PageContent>
                    <Col>
                        <ContestInfoCard contest={contest} {...actions} {...statistics} />

                        <div className="card mt-2">
                            <div className="card-header">
                                <strong>Requests</strong>
                            </div>
                            <div className="card-block">
                                <AcceptedContestRequests
                                    fightersRequests={fightersRequests}
                                    judgesRequests={judgesRequests}
                                    doctorsRequests={doctorsRequests}
                                />
                            </div>
                        </div>
                    </Col>
                </PageContent>
            </Page>
        );
    }
}

export default ContestViewPage;
