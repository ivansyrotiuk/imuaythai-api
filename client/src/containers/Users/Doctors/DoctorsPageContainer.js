import React, { Component } from 'react';
import { connect } from "react-redux"
import Page from "../../../components/Page/Page";
import PageContent from "../../../components/Page/PageContent";
import PageHeader from "../../../components/Page/PageHeader";
import UserTable from "../../../components/Users/UserTable";
import Spinner from "../../../views/Components/Spinners/Spinner"
import { fetchDoctors, deleteUser } from "../../../actions/UsersActions"

class DoctorsPageContainer extends Component {
  componentWillMount() {
    this.props.fetchDoctors();
  }

  render() {
    const {doctors, fetching} = this.props;

    if (fetching) {
      return <Spinner />
    }

      return (
          <Page>
              <PageHeader>Doctors</PageHeader>
              <PageContent>
                  <UserTable users={doctors} deleteUser={this.props.deleteUser.bind(this)}/>
              </PageContent>
          </Page>
      );
  }
}

const mapStateToProps = (state, ownProps) => {
  return {
    doctors: state.Users.doctors,
    fetching: state.Users.fetching,
    fetched: state.Users.fetched
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    fetchDoctors: () => {
      dispatch(fetchDoctors());
    },
    deleteUser: (id) => {
      dispatch(deleteUser(id));
    }
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(DoctorsPageContainer);