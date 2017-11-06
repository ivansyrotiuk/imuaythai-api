import React from 'react';
import PropTypes from 'prop-types';
import Page from "../../components/Page/Page";
import PageHeader from "../../components/Page/PageHeader";
import PageContent from "../../components/Page/PageContent";
import AddButton from "../Components/Buttons/AddButton";
import InstitutionsTable from "../../components/Institutions/Tables/InstitutionsTable";

const FederationsListView = (props) => {
    return(
        <Page>
            <PageHeader>
                <div><strong>{props.title}</strong>
                    <div className="pull-right">
                        <AddButton click={props.actions.addClick} tip={"Add Federation"}/>
                    </div>
                </div>
            </PageHeader>
            <PageContent>
                <InstitutionsTable institutions={props.federations} actions={props.actions}/>
            </PageContent>
        </Page>
    );
};

FederationsListView.defaultProps = {
    title: 'Federations',
    actions: {},
    federations: []
}

FederationsListView.propTypes = {
    title: PropTypes.string,
    actions: PropTypes.object,
    federations: PropTypes.array
}

export default FederationsListView;
