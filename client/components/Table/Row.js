import React from "react"

export default class Row extends React.Component {
    render() {
            var {client} = this.props;
        return (
            <tr data-toggle="modal" data-target="#myModal">
                <td>{this.props.count}</td>
                <td>{client.Firstname}</td>
                <td>{client.Surname}</td>
                <td>{client.Email}</td>
            </tr>

        );
    }
}
