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
import InstitutionGeneralInformaitonBlock from "../../../views/Components/InstitutionGeneralInformaitonBlock"

class NationalFederationViewPageContainer extends Component {
  constructor(props) {
    super(props);
    this.state = {}
  }

  componentWillMount() {
    const nationalId = this.props.match.params.id;
    this.props.fetchInstitution(nationalId);
  }

  goToEditPageClick() {
    const nationalId = this.props.match.params.id;
    this.props.history.push("/institutions/national/edit/" + nationalId);
  }



  render() {
    const {fetching, nationalFederation} = this.props;

    if (fetching) {
      return (<Spinner/>);
    }
    if (!fetching && nationalFederation == undefined) {
      return (
        <div></div>
        );
    }


    const header = <div><strong>{ nationalFederation.name }</strong>
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

    const content = <div className="col-md-12">
                      <div className="row">
                        <div className="col-md-6">
                          <div className="row">
                            <div className="col-md-6">
                              <UserAvatar size="150" name={ nationalFederation.name } src={ nationalFederation.logo } />
                            </div>
                            <div className="col-md-6">
                              <InstitutionGeneralInformaitonBlock name={ nationalFederation.name } address={ nationalFederation.address + ", " + nationalFederation.city + ", " + nationalFederation.zipCode + ", " + nationalFederation.country.name } owner={ nationalFederation.owner } contactPerson={ nationalFederation.contactPerson } email={ nationalFederation.email }
                                phone={ nationalFederation.phone } />
                            </div>
                          </div>
                        </div>
                        <div className="col-md-6">
                          <div className="row justify-content-end">
                            { nationalFederation.facebook && <a href={ nationalFederation.facebook } target="_blank">
                                                               <button type="button" className="btn  btn-facebook">
                                                                 <span>Facebook</span>
                                                               </button> </a> }
                            { nationalFederation.twitter && <a href={ nationalFederation.twitter } target="_blank">
                                                              <button type="button" className="btn  btn-twitter">
                                                                <span>Twitter</span>
                                                              </button> </a> }
                            { nationalFederation.instagram && <a href={ nationalFederation.instagram } target="_blank">
                                                                <button type="button" className="btn btn-instagram">
                                                                  <span>Instagram</span>
                                                                </button> </a> }
                            { nationalFederation.vk && <a href={ nationalFederation.vk } target="_blank">
                                                         <button type="button" className="btn  btn-vk">
                                                           <span>VK</span>
                                                         </button>
                                                       </a> }
                          </div>
                        </div>
                      </div>
                    </div>

    return <Page header={ header } content={ content } />
  }
}

const mapStateToProps = (state, ownProps) => {
  return {
    nationalFederation: state.SingleInstitution.institution,
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

export default connect(mapStateToProps, mapDispatchToProps)(NationalFederationViewPageContainer)