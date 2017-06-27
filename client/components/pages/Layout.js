import React from "react"
import Navbar from "../../components/Navbar"
import {Link} from "react-router";

export default class Layout extends React.Component {
    render() {
        var titleStyle = {
            marginLeft: '50px'
        };
        var {routes} = this.props;
        return (
            <div>
                <Navbar/>
               
                <div class="container">
                    {this.props.children}
                </div>
            </div>
        );
    }
}