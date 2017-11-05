import React, { Component } from 'react';
import { connect } from "react-redux"
import Spinner from "../../../views/Components/Spinners/Spinner"
import Page from "../../../components/Page/Page";
import PageContent from "../../../components/Page/PageContent";
import PageHeader from "../../../components/Page/PageHeader";
import UserTable from "../../../components/Users/UserTable";
import { fetchJudges, deleteUser } from "../../../actions/UsersActions"

class JudgesPageContainer extends Component {
  componentWillMount() {
    this.props.fetchJudges();
  }

  render() {
    const {judges, fetching} = this.props;

    if (fetching) {
      return <Spinner />
    }

    return (
        <Page>
          <PageHeader>Judges</PageHeader>
          <PageContent>
            <UserTable users={judges} deleteUser={this.props.deleteUser.bind(this)}/>
          </PageContent>
        </Page>
      );
  }
}

const mapStateToProps = (state, ownProps) => {
  return {
    judges: state.Users.judges,
    fetching: state.Users.fetching,
    fetched: state.Users.fetched
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    fetchJudges: () => {
      dispatch(fetchJudges());
    },
    deleteUser: (id) => {
      dispatch(deleteUser(id));
    }
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(JudgesPageContainer);