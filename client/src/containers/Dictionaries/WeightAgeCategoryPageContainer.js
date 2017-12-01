import React, {Component} from "react";
import {connect} from "react-redux";
import {fetchWeightCategory, saveWeightCategory} from '../../actions/Dictionaries/WeightCategoriesActions'
import Spinner from "../../views/Components/Spinners/Spinner";
import WeightAgeCategoryPage from "../../views/Dictionaries/WeightAgeCategories/WeightAgeCategoryPage";

class WeightAgeCategoriesDetailsPage extends Component {
    componentWillMount() {
        const id = this.props.match.params.id;
        if (isNaN(id)){
            return;
        }
        this.props.fetchWeightCategory(this.props.match.params.id);
    }

    render() {
        const {fetching} = this.props;
        if (fetching) {
            return <Spinner/>;
        }

        return <WeightAgeCategoryPage {...this.props} />;
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        fetching: state.WeightCategories.fetching,
        category: state.WeightCategories.category
    };
};

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchWeightCategory: id => {
            dispatch(fetchWeightCategory(id))
        },
        saveWeightCategory: category => {
            dispatch(saveWeightCategory(category))
        }
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(WeightAgeCategoriesDetailsPage);
