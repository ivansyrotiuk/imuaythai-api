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

class WorldFederationViewPageContainer extends Component {
    constructor(props) {
        super(props);
        this.state = {}
    }

    componentWillMount() {
        const worldId = this.props.match.params.id;
        this.props.fetchInstitution(worldId);
    }

    goToEditPageClick() {
        const worldId = this.props.match.params.id;
        this.props.history.push("/institutions/world/edit/" + worldId);
    }



    render() {
        const {fetching, worldFederation} = this.props;

        if (fetching) {
            return (<Spinner/>);
        }
        if (!fetching && worldFederation == undefined) {
            return (
                <div></div>
                );
        }


        const header = <div><strong>{ worldFederation.name }</strong>
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
                                  <UserAvatar size="150" name={ worldFederation.name } src={ worldFederation.logo } />
                                </div>
                                <div className="col-md-6">
                                  <InstitutionGeneralInformaitonBlock name={ worldFederation.name } address={ worldFederation.address + ", " + worldFederation.city + ", " + worldFederation.zipCode + ", " + worldFederation.country.name } owner={ worldFederation.owner } contactPerson={ worldFederation.contactPerson } email={ worldFederation.email }
                                    phone={ worldFederation.phone } />
                                </div>
                              </div>
                            </div>
                            <div className="col-md-6">
                              <div className="row justify-content-end">
                                { worldFederation.facebook && <a href={ worldFederation.facebook } target="_blank">
                                                                <button type="button" className="btn  btn-facebook">
                                                                  <span>Facebook</span>
                                                                </button> </a> }
                                { worldFederation.twitter && <a href={ worldFederation.twitter } target="_blank">
                                                               <button type="button" className="btn  btn-twitter">
                                                                 <span>Twitter</span>
                                                               </button> </a> }
                                { worldFederation.instagram && <a href={ worldFederation.instagram } target="_blank">
                                                                 <button type="button" className="btn btn-instagram">
                                                                   <span>Instagram</span>
                                                                 </button> </a> }
                                { worldFederation.vk && <a href={ worldFederation.vk } target="_blank">
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
        worldFederation: state.SingleInstitution.institution,
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

export default connect(mapStateToProps, mapDispatchToProps)(WorldFederationViewPageContainer)