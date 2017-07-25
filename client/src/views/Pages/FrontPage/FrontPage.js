import React, { Component } from 'react';
import { NavLink } from 'react-router-dom'

class FrontPage extends Component {

    constructor(props){
        super(props);
        this.conteinerStyle = {height: window.innerHeight + 'px'}
    }

    
  render() {
    

    return (
        <div class="container-fluid front-background">
            <div class="row align-items-center" style={this.conteinerStyle}>
                <div class="col">
                 <div className="row justify-content-center">
                    <div className="col-sm-6 col-md-4 col-sm-offset-4">
                        <div className="card card-inverse card-primary">
                        <div className="card-header">
                            IMuaythai
                        </div>
                        <div className="card-block">
                            <div class="col">
                                <div class="row">
                                    The web application is in development.
                                </div>
                                    <br/>
                                <div class="row">
                                    <button type="button" className="btn btn-secondary btn-lg btn-block">
                                            <NavLink to={'/dashboard'} className="nav-link" activeClassName="active">Go in </NavLink>
                                    </button>
                                </div>  
                            </div>

                        </div>
                        </div>
                    </div>
                 </div>
                </div>
            </div>
        </div>
    );
  }
}

export default FrontPage;
