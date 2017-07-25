import {Link} from 'react-router-dom'
import React, {Component} from 'react';

class Registered extends Component {
    render() {
        return (
            <div className="container">
                <div className="jumbotron">
                    <h1 className="text-center">{this.props.headerText}</h1>
                    <p className="text-center">{this.props.description}</p>
                    <div class="col-md-4 offset-md-4 text-center">
                        <Link to={this.props.callback} className="btn btn-primary btn-large">{this.props.callbackButtonText}</Link>
                    </div>
                </div>
            </div>
        );
    }
}

export default Registered;