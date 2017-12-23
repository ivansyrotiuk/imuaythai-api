import React, { Component } from 'react';
import { Tooltip } from 'reactstrap';

export default class EditButton extends Component {
    constructor(props) {
        super(props);

        this.toggle = this.toggle.bind(this);
        this.state = {
            tooltipOpen: false
        };
    }

    toggle() {
        this.setState({
            tooltipOpen: !this.state.tooltipOpen
        });
    }

    render() {
        const { text, click } = this.props;
        return (
            <div>
                <button id="EditButton" type="button" className="btn btn-link pull-right" onClick={click}>
                    <i className="fa fa-pencil text-primary" />
                    {text}
                </button>
                <Tooltip placement="bottom" isOpen={this.state.tooltipOpen} target="EditButton" toggle={this.toggle}>
                    Edit
                </Tooltip>
            </div>
        );
    }
}
