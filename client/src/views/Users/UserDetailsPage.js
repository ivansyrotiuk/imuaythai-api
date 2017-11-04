import React, { Component } from "react";
import Accordion from "../Widgets/Accordion";
import DocumentContainer from "../../containers/Users/UserDocumentContainer";
import UserDetails from "./UserDetails";
import "../Styles/accord.css";
class UserDetailsPage extends Component {
  render() {
    return (
      <div className="animated fadeIn">
        <div className="row">
          <div className="col-12">
            <Accordion
              classParentString="card-override"
              triggerClassName="card-header"
              triggerOpenedClassName="card-header"
              contentInnerClassName="card-content">
              <div data-trigger="User details">
                <div className="card-body">
                  <UserDetails user={this.props.user} />
                </div>
              </div>

              <div data-trigger="Fights">
                <p>
                  An Accordion is different to a Collapsible in the sense that
                  only one "tray" will be open at any one time.
                </p>
              </div>

              <div data-trigger="Documents">
                <DocumentContainer type="user" id={this.props.user.id} />
              </div>
            </Accordion>
          </div>
        </div>
      </div>
    );
  }
}

export default UserDetailsPage;
