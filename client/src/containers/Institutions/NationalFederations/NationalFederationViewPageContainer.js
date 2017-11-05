import React, {Component} from 'react';
import {connect} from "react-redux";
import Spinner from "../../../views/Components/Spinners/Spinner";
import {fetchInstitution, fetchInstitutionMembers} from "../../../actions/InstitutionsActions";
import FederationView from "../../../views/Institutions/FederationView";

class NationalFederationViewPageContainer extends Component {
    componentWillMount() {
        const nationalId = this.props.match.params.id;
        this.props.fetchInstitution(nationalId);
        this.props.fetchInstitutionMembers(nationalId);
    }

    goToEditPageClick() {
        const id = this.props.match.params.id;
        this.props.history.push("/institutions/national/edit/" + id);
    }


    render() {
        const {fetching, federation, members} = this.props;

        if (fetching || !federation) {
            return (<Spinner/>);
        }

        const actions = {
            goToEditPage: this.goToEditPageClick.bind(this)
        };

        return <FederationView federation={federation} actions={actions} members={members}/>
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        federation: state.SingleInstitution.institution,
        fetching: state.SingleInstitution.fetching
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchInstitution: (id) => {
            dispatch(fetchInstitution(id));
        },
        fetchInstitutionMembers: (id) => {
            dispatch(fetchInstitutionMembers(id));
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(NationalFederationViewPageContainer)