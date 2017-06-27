import React from "react"

export default class Row extends React.Component {
    render() {
            var {dummyUser} = this.props;
        return (
            <tr data-toggle="modal" data-target="#myModal">
                <td>{dummyUser.id}</td>
                <td>{dummyUser.firstname}</td>
                <td>{dummyUser.surname}</td>
            </tr>
        );
    }
}
