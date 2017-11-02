import React, { Component } from "react";
import Accordion from "../Widgets/Accordion";
import "../Styles/accord.css";
class UserDetailsPage extends Component {
  render() {
    return (
      <Accordion
        classParentString="card-override"
        triggerClassName="card-header"
        triggerOpenedClassName="card-header">
        <div data-trigger="User details">
          <div className="card-body">{this.props.content}</div>
        </div>

        <div data-trigger="Fights">
          <p>
            An Accordion is different to a Collapsible in the sense that only
            one "tray" will be open at any one time.
          </p>
        </div>

        <div data-trigger="Documents">
          <p>
            And this Accordion component is also completely repsonsive. Hurrah
            for mobile users!
          </p>
        </div>
      </Accordion>
    );
  }
}

export default UserDetailsPage;
