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

class GymViewPageContainer extends Component {
  constructor(props) {
    super(props);
    this.state = {}
  }

  componentWillMount() {
    const gymId = this.props.match.params.id;
    this.props.fetchInstitution(gymId);
  }

  goToEditPageClick() {
    const gymId = this.props.match.params.id;
    this.props.history.push("/institutions/gyms/edit/" + gymId);
  }

  goToRolesPageClick() {
    this.props.history.push(this.props.match.url + '/roles');
  }

  render() {
    const {fetching, gym} = this.props;

    if (fetching) {
      return (<Spinner/>);
    }
    if (!fetching && gym == undefined) {
      return (
        <div></div>
        );
    }


    const header = <div><strong>{ gym.name }</strong>
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
                              <UserAvatar size="150" name={ gym.name } src={ gym.logo } />
                            </div>
                            <div className="col-md-6">
                              <InstitutionGeneralInformaitonBlock name={ gym.name } address={ gym.address + ", " + gym.city + ", " + gym.zipCode + ", " + gym.country.name } owner={ gym.owner } contactPerson={ gym.contactPerson } email={ gym.email }
                                phone={ gym.phone } />
                            </div>
                          </div>
                        </div>
                        <div className="col-md-6">
                          <div className="row justify-content-end">
                            { gym.facebook && <a href={ gym.facebook } target="_blank">
                                                <button type="button" className="btn  btn-facebook">
                                                  <span>Facebook</span>
                                                </button> </a> }
                            { gym.twitter && <a href={ gym.twitter } target="_blank">
                                               <button type="button" className="btn  btn-twitter">
                                                 <span>Twitter</span>
                                               </button> </a> }
                            { gym.instagram && <a href={ gym.instagram } target="_blank">
                                                 <button type="button" className="btn btn-instagram">
                                                   <span>Instagram</span>
                                                 </button> </a> }
                            { gym.vk && <a href={ gym.vk } target="_blank">
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
    gym: state.SingleInstitution.institution,
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

export default connect(mapStateToProps, mapDispatchToProps)(GymViewPageContainer)