import React, {Component} from 'react';
import {host} from "../../../global"
import Spinner from "../../Components/Spinners/Spinner";
import {saveFighter} from "../../../actions/UsersActions";
import axios from "axios";
import DatePicker from 'react-datepicker';
import moment from 'moment';
import 'react-datepicker/dist/react-datepicker.css';

export default class CommonUserDataForm extends Component {
    constructor(props) {
        super(props);
        this.state = {user: this.props.user};
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleBirthdateChange = this.handleBirthdateChange.bind(this);
        
    }
    handleInputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox'
            ? target.checked
            : target.value;
        
        const name = target.name;
        const user = this.state.user;

        user[target.name] = value;
        this.setState({user: user});
    }

    handleBirthdateChange(date){
        const user = this.state.user;
        user.birthdate = date;
        this.setState({user: user});
    }

    render() {
        return (

            <form
            action=""
            method="post"
            encType="multipart/form-data"
            className="form-horizontal"
            onSubmit={this.props.onSubmit}>
            <div className="form-group row">
                <label className="col-md-3 form-control-label" htmlFor="text-input">First name</label>
                <div className="col-md-9">
                    <input
                        type="text"
                        name="firstname"
                        className="form-control"
                        placeholder="Text"
                        value={this.state.user.firstname}
                        onChange={this.handleInputChange}/>
                </div>
            </div>
            
            <div className="form-group row">
                <label className="col-md-3 form-control-label" htmlFor="text-input">Surname</label>
                <div className="col-md-9">
                    <input
                        type="text"
                        name="surname"
                        className="form-control"
                        placeholder="Text"
                        value={this.state.user.surname}
                        onChange={this.handleInputChange}/>
                </div>
            </div>
                
            <div className="form-group row">
                <label className="col-md-3 form-control-label" htmlFor="text-input">Nationality</label>
                <div className="col-md-9">
                    <input
                        type="text"
                        name="nationality"
                        className="form-control"
                        placeholder="Text"
                        value={this.state.user.nationality}
                        onChange={this.handleInputChange}/>
                    
                </div>
            </div>
            <div className="form-group row">
                <label className="col-md-3 form-control-label" htmlFor="text-input">Birthdate</label>
                <div className="col-md-9">
                        <DatePicker
                            selected={moment(this.state.user.birthdate)}
                            onChange={this.handleBirthdateChange}
                        />
                </div>
            </div>
            <button type="button" type="submit" className="btn btn-primary pull-right">Save</button>
        </form>
                                    
        );
    }
}