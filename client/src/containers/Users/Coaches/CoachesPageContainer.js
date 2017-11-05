import React, { Component } from 'react';
import { connect } from "react-redux"
import Spinner from "../../../views/Components/Spinners/Spinner"
import { fetchCoaches, deleteUser } from "../../../actions/UsersActions"
import Page from "../../../components/Page/Page";
import PageContent from "../../../components/Page/PageContent";
import PageHeader from "../../../components/Page/PageHeader";
import UserTable from "../../../components/Users/UserTable";

class CoachesPageContainer extends Component {
  componentWillMount() {
    this.props.fetchCoaches();
  }

  render() {
    const {coaches, fetching} = this.props;

    if (fetching) {
      return <Spinner />
    }

      return (
          <Page>
              <PageHeader>Coaches</PageHeader>
              <PageContent>
                  <UserTable users={coaches} deleteUser={this.props.deleteUser.bind(this)}/>
              </PageContent>
          </Page>
      );
  }
}

const mapStateToProps = (state, ownProps) => {
  return {
    coaches: state.Users.coaches,
    fetching: state.Users.fetching,
    fetched: state.Users.fetched
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    fetchCoaches: () => {
      dispatch(fetchCoaches());
    },
    deleteUser: (id) => {
      dispatch(deleteUser(id));
    }
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(CoachesPageContainer);