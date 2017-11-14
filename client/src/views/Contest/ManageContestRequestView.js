import React from 'react';
import PropTypes from 'prop-types';
import Page from "../../components/Page/Page";
import PageHeader from "../../components/Page/PageHeader";
import Right from "../../components/Common/Right";
import AddButton from "../Components/Buttons/AddButton";
import PageContent from "../../components/Page/PageContent";
import ContestRequestForm from "../../components/Contest/Forms/ContestRequestForm";

const ManageContestRequestView = props => {
    const {actions, request, roles, categories, candidates} = props;
    return (
        <Page>
            <PageHeader>
                Add request
            </PageHeader>


            <PageContent>
                <ContestRequestForm onSubmit={actions.saveRequest}
                                    initialValues={request}
                                    roles={roles}
                                    candidates={candidates}
                                    categories={categories}
                                    onCancel={actions.cancelRequest}/>
            </PageContent>
        </Page>
    );
};

ManageContestRequestView.defaultProps = {
    request: {},
    actions: {},
    roles: [],
    candidates: {},
    categories: []
};

ManageContestRequestView.propTypes = {
    request: PropTypes.object,
    actions: PropTypes.object,
    roles: PropTypes.array,
    candidates: PropTypes.object,
    categories: PropTypes.array
};

export default ManageContestRequestView;
