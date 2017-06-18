import React from "react"
import Modal from "../components/Modal"
import Table from "../components/Table"


export default class Clients extends React.Component {
    render() {
        return (
            <div>
                <Table/>
                <Modal/>
            </div>
        );
    }
}
