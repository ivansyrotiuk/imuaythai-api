import React, { Component } from 'react';
import { Link } from 'react-router-dom'
import { connect } from "react-redux";
import { ButtonDropdown, DropdownItem, DropdownToggle, Button, DropdownMenu } from 'reactstrap';
import axios from "axios";
import UserAvatar from 'react-user-avatar'
import Spinner from "../../views/Components/Spinners/Spinner";
import { fetchCountries } from "../../actions/CountriesActions";
import { fetchUser } from "../../actions/UsersActions";
import moment from 'moment';
import Page from "../../views/Components/Page"


class UserViewPageContainer extends Component {
  constructor(props) {
    super(props);
    this.state = {}
  }

  componentWillMount() {
    const userId = this.props.match.params.id;
    this.props.fetchUser(userId);

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
    const {fetching, user} = this.props;

    if (fetching) {
      return (<Spinner/>);
    }
    if (!fetching && user == undefined) {
      return (
        <div></div>
        );
    }

    const titleTextSyle = {
      color: '#697078'
    }

    const gender = user.gender == 'male'
      ? <h6 style={ titleTextSyle }>
                                                                                                                                                                                                          <i className="fa fa-mars" aria-hidden="true"></i>  Male
                                                                                                                                                                                                        </h6>
      : <h6 style={ titleTextSyle }>
                                                                                                                                                                                                          <i className="fa fa-venus" aria-hidden="true"></i>  Female
                                                                                                                                                                                                        </h6>;

    const userName = (user.firstname || 'No name') + ' ' + (user.surname || '');

    const header = <div><strong>Fighter</strong>
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

    const content = <div className="row">
                      <div className="col-12 col-md-auto col-sm-6">
                        <UserAvatar size="150" name={ user.firstname + " " + user.surname || user.email } src={ user.photo } />
                      </div>
                      <div className="col-12 col-md-4 col-sm-6">
                        <div class="page-header">
                          <h2>{ userName }
                                                                                                                                                                                                                                                                                                   </h2>
                          <a href={ 'mailto:' + user.email }>
                            { user.email }
                          </a>
                        </div>
                        <h6 style={ titleTextSyle }>
                                                                                                                                                                                      <i class="fa fa-birthday-cake" aria-hidden="true"></i>  { moment(user.birthdate).format("YYYY-MM-DD") }
                                                                                                                                                                                          </h6>
                        { gender }
                        { user.phone && <h6 style={ titleTextSyle }>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  <i class="fa fa-1x fa-phone" aria-hidden="true"></i>  { user.phone }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              </h6> }
                        { user.countryName && <h6 style={ titleTextSyle }>
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
                          { user.facebook && <a href={ user.facebook } target="_blank">
                                               <button type="button" className="btn  btn-facebook">
                                                 <span>Facebook</span>
                                               </button> </a> }
                          { user.twitter && <a href={ user.twitter } target="_blank">
                                              <button type="button" className="btn  btn-twitter">
                                                <span>Twitter</span>
                                              </button> </a> }
                          { user.instagram && <a href={ user.instagram } target="_blank">
                                                <button type="button" className="btn btn-instagram">
                                                  <span>Instagram</span>
                                                </button> </a> }
                          { user.vk && <a href={ user.vk } target="_blank">
                                         <button type="button" className="btn  btn-vk">
                                           <span>VK</span>
                                         </button>
                                       </a> }
                        </div>
                      </div>
                    </div>

    return <Page header={ header } content={ content } />
  }
}

const mapStateToProps = (state, ownProps) => {
  return {
    countries: state.Countries.countries,
    user: state.SingleUser.user,
    fetching: state.SingleUser.fetching,
  }
}

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    fetchCountries: () => {
      dispatch(fetchCountries());
    },
    fetchUser: (id) => {
      dispatch(fetchUser(id));
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(UserViewPageContainer)