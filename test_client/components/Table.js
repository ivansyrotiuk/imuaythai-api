import React from "react"
import Row from "./table/Row"
import { connect } from "react-redux"

export default class Table extends React.Component {

    render() {
        const mappedDummyUsers = this.props.dummyUsers.map((dummyUser, i) => <Row key={i} dummyUser={dummyUser} count={i+1}/> );

        return (
            <div>
                <table class="table table-striped table-hover ">
                    <thead>
                        <tr>
                            <th>Image</th>
                            <th>Id</th>
                            <th>Firstname</th>
                            <th>Surname</th>
                        </tr>
                    </thead>
                    <tbody>
                       {mappedDummyUsers}
                    </tbody>
                </table>
            </div>
        );
    }
}
