import React, {Component} from "react";
import WeightCategoriesDataForm from "./WeightCategoriesDataForm";
import Page from "../../../components/Page/Page";
import PageHeader from "../../../components/Page/PageHeader";
import PageContent from "../../../components/Page/PageContent";

class WeightAgeCategoryPage extends Component {
    render() {
        const {category, saveWeightCategory} = this.props;

        return (<Page>
                <PageHeader>
                    <strong>Weight category</strong>
                </PageHeader>
                <PageContent>
                    <WeightCategoriesDataForm initialValues={category} onSubmit={saveWeightCategory}/>
                </PageContent>
            </Page>
        );
    }
}

export default WeightAgeCategoryPage;
