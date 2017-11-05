import React, {Component} from 'react';
import {connect} from "react-redux"
import Spinner from "../../../views/Components/Spinners/Spinner"
import {fetchFighters, deleteUser} from "../../../actions/UsersActions"
import UserTable from "../../../components/Users/UserTable";
import Page from "../../../components/Page/Page";
import PageHeader from "../../../components/Page/PageHeader";
import PageContent from "../../../components/Page/PageContent";

class FightersPageContainer extends Component {
    componentWillMount() {
        this.props.fetchFighters();
    }

    render() {
        const {fighters, fetching} = this.props;

        if (fetching) {
            return <Spinner/>
        }
        return (
            <Page>
                <PageHeader>Fighters</PageHeader>
                <PageContent>
                    <UserTable users={fighters} deleteUser={this.props.deleteUser.bind(this)}/>
                </PageContent>
            </Page>
        );
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        fighters: state.Users.fighters,
        fetching: state.Users.fetching,
        fetched: state.Users.fetched
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        fetchFighters: () => {
            dispatch(fetchFighters());
        },
        deleteUser: (id) => {
            dispatch(deleteUser(id));
        }
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(FightersPageContainer);