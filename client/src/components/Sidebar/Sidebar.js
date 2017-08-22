import React, { Component } from 'react';
import { NavLink } from 'react-router-dom'

import { userIsAdmin, userCanManageRoles, userCanSeeContests } from '../../auth/auth'

class Sidebar extends Component {

  handleClick(e) {
    e.preventDefault();
    e.target.parentElement.classList.toggle('open');
  }

  activeRoute(routeName) {
    return this.props.location.pathname.indexOf(routeName) > -1 ? 'nav-item nav-dropdown open' : 'nav-item nav-dropdown';
  }

  // secondLevelActive(routeName) {
  //   return this.props.location.pathname.indexOf(routeName) > -1 ? "nav nav-second-level collapse in" : "nav nav-second-level collapse";
  // }

  render() {

    const FigthersLink = userIsAdmin(() => <NavLink to="/fighters" className="nav-link" activeClassName="active"><i className="fa fa-user"></i> Fighters</NavLink>)
    const JudgesLink = userIsAdmin(() => <NavLink to="/judges" className="nav-link" activeClassName="active"><i className="fa fa-gavel"></i> Judges</NavLink>)
    const CoachesLink = userIsAdmin(() => <NavLink to="/coaches" className="nav-link" activeClassName="active"><i className="fa fa-male"></i> Coaches</NavLink>)
    const DoctorsLink = userIsAdmin(() => <NavLink to="/doctors" className="nav-link" activeClassName="active"><i className="fa fa-user-md"></i> Doctors</NavLink>)

    const GymsLink = userIsAdmin(() => <NavLink to="/institutions/gyms" className="nav-link" activeClassName="active"><i className="fa fa-flag"></i> Gyms</NavLink>);
    const NationalFederationsLink = userIsAdmin(() => <NavLink to="/institutions/national" className="nav-link" activeClassName="active"><i className="fa fa-building"></i> National federations</NavLink>)
    const ContinetalFederationsLink = userIsAdmin(() => <NavLink to="/institutions/continental" className="nav-link" activeClassName="active"><i className="fa fa-building"></i> Continental federations</NavLink>)
    const WorldFederationsLink = userIsAdmin(() => <NavLink to="/institutions/world" className="nav-link" activeClassName="active"><i className="fa fa-globe "></i> World federations</NavLink>)
    const ContestsDropdown = userCanSeeContests(() => <li className={ this.activeRoute("/contests") }>
                                                        <a className="nav-link nav-dropdown-toggle" href="#" onClick={ this.handleClick.bind(this) }><i className="fa fa-trophy"></i> Contests</a>
                                                        <ul className="nav-dropdown-items">
                                                          <li className="nav-item">
                                                            <NavLink to="/contests" className="nav-link" activeClassName="active"><i className="fa fa-trophy"></i>Contests list</NavLink>
                                                          </li>
                                                          <li className="nav-item">
                                                            <NavLink to="/fight" className="nav-link" activeClassName="active"><i className="fa fa-bar-chart"></i>Fight draw demo</NavLink>
                                                          </li>
                                                        </ul>
                                                      </li>)


    const UserRoleRequestLink = userCanManageRoles(() => <NavLink to="/users/role_requests" className="nav-link" activeClassName="active"><i className="fa fa-user-plus"></i> Role requests</NavLink>)

    return (
      <div className="sidebar">
        <nav className="sidebar-nav">
          <ul className="nav">
            <li className="nav-item">
              <NavLink to={ '/dashboard' } className="nav-link" activeClassName="active"><i className="icon-speedometer"></i> Dashboard <span className="badge badge-info">NEW</span></NavLink>
            </li>
            <li className={ this.activeRoute("/institutions") }>
              <a className="nav-link nav-dropdown-toggle" href="#" onClick={ this.handleClick.bind(this) }><i className="fa fa-university"></i> Institutions</a>
              <ul className="nav-dropdown-items">
                <li className="nav-item">
                  <GymsLink />
                </li>
                <li className="nav-item">
                  <NationalFederationsLink />
                </li>
                <li className="nav-item">
                  <ContinetalFederationsLink />
                </li>
                <li className="nav-item">
                  <WorldFederationsLink />
                </li>
              </ul>
            </li>
            <li className={ this.activeRoute("/users") }>
              <a className="nav-link nav-dropdown-toggle" href="#" onClick={ this.handleClick.bind(this) }><i className="fa fa-users"></i> Users</a>
              <ul className="nav-dropdown-items">
                <li className="nav-item">
                  <FigthersLink />
                </li>
                <li className="nav-item">
                  <JudgesLink />
                </li>
                <li className="nav-item">
                  <CoachesLink />
                </li>
                <li className="nav-item">
                  <DoctorsLink />
                </li>
                <li className="nav-item">
                  <UserRoleRequestLink />
                </li>
              </ul>
            </li>
            <li className={ this.activeRoute("/dictionaries") }>
              <a className="nav-link nav-dropdown-toggle" href="#" onClick={ this.handleClick.bind(this) }><i className="icon-puzzle"></i> Dictionaries</a>
              <ul className="nav-dropdown-items">
                <li className="nav-item">
                  <NavLink to="/dictionaries/types" className="nav-link" activeClassName="active"><i className="icon-puzzle"></i> Contest types</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to="/dictionaries/ranges" className="nav-link" activeClassName="active"><i className="icon-puzzle"></i> Contest ranges</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to="/dictionaries/levels" className="nav-link" activeClassName="active"><i className="icon-puzzle"></i> Khan levels</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to="/dictionaries/suspensions" className="nav-link" activeClassName="active"><i className="icon-puzzle"></i> Suspension types</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to="/dictionaries/points" className="nav-link" activeClassName="active"><i className="icon-puzzle"></i> Contest points</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to="/dictionaries/weightcategories" className="nav-link" activeClassName="active"><i className="icon-puzzle"></i> Weight categories</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to="/dictionaries/rounds" className="nav-link" activeClassName="active"><i className="icon-puzzle"></i> Rounds</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to="/dictionaries/structures" className="nav-link" activeClassName="active"><i className="icon-puzzle"></i> Fight structures</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to="/dictionaries/categories" className="nav-link" activeClassName="active"><i className="icon-puzzle"></i> Contest categories</NavLink>
                </li>
              </ul>
            </li>
            <ContestsDropdown/>
            <li className="nav-title">
              UI Elements
            </li>
            <li className={ this.activeRoute("/components") }>
              <a className="nav-link nav-dropdown-toggle" href="#" onClick={ this.handleClick.bind(this) }><i className="icon-puzzle"></i> Components</a>
              <ul className="nav-dropdown-items">
                <li className="nav-item">
                  <NavLink to={ '/components/buttons' } className="nav-link" activeClassName="active"><i className="icon-puzzle"></i> Buttons</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to={ '/components/social-buttons' } className="nav-link" activeClassName="active"><i className="icon-puzzle"></i> Social Buttons</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to={ '/components/cards' } className="nav-link" activeClassName="active"><i className="icon-puzzle"></i> Cards</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to={ '/components/forms' } className="nav-link" activeClassName="active"><i className="icon-puzzle"></i> Forms</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to={ '/components/modals' } className="nav-link" activeClassName="active"><i className="icon-puzzle"></i> Modals</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to={ '/components/switches' } className="nav-link" activeClassName="active"><i className="icon-puzzle"></i> Switches</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to={ '/components/tables' } className="nav-link" activeClassName="active"><i className="icon-puzzle"></i> Tables</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to={ '/components/tabs' } className="nav-link" activeClassName="active"><i className="icon-puzzle"></i> Tabs</NavLink>
                </li>
              </ul>
            </li>
            <li className={ this.activeRoute("/icons") }>
              <a className="nav-link nav-dropdown-toggle" href="#" onClick={ this.handleClick.bind(this) }><i className="icon-star"></i> Icons</a>
              <ul className="nav-dropdown-items">
                <li className="nav-item">
                  <NavLink to={ '/icons/font-awesome' } className="nav-link" activeClassName="active"><i className="icon-star"></i> Font Awesome</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to={ '/icons/simple-line-icons' } className="nav-link" activeClassName="active"><i className="icon-star"></i> Simple Line Icons</NavLink>
                </li>
              </ul>
            </li>
            <li className="nav-item">
              <NavLink to={ '/widgets' } className="nav-link" activeClassName="active"><i className="icon-calculator"></i> Widgets <span className="badge badge-info">NEW</span></NavLink>
            </li>
            <li className="nav-item">
              <NavLink to={ '/charts' } className="nav-link" activeClassName="active"><i className="icon-pie-chart"></i> Charts</NavLink>
            </li>
            <li className="divider"></li>
            <li className="nav-title">
              Extras
            </li>
            <li className="nav-item nav-dropdown">
              <a className="nav-link nav-dropdown-toggle" href="#" onClick={ this.handleClick.bind(this) }><i className="icon-star"></i> Pages</a>
              <ul className="nav-dropdown-items">
                <li className="nav-item">
                  <NavLink to={ '/login' } className="nav-link" activeClassName="active"><i className="icon-star"></i> Login</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to={ '/register' } className="nav-link" activeClassName="active"><i className="icon-star"></i> Register</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to={ '/404' } className="nav-link" activeClassName="active"><i className="icon-star"></i> Error 404</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink to={ '/500' } className="nav-link" activeClassName="active"><i className="icon-star"></i> Error 500</NavLink>
                </li>
              </ul>
            </li>
          </ul>
        </nav>
      </div>
    )
  }
}

export default Sidebar;
