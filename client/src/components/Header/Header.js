import React, { Component } from 'react';
import { Dropdown, DropdownMenu, DropdownItem } from 'reactstrap';
import { NavLink } from 'react-router-dom'
import UserAvatar from 'react-user-avatar'

class Header extends Component {

  constructor(props) {
    super(props);

    this.toggle = this.toggle.bind(this);
    this.state = {
      dropdownOpen: false
    };
    document.body.classList.toggle('aside-menu-hidden');
  }



  toggle() {
    this.setState({
      dropdownOpen: !this.state.dropdownOpen
    });
  }

  sidebarToggle(e) {
    e.preventDefault();
    document.body.classList.toggle('sidebar-hidden');
  }

  sidebarMinimize(e) {
    e.preventDefault();
    document.body.classList.toggle('sidebar-minimized');
  }

  mobileSidebarToggle(e) {
    e.preventDefault();
    document.body.classList.toggle('sidebar-mobile-show');
  }

  asideToggle(e) {
    e.preventDefault();
    document.body.classList.toggle('aside-menu-hidden');
  }

  render() {
    return (
      <header className="app-header navbar">
        <button className="navbar-toggler mobile-sidebar-toggler d-lg-none" type="button" onClick={ this.mobileSidebarToggle }>☰</button>
        <a className="navbar-brand" href="#"></a>
        <ul className="nav navbar-nav d-md-down-none">
          <li className="nav-item">
            <button className="nav-link navbar-toggler sidebar-toggler" type="button" onClick={ this.sidebarToggle }>☰</button>
          </li>
          <li className="nav-item px-3">
            <a className="nav-link" href="#">Dashboard</a>
          </li>
          <li className="nav-item px-3">
            <a className="nav-link" href="#">Users</a>
          </li>
          <li className="nav-item px-3">
            <a className="nav-link" href="#">Settings</a>
          </li>
        </ul>
        <ul className="nav navbar-nav ml-auto">
          <li className="nav-item d-md-down-none">
            <a className="nav-link" href="#"><i className="icon-bell"></i></a>
          </li>
          <li className="nav-item">
            <Dropdown isOpen={ this.state.dropdownOpen } toggle={ this.toggle }>
              <button onClick={ this.toggle } className="nav-link" data-toggle="dropdown" type="button" aria-haspopup="true" aria-expanded={ this.state.dropdownOpen }>
                <UserAvatar size="40" name={ this.props.username } src="http://dc-centrum.pl/wp-content/uploads/avatar-1.png" className="float-left" />
                <div className="float-left" style={ { lineHeight: 3, paddingLeft: 10 } }>
                  <span className="d-md-down-none">{ this.props.username }</span>
                </div>
                <div className="float-left" style={ { lineHeight: 3, paddingLeft: 5 } }> <span className="dropdown-toggle"></span></div>
              </button>
              <DropdownMenu className="dropdown-menu-right">
                <DropdownItem header className="text-center">
                  <strong>Account</strong>
                </DropdownItem>
                <DropdownItem onClick={ this.props.gotoProfile }>
                  <i className="fa fa-user"></i> Profile
                </DropdownItem>
                <DropdownItem><i className="fa fa-wrench"></i> Settings</DropdownItem>
                <DropdownItem><i className="fa fa-usd"></i> Payments</DropdownItem>
                <DropdownItem onClick={ this.props.logout }><i className="fa fa-lock"></i> Logout</DropdownItem>
              </DropdownMenu>
            </Dropdown>
          </li>
        </ul>
      </header>
    )
  }
}

export default Header;
