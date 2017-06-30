import React from "react"
import Modal from "../../components/Modal"
import Table from "../../components/Table"

import {connect} from "react-redux"
import LoadButton from "../LoadButton"

import {fetchDummyUsers} from "../../actions/dummyUsersActions"

@connect((store) => {
    return {dummyUsers: store.dummyUsers.dummyUsers, fetching: store.dummyUsers.fetching, fetched: store.dummyUsers.fetched};
})

export default class Clients extends React.Component {

    constructor(props){
        super(props);
        this.fetchDummyUsers();
    }

    fetchDummyUsers() {
        this.props.dispatch(fetchDummyUsers())
    }

    render() {
        const {dummyUsers, fetching} = this.props;
    
        const content = <div>
            <Table dummyUsers={dummyUsers}/>
            <Modal/>
        </div>

        if (fetching) {
            return <LoadButton text="Load users" loading={fetching} click={this.fetchDummyUsers.bind(this)}/>
        }
        
        return content;
    }
}
