import React, {Component} from 'react';
import {connect} from "react-redux";
import Spinner from "../../../views/Components/Spinners/Spinner";
import {fetchInstitution, fetchInstitutionMembers} from "../../../actions/InstitutionsActions";
import GymView from "../../../views/Institutions/GymView";

class GymViewPageContainer extends Component {

    componentWillMount() {
        const gymId = this.props.match.params.id;
        this.props.fetchInstitution(gymId);
        this.props.fetchInstitutionMembers(gymId);
    }

    goToEditPageClick() {
        const gymId = this.props.match.params.id;
        this.props.history.push("/institutions/gyms/edit/" + gymId);
    }

    render() {
        const {fetching, gym, members} = this.props;

        if (fetching || !gym) {
            return (<Spinner/>);
        }

        const actions = {
            goToEditPage: this.goToEditPageClick.bind(this)
        };

        return <GymView gym={gym} actions={actions} members={members}/>
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        gym: state.SingleInstitution.institution,
        members: state.SingleInstitution.members,
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

export default connect(mapStateToProps, mapDispatchToProps)(GymViewPageContainer)