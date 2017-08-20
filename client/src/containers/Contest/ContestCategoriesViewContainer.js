import React, { Component } from 'react'
import { connect } from 'react-redux'
import ContestCategoriesView from '../../views/Contest/ContestCategoriesView'
import Spinner from '../../views/Components/Spinners/Spinner'
import { fetchCategoriesWithFighters } from '../../actions/ContestActions'


export class ContestCategoriesViewContainer extends Component {

    componentWillMount() {
        var id = this.props.match.params.id;
        this.props.fetchCategoriesWithFighters(id);
    }

    render() {
        const {fetching, categories} = this.props;
        const contestId = this.props.match.params.id;
        if (fetching) {
            return <Spinner />
        }

        return <ContestCategoriesView categories={ categories } contestId={ contestId } />
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        fetching: state.Contest.fetching,
        categories: state.Contest.categories
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchCategoriesWithFighters: (contestId) => {
            dispatch(fetchCategoriesWithFighters(contestId))
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(ContestCategoriesViewContainer)



