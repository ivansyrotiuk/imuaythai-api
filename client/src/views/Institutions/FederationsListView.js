import React from 'react';
import PropTypes from 'prop-types';
import Page from '../../components/Page/Page';
import PageHeader from '../../components/Page/PageHeader';
import PageContent from '../../components/Page/PageContent';
import AddButton from '../Components/Buttons/AddButton';
import InstitutionsTable from '../../components/Institutions/Tables/InstitutionsTable';
import Right from '../../components/Common/Right';

const FederationsListView = props => {
    return (
        <Page>
            <PageHeader>
                <strong>{props.title}</strong>
                <Right>
                    <AddButton click={props.actions.addClick} tip={'Add Federation'} />
                </Right>
            </PageHeader>
            <PageContent>
                <InstitutionsTable institutions={props.federations} actions={props.actions} />
            </PageContent>
        </Page>
    );
};

FederationsListView.defaultProps = {
    title: 'Federations',
    actions: {},
    federations: []
};

export default FederationsListView;
