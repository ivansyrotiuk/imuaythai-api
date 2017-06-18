import React from "react"
import Panel from "../components/Panel"

export default class Dashboard extends React.Component {
    render() {
        return (
            <div>
                <div class="row">
                    <div class="col-md-4"><Panel/></div>
                    <div class="col-md-4"><Panel/></div>
                    <div class="col-md-4"><Panel/></div>
                </div>
            </div>
        );
    }
}