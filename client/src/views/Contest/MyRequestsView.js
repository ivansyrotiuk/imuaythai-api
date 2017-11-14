import React from 'react';
import PropTypes from 'prop-types';
import Page from "../../components/Page/Page";
import PageHeader from "../../components/Page/PageHeader";
import PageContent from "../../components/Page/PageContent";
import ContestInstitutionRequests from "./ContestInstitutionRequests";

const MyRequestsView = props => {
    const {requests, actions} = props;
    return (
        <Page>
            <PageHeader>
                <strong>Requests</strong>
            </PageHeader>
            <PageContent>
                <ContestInstitutionRequests requests={ requests } {...actions}/>
            </PageContent>
        </Page>
    );
};

MyRequestsView.defaultProps = {
    requests: [],
    actions: {}
};

MyRequestsView.propTypes = {
    requests: PropTypes.array,
    actions: PropTypes.obj
};

export default MyRequestsView;
