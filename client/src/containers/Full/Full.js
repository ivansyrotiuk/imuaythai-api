import React, { Component } from 'react';
import { Link, Switch, Route, Redirect } from 'react-router-dom'
import Header from '../../components/Header/';
import Sidebar from '../../components/Sidebar/';
import Breadcrumb from '../../components/Breadcrumb/';
import Aside from '../../components/Aside/';
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
import GymsPage from "../../views/Institutions/GymsPage"
import GymDetailsPage from "../../views/Institutions/GymDetailsPage"
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

import FightersPage from "../../views/Users/Fighters/FightersPage"
import JudgesPage from "../../views/Users/Judges/JudgesPage"
import CoachesPage from "../../views/Users/Coaches/CoachesPage"
import DoctorsPage from "../../views/Users/Doctors/DoctorsPage"

import UserEditPage from "../../views/Users/UserEditPage"
import UserViewPage from "../../views/Users/UserViewPage"

import UserRolesPage from "../../views/Users/UserRolesPage"
import RoleRequestsPage from "../../views/Users/RoleRequestsPage"
import ContestsPage from "../../views/Contest/ContestsPage"
import CreateContest from '../Contest/CreateContestContainer'


class Full extends Component {
  render() {
    return (
      <div className="app">
        <Header/>
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
                <Route path="/gyms/:id" name="Gym" component={ GymDetailsPage } />
                <Route path="/gyms/" name="Gyms" component={ GymsPage } />
                <Route path="/users/(role_requests)" name="RoleRequests" component={ RoleRequestsPage } />
                <Route path="/users/:id/(edit)" name="UserEdit" component={ UserEditPage } />
                <Route path="/users/:id/(roles)" name="UserRoles" component={ UserRolesPage } />
                <Route path="/users/:id" name="User" component={ UserViewPage } />
                <Route path="/fighters/" name="Fighters" component={ FightersPage } />
                <Route path="/judges/" name="Judges" component={ JudgesPage } />
                <Route path="/coaches/" name="Coaches" component={ CoachesPage } />
                <Route path="/doctors/" name="Doctors" component={ DoctorsPage } />
                <Route path="/dictionaries/types" name="ContestTypes" component={ ContestTypesPage } />
                <Route path="/dictionaries/ranges/:id" name="ContestRange" component={ ContestRangesDetailsPage } />
                <Route path="/dictionaries/ranges/" name="ContestRanges" component={ ContestRangesPage } />
                <Route path="/dictionaries/levels/:id" name="KhanLevel" component={ KhanLevelsDetailsPage } />
                <Route path="/dictionaries/levels/" name="KhanLevels" component={ KhanLevelsPage } />
                <Route path="/dictionaries/levels" name="KhanLevels" component={ KhanLevelsPage } />
                <Route path="/dictionaries/suspensions/:id" name="SuspensionType" component={ SuspensionsDetailsPage } />
                <Route path="/dictionaries/suspensions/" name="SuspensionTypes" component={ SuspensionTypesPage } />
                <Route path="/dictionaries/suspensions" name="SuspensionTypes" component={ SuspensionTypesPage } />
                <Route path="/dictionaries/points/:id" name="ContestPoint" component={ ContestPointsDetailsPage } />
                <Route path="/dictionaries/points/" name="ContestPoints" component={ ContestPointsPage } />
                <Route path="/dictionaries/points" name="ContestPoints" component={ ContestPointsPage } />
                <Route path="/contests/add" name="Create contest" component={ CreateContest } />
                <Route path="/contests/:id/edit" name="Edit contest" component={ CreateContest } />
                <Route path="/contests/" name="Contests" component={ ContestsPage } />
                <Redirect from="/" to="/dashboard" />
              </Switch>
            </div>
          </main>
          <Aside/>
        </div>
        <Footer/>
      </div>
      );
  }
}

export default Full;
