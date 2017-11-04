import React, { Component } from "react";
import UserAvatar from "react-user-avatar";
import moment from "moment";

const UserDetails = props => {
  const { user } = props;
  const titleTextSyle = {
    color: "#697078"
  };

  const gender =
    user.gender == "male" ? (
      <h6 style={titleTextSyle}>
        <i className="fa fa-mars" aria-hidden="true" />  Male
      </h6>
    ) : (
      <h6 style={titleTextSyle}>
        <i className="fa fa-venus" aria-hidden="true" />  Female
      </h6>
    );

  const userName = (user.firstname || "No name") + " " + (user.surname || "");

  return (
    <div className="row">
      <div className="col-md-2">
        <UserAvatar
          size="150"
          name={user.firstname + " " + user.surname || user.email}
          src={user.photo}
          style={{ display: "block", margin: "auto" }}
        />
      </div>
      <div className="col-md-3 col-sm-12">
        <h4>Name: {userName}</h4>
        <h4>
          Email: <a href={"mailto:" + user.email}>{user.email}</a>
        </h4>
        <h4>Birthday: {moment(user.birthdate).format("YYYY-MM-DD")}</h4>
        <h4>Age: {user.age}</h4>
      </div>
      <div className="col-md-3 col-sm-12">
        <h4>Gender: {user.gender}</h4>
        <h4>Country: {user.countryName}</h4>
        <h4>Gym: Best fighters ever</h4>
      </div>
      <div className="col-md-4" />
    </div>
  );
};

export default UserDetails;
