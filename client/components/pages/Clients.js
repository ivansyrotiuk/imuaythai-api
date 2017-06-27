import React from "react"
import Modal from "../../components/Modal"
import Table from "../../components/Table"

import { connect } from "react-redux"

import Loading from 'react-loading-spinner';

import { fetchDummyUsers } from "../../actions/dummyUsersActions"

@connect((store) => {
  return {
    dummyUsers: store.dummyUsers.dummyUsers,
    fetching: store.dummyUsers.fetching,
    fetched: store.dummyUsers.fetched,
  };
})

export default class Clients extends React.Component {

    fetchDummyUsers() {
        this.props.dispatch(fetchDummyUsers())
    }

    render() {
        const {dummyUsers, fetching} = this.props;

       const content = <div>
            <Table dummyUsers={dummyUsers}/>
            <Modal/>
       </div>

        const Spinner = () => <i class="fa fa-circle-o-notch fa-spin fa-3x fa-fw"></i>

    if (dummyUsers.length === 0 && !fetching) {

      return <button onClick={this.fetchDummyUsers.bind(this)}>Get users</button>

    }

        return (
            <div>
                <Loading isLoading={fetching} children={content} spinner={Spinner}/>
              
            </div>
        );
    }
}
