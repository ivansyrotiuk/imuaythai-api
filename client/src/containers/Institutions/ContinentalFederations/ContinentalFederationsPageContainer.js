import React, {Component} from 'react';
import {connect} from 'react-redux'
import {fetchContinentalFederations, deleteInstitution} from '../../../actions/InstitutionsActions'
import Spinner from '../../../views/Components/Spinners/Spinner'
import FederationsListView from '../../../views/Institutions/FederationsListView';

class ContinentalFederationsPageContainer extends Component {
    constructor(props) {
        super(props);
        this.handleAddFederationClick = this.handleAddFederationClick.bind(this);
        this.handlePreviewFederationClick = this.handlePreviewFederationClick.bind(this);
        this.handleEditFederationClick = this.handleEditFederationClick.bind(this);
        this.handleDeleteFederationClick = this.handleDeleteFederationClick.bind(this);
    }

    componentWillMount() {
        this.props.fetchFederations();
    }

    handleAddFederationClick() {
        this.props.history.push('/institutions/continental/add');
    }

    handlePreviewFederationClick(id) {
        this.props.history.push("/institutions/continental/" + id);
    }

    handleEditFederationClick(id) {
        this.props.history.push("/institutions/continental/edit/" + id);
    }

    handleDeleteFederationClick(id) {
        this.props.deleteFederation(id);
    }

    get viewTitle(){
        return "Continental federations";
    }

    get viewActions(){
        return {
            addClick: this.handleAddFederationClick,
            previewClick: this.handlePreviewFederationClick,
            editClick: this.handleEditFederationClick,
            deleteClick: this.handleDeleteFederationClick
        };
    }

    render() {
        const {federations, fetching} = this.props;

        if (fetching) {
            return <Spinner/>
        }

        return <FederationsListView title={this.viewTitle} federations={federations} actions={this.viewActions}/>
    }
}


const mapStateToProps = (state, ownProps) => {
    return {
        federations: state.Institutions.continentalFederations,
        fetching: state.Institutions.fetching,
        fetched: state.Institutions.fetched
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchFederations: () => {
            dispatch(fetchContinentalFederations())
        },
        deleteFederation: (id) => {
            return dispatch(deleteInstitution(id));
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(ContinentalFederationsPageContainer)