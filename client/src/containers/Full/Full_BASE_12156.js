import React, { Component } from 'react';
import { Link, Switch, Route, Redirect } from 'react-router-dom'
import Header from '../../containers/Header/HeaderContainer';
import Sidebar from '../../components/Sidebar/';
import Breadcrumb from '../../components/Breadcrumb/';
//import Aside from '../../components/Aside/';
//import {requireAuthentication} from '../../utils/requireAuthentication'

import { userIsAuthenticatedRedir, userIsNotAuthenticatedRedir, userIsAdminRedir, userIsAuthenticated, userIsNotAuthenticated, userIsAdmin } from '../../auth/auth'

import Footer from '../../components/Footer/';
import Dashboard from '../../views/Dashboard/'
import Charts from '../../views/Charts/'
import Widgets from '../../views/Widgets/'
import Buttons from '../../views/Components/Buttons/'
import Cards from '../../views/Components/Cards/'
import Forms from '../../views/Components/Forms/'
import Modals from '../../views/Components/Modals/'
import SocialButtons from '../../views/Components/SocialButtons/'
import Switches from '../../views/Components/Switches/'
import Tables from '../../views/Components/Tables/'
import Tabs from '../../views/Components/Tabs/'
import FontAwesome from '../../views/Icons/FontAwesome/'
import SimpleLineIcons from '../../views/Icons/SimpleLineIcons/'

import ContestTypesPage from "../../views/Dictionaries/ContestTypes/ContestTypesPage"
import ContestTypesDetailsPage from "../../views/Dictionaries/ContestTypes/ContestTypesDetailsPage"
import ContestRangesPage from "../../views/Dictionaries/ContestRanges/ContestRangesPage"
import ContestRangesDetailsPage from "../../views/Dictionaries/ContestRanges/ContestRangesDetailsPage"
import KhanLevelsPage from "../../views/Dictionaries/KhanLevels/KhanLevelsPage"
import KhanLevelsDetailsPage from "../../views/Dictionaries/KhanLevels/KhanLevelsDetailsPage"
import SuspensionTypesPage from "../../views/Dictionaries/SuspensionTypes/SuspensionTypesPage"
import SuspensionsDetailsPage from "../../views/Dictionaries/SuspensionTypes/SuspensionTypesDetailsPage"
import ContestPointsPage from "../../views/Dictionaries/ContestPoints/ContestPointsPage"
import ContestPointsDetailsPage from "../../views/Dictionaries/ContestPoints/ContestPointsDetailsPage"

import GymsPageContainer from "../../containers/Institutions/GymsPageContainer"
import NationalFederationsPageContainer from "../../containers/Institutions/NationalFederationsPageContainer"
import ContinentalFederationsPageContainer from "../../containers/Institutions/ContinentalFederationsPageContainer"
import WorldFederationsPageContainer from "../../containers/Institutions/WorldFederationsPageContainer"
import InstitutionEditPageContainer from "../../containers/Institutions/InstitutionEditPageContainer"

import FightersPageContainer from "../../containers/Users/Fighters/FightersPageContainer"
import JudgesPageContainer from "../../containers/Users/Judges/JudgesPageContainer"
import CoachesPageContainer from "../../containers/Users/Coaches/CoachesPageContainer"
import DoctorsPageContainer from "../../containers/Users/Doctors/DoctorsPageContainer"

import UserEditPageContainer from "../../containers/Users/UserEditPageContainer"
import UserViewPageContainer from "../../containers/Users/UserViewPageContainer"


import UserRolesPageContainer from "../../containers/Users/UserRolesPageContainer"
import RoleRequestsPageContainer from "../../containers/Users/RoleRequestsPageContainer"
import ContestsContainer from "../Contest/ContestsContainer"
import ContestEditContainer from '../Contest/ContestEditContainer'
import ContestViewContainer from '../Contest/ContestViewContainer'
import CreateFightsDiagram from '../Fight/CreateDiagramContainer'

class Full extends Component {
  render() {
    return (
      <div className="app">
        <Header {...this.props}/>
        <div className="app-body">
          <Sidebar {...this.props}/>
          <main className="main">
            <Breadcrumb/>
            <div className="container-fluid">
              <Switch>
                <Route path="/dashboard" name="Dashboard" component={ Dashboard } />
                <Route path="/components/buttons" name="Buttons" component={ Buttons } />
                <Route path="/components/cards" name="Cards" component={ Cards } />
                <Route path="/components/forms" name="Forms" component={ Forms } />
                <Route path="/components/modals" name="Modals" component={ Modals } />
                <Route path="/components/social-buttons" name="Social Buttons" component={ SocialButtons } />
                <Route path="/components/switches" name="Swithces" component={ Switches } />
                <Route path="/components/tables" name="Tables" component={ Tables } />
                <Route path="/components/tabs" name="Tabs" component={ Tabs } />
                <Route path="/icons/font-awesome" name="Font Awesome" component={ FontAwesome } />
                <Route path="/icons/simple-line-icons" name="Simple Line Icons" component={ SimpleLineIcons } />
                <Route path="/widgets" name="Widgets" component={ Widgets } />
                <Route path="/charts" name="Charts" component={ Charts } />
                <Route path="/institutions/add/:type" name="Add institution" component={ InstitutionEditPageContainer } />
                <Route path="/institutions/:id" name="Institution" component={ InstitutionEditPageContainer } />
                <Route path="/gyms/" name="Gyms" component={ GymsPageContainer } />
                <Route path="/federations/national" name="Nationl federations" component={ NationalFederationsPageContainer } />
                <Route path="/federations/continental" name="Continental federation" component={ ContinentalFederationsPageContainer } />
                <Route path="/federations/world" name="World federation" component={ WorldFederationsPageContainer } />
                <Route path="/users/(role_requests)" name="RoleRequests" component={ RoleRequestsPageContainer } />
                <Route path="/users/:id/(edit)" name="UserEdit" component={ UserEditPageContainer } />
                <Route path="/users/:id/(roles)" name="UserRoles" component={ UserRolesPageContainer } />
                <Route path="/users/:id" name="User" component={ UserViewPageContainer } />
                <Route path="/fighters/" name="Fighters" component={ FightersPageContainer } />
                <Route path="/judges/" name="Judges" component={ JudgesPageContainer } />
                <Route path="/coaches/" name="Coaches" component={ CoachesPageContainer } />
                <Route path="/doctors/" name="Doctors" component={ DoctorsPageContainer } />
                <Route path="/dictionaries/types/(name)" name="ContestTypes" component={ ContestTypesDetailsPage } />
                <Route path="/dictionaries/types/:id" name="ContestTypes" component={ ContestTypesDetailsPage } />
                <Route path="/dictionaries/types" name="ContestTypes" component={ ContestTypesPage } />
                <Route path="/dictionaries/ranges/:id" name="ContestRange" component={ ContestRangesDetailsPage } />
                <Route path="/dictionaries/ranges/" name="ContestRanges" component={ ContestRangesPage } />
                <Route path="/dictionaries/levels/:id" name="KhanLevel" component={ KhanLevelsDetailsPage } />;
                <Route path="/dictionaries/levels/" name="KhanLevels" component={ KhanLevelsPage } />
                <Route path="/dictionaries/levels" name="KhanLevels" component={ KhanLevelsPage } />
                <Route path="/dictionaries/suspensions/:id" name="SuspensionType" component={ SuspensionsDetailsPage } />
                <Route path="/dictionaries/suspensions/" name="SuspensionTypes" component={ SuspensionTypesPage } />
                <Route path="/dictionaries/suspensions" name="SuspensionTypes" component={ SuspensionTypesPage } />
                <Route path="/dictionaries/points/:id" name="ContestPoint" component={ ContestPointsDetailsPage } />
                <Route path="/dictionaries/points/" name="ContestPoints" component={ ContestPointsPage } />
                <Route path="/dictionaries/points" name="ContestPoints" component={ ContestPointsPage } />
                <Route path="/contests/add" name="Create contest" component={ ContestEditContainer } />
                <Route path="/contests/:id/(edit)" name="Edit contest" component={ ContestEditContainer } />
                <Route path="/contests/:id" name="Contest view" component={ ContestViewContainer } />
                <Route path="/contests/" name="Contests" component={ ContestsContainer } />
                <Route path="/fight" name="fights" component={ CreateFightsDiagram } />
                <Redirect from="/" to="/dashboard" />
              </Switch>
            </div>
          </main>
        </div>
        <Footer/>
      </div>
      );
  }
}

export default Full;
