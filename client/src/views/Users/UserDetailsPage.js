import React, { Component } from "react";
import Collapsible from "react-collapsible";
import DocumentContainer from "../../containers/Users/UserDocumentContainer";
import UserDetails from "./UserDetails";
import UserFightDetails from "./UserFightDetails";
import "../Styles/accord.css";
class UserDetailsPage extends Component {
  render() {
    return (
      <div className="animated fadeIn">
        <div className="row">
          <div className="col-12">
            <Collapsible
              trigger="User details"
              triggerClassName="card-header"
              triggerOpenedClassName="card-header"
              contentInnerClassName="card-content"
              classParentString="card-override"
              open={true}>
              <div className="card-body">
                <UserDetails user={this.props.user} />
              </div>
            </Collapsible>

            <Collapsible
              trigger="Fights"
              triggerClassName="card-header"
              triggerOpenedClassName="card-header"
              contentInnerClassName="card-content"
              classParentString="card-override">
              <UserFightDetails />
            </Collapsible>

            <Collapsible
              trigger="Documents"
              triggerClassName="card-header"
              triggerOpenedClassName="card-header"
              contentInnerClassName="card-content"
              classParentString="card-override">
              <DocumentContainer type="user" id={this.props.user.id} />
            </Collapsible>
          </div>
        </div>
      </div>
    );
  }
}

export default UserDetailsPage;
