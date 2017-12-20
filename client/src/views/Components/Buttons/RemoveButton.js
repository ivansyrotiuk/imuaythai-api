import React, { Component } from 'react';

import { Tooltip } from 'reactstrap';

export default class RemoveButton extends Component {
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
        const { text, removing, click } = this.props;
        return (
            <div>
                <button id="RemoveButton" className="btn btn-link pull-right" onClick={click}>
                    {!removing && <i className="fa fa-trash text-danger" />}
                    {removing && (
                        <i
                            style={{
                                width: '12px'
                            }}
                            className="fa fa-spinner fa-pulse fa-1x fa-fw "
                        />
                    )}
                </button>
                <Tooltip placement="bottom" isOpen={this.state.tooltipOpen} target="RemoveButton" toggle={this.toggle}>
                    Delete
                </Tooltip>
            </div>
        );
    }
}
