import React, { Component } from "react";
import FightCountCard from "./UserFightDetails/FightCountCard";

export default class UserFightDetails extends Component {
  render() {
    return (
      <div>
        <div className="row">
          <FightCountCard count="0" text="fights" />
          <FightCountCard count="0" text="win" />
          <FightCountCard count="0" text="lost" />
        </div>
      </div>
    );
  }
}
