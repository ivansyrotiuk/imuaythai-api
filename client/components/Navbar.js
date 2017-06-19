import React from "react"
import {IndexLink, Link} from "react-router";

export default class Navbar extends React.Component {
    render() {
        const {location} = this.props;
        return (
            <nav class="navbar navbar-default">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <button
                            type="button"
                            class="navbar-toggle collapsed"
                            data-toggle="collapse"
                            data-target="#bs-example-navbar-collapse-1"
                            aria-expanded="false">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="#">Muay Thai</a>
                    </div>

                    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                        <ul class="nav navbar-nav">
                            <li>
                                <IndexLink to="/">Home</IndexLink>
                            </li>
                            <li>
                                <Link to="clients">Users</Link>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        );
    }
}