import React, { Component } from 'react'
import { connect } from 'react-redux'
import ContestViewPage from '../../views/Contest/ContestViewPage'
import Spinner from '../../views/Components/Spinners/Spinner'
import { fetchContest } from '../../actions/ContestActions'

class ContestViewPageContainer extends Component {
    constructor(props) {
        super(props);
        this.editContestClick = this.editContestClick.bind(this);
    }

    componentWillMount() {
        var id = this.props.match.params.id;
        this.props.fetchContest(id);
    }

    editContestClick() {
        this.props.history.push(this.props.match.url + '/edit');
    }

    render() {
        const {contest, fetching} = this.props;
        if (fetching) {
            return <Spinner/>
        }
        return <ContestViewPage contest={ contest } editClick={ this.editContestClick } />
    }

}

const mapStateToProps = (state, ownProps) => {
    return {
        contest: state.Contest.singleContest,
        fetching: state.Contest.fetching
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchContest: (id) => {
            dispatch(fetchContest(id))
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(ContestViewPageContainer)