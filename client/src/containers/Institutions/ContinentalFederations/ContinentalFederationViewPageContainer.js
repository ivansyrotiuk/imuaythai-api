import React, { Component } from 'react';
import { Link } from 'react-router-dom'
import { connect } from "react-redux";
import { ButtonDropdown, DropdownItem, DropdownToggle, Button, DropdownMenu } from 'reactstrap';
import axios from "axios";
import UserAvatar from 'react-user-avatar'
import Spinner from "../../../views/Components/Spinners/Spinner";
import { fetchCountries } from "../../../actions/CountriesActions";
import { fetchInstitution } from "../../../actions/InstitutionsActions";
import moment from 'moment';
import Page from "../../../views/Components/Page"

class ContinentalFederationViewPageContainer extends Component {
  constructor(props) {
    super(props);
    this.state = {}
  }

  componentWillMount() {
    const federationId = this.props.match.params.id;
    this.props.fetchInstitution(federationId);
  }

  goToEditPageClick() {
    this.props.history.push(this.props.match.url + '/edit');
  }

  goToRolesPageClick() {
    this.props.history.push(this.props.match.url + '/roles');
  }

  render() {
    const {fetching, federation} = this.props;

    if (fetching) {
      return (<Spinner/>);
    }
    if (!fetching && federation == undefined) {
      return (
        <div></div>
        );
    }


    const header = <div><strong>Continental Federation</strong>
                     <div className="pull-right">
                       <div className="input-group-btn">
                         <ButtonDropdown isOpen={ this.state.fourth } toggle={ () => {
                                                                                 this.setState({
                                                                                   fourth: !this.state.fourth
                                                                                 });
                                                                               } }>
                           <DropdownToggle caret color="link">
                             <i className="fa fa-bars" aria-hidden="true"></i>
                           </DropdownToggle>
                           <DropdownMenu className="dropdown-menu-right">
                             <DropdownItem onClick={ this.goToEditPageClick.bind(this) }>
                               <i className="fa fa-pencil" aria-hidden="true"></i>  Edit
                             </DropdownItem>
                           </DropdownMenu>
                         </ButtonDropdown>
                       </div>
                     </div>
                   </div>

    const content = <div className="row">
                      <div className="col-12 col-md-auto col-sm-6">
                        <UserAvatar size="150" name={ federation.name } />
                        <div className="caption">
                          <button type="button" className="btn btn-link">
                            <i className="fa fa-pencil"></i>  Change photo
                          </button>
                        </div>
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
                          { federation.facebook && <a href={ federation.facebook } target="_blank">
                                                     <button type="button" className="btn  btn-facebook">
                                                       <span>Facebook</span>
                                                     </button> </a> }
                          { federation.twitter && <a href={ federation.twitter } target="_blank">
                                                    <button type="button" className="btn  btn-twitter">
                                                      <span>Twitter</span>
                                                    </button> </a> }
                          { federation.instagram && <a href={ federation.instagram } target="_blank">
                                                      <button type="button" className="btn btn-instagram">
                                                        <span>Instagram</span>
                                                      </button> </a> }
                          { federation.vk && <a href={ federation.vk } target="_blank">
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
    federation: state.SingleInstitution.institution,
    fetching: state.SingleInstitution.fetching
  }
}

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    fetchInstitution: (id) => {
      dispatch(fetchInstitution(id));
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(ContinentalFederationViewPageContainer)