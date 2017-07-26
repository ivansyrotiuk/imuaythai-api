import React, { Component } from 'react';
import { Link } from 'react-router-dom'
import { connect } from "react-redux";
import { Progress, ButtonDropdown, DropdownItem, DropdownToggle, Button, DropdownMenu } from 'reactstrap';
import axios from "axios";
import { host } from "../../global"
import UserAvatar from 'react-user-avatar'
import Spinner from "../Components/Spinners/Spinner";
import { fetchCountries } from "../../actions/CountriesActions";
import moment from 'moment';

class FighterViewPage extends Component {
    constructor(props) {
        super(props);

        this.dispatchFetchFighter = this
            .dispatchFetchFighter
            .bind(this);
        this.state = {
            fetching: true
        };
    }

    componentWillMount() {
        this.dispatchFetchFighter();
        this.dispatchFetchCountries();
    }

    dispatchFetchFighter() {
        const fighterId = this.props.match.params.id;

        var self = this;

        axios
            .get(host + "api/users/fighters/" + fighterId)
            .then((response) => {
                self.setState({
                    fetching: false,
                    fighter: response.data
                });
            })
            .catch((err) => {
                self.setState({
                    fetching: false,
                    error: err
                });
            });
    }

    dispatchFetchCountries() {
        if (this.props.countries === undefined) {
            this.props.fetchCountries();
        }
    }

    goToEditPageClick() {
        this.props.history.push(this.props.match.url + '/edit');
    }

    goToRolesPageClick() {
        this.props.history.push(this.props.match.url + '/roles');
    }

    render() {
        const {fetching, fighter} = this.state;

        if (fetching) {
            return (<Spinner/>);
        }
        if (!fetching && this.state.fighter == undefined) {
            return (
                <div></div>
                );
        }

        const titleTextSyle = {
            color: '#697078'
        }

        const gender = fighter.gender == 'male'
            ? <h6 style={ titleTextSyle }>
                                                <i className="fa fa-mars" aria-hidden="true"></i>  Male</h6>
            : <h6 style={ titleTextSyle }>
                                            <i className="fa fa-venus" aria-hidden="true"></i>  Female</h6>;

        const userName = (fighter.firstname || 'No name') + ' ' + (fighter.surname || '');
        return <div className="animated fadeIn">
                 <div className="card">
                   <div className="card-header">
                     <strong>Fighter</strong>
                     <div className="pull-right">
                       <div className="input-group-btn">
                         <ButtonDropdown isOpen={ this.state.fourth } toggle={ () => {
                                                                                   this.setState({
                                                                                       fourth: !this.state.fourth
                                                                                   });
                                                                               } }>
                           <DropdownToggle caret color="link">
                             <i className="fa fa-bars" aria-hidden="true">  Options</i>
                           </DropdownToggle>
                           <DropdownMenu>
                             <DropdownItem onClick={ this.goToEditPageClick.bind(this) }>
                               <i className="fa fa-pencil" aria-hidden="true"></i>  Edit
                             </DropdownItem>
                             <DropdownItem onClick={ this.goToRolesPageClick.bind(this) }>
                               <i className="fa fa-users" aria-hidden="true"></i>  Roles
                             </DropdownItem>
                             <DropdownItem>Something </DropdownItem>
                             <DropdownItem>Separated</DropdownItem>
                           </DropdownMenu>
                         </ButtonDropdown>
                       </div>
                     </div>
                   </div>
                   <div className="card-block">
                     <div className="row">
                       <div className="col-12 col-md-auto col-sm-6">
                         <UserAvatar size="150" name={ fighter.firstname || fighter.email } />
                         <div className="caption">
                           <button type="button" className="btn btn-link">
                             <i className="fa fa-pencil"></i>  Change photo
                           </button>
                         </div>
                       </div>
                       <div className="col-12 col-md-4 col-sm-6">
                         <div class="page-header">
                           <h2>{ userName }
                                               </h2>
                           <a href={ 'mailto:' + fighter.email }>
                             { fighter.email }
                           </a>
                         </div>
                         <h6 style={ titleTextSyle }>
                                               <i class="fa fa-birthday-cake" aria-hidden="true"></i>  { moment(fighter.birthdate).format("YYYY-MM-DD") }
                                           </h6>
                         { gender }
                         { fighter.phone && <h6 style={ titleTextSyle }>
                                                                                                                                    <i class="fa fa-1x fa-phone" aria-hidden="true"></i>  { fighter.phone }
                                                                                                                                </h6> }
                         { fighter.countryName && <h6 style={ titleTextSyle }>
                                                                                                                                          <i class="fa fa-globe" aria-hidden="true"></i>
                                                                                                                                          <b>
                                                                                                                                              { fighter.countryName }</b>, { fighter.nationality }
                                                                                                                                      </h6> }
                       </div>
                       <div className="col-12 col-md-6 col-sm-12">
                         <div className="row justify-content-between">
                           <div className="col">
                             <div className="card">
                               <div className="card-block p-3 clearfix">
                                 <i className="fa fa-trophy bg-success p-3 font-2xl mr-3 float-left"></i>
                                 <div className="h5 text-primary mb-0 mt-2">23</div>
                                 <div className="text-muted text-uppercase font-weight-bold font-xs">wins</div>
                               </div>
                             </div>
                           </div>
                           <div className="col">
                             <div className="card">
                               <div className="card-block p-3 clearfix">
                                 <i className="fa fa-frown-o bg-danger p-3 font-2xl mr-3 float-left"></i>
                                 <div className="h5 text-primary mb-0 mt-2">1</div>
                                 <div className="text-muted text-uppercase font-weight-bold font-xs">defeats</div>
                               </div>
                             </div>
                           </div>
                         </div>
                         <div className="row justify-content-end">
                           { fighter.facebook && <a href={ fighter.facebook } target="_blank">
                                                   <button type="button" className="btn  btn-facebook">
                                                     <span>Facebook</span>
                                                   </button> </a> }
                           { fighter.twitter && <a href={ fighter.twitter } target="_blank">
                                                  <button type="button" className="btn  btn-twitter">
                                                    <span>Twitter</span>
                                                  </button> </a> }
                           { fighter.instagram && <a href={ fighter.instagram } target="_blank">
                                                    <button type="button" className="btn btn-instagram">
                                                      <span>Instagram</span>
                                                    </button> </a> }
                           { fighter.vk && <a href={ fighter.vk } target="_blank">
                                             <button type="button" className="btn  btn-vk">
                                               <span>VK</span>
                                             </button>
                                           </a> }
                         </div>
                       </div>
                     </div>
                   </div>
                 </div>
               </div>

    }
}

const mapStateToProps = (state, ownProps) => {
    return {
       countries: state.Countries.countries, 
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchCountries: () => {
            dispatch(fetchCountries());
        },
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(FighterViewPage)