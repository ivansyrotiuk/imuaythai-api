import React from "react"

export default class Layout extends React.Component {
    constructor(){
        super();
    }

    render() {
        return (
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Panel title</h3>
                </div>
                <div class="panel-body">
                    Panel content
                </div>
            </div>
        );
    }
}