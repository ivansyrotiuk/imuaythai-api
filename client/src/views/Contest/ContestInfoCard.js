import React, { Component } from "react";
import EditButton from "../Components/Buttons/EditButton";
import moment from "moment";
import {
  userCanAcceptContestRequest,
  userCanAddContestRequest
} from "../../auth/auth";
import Col from "../../components/Layout/Col";
import Row from "../../components/Layout/Row";
import SocialNetworksBox from "../../components/Social/SocialNetworksBox";

export default class ContestInfoCard extends Component {
  render() {
    const {
      contest, editContestClick,
      pendingRequestsClick,
      addRequestClick,
      contestCategoriesClick,
      contestFightsClick,
      manageJudgesClick,
      fightersCount,
        judgesCount,
      doctorsCount,
      pendingCount
    } = this.props;

    const PendingRequestsButton = userCanAcceptContestRequest(() => (
      <Col className="col-sm-2">
        <div className="btn btn-warning btn-block" onClick={pendingRequestsClick} >
          <div>Pending requests</div>
        </div>
      </Col>
    ));

    const ContestCategoriesButton = userCanAcceptContestRequest(() => (
      <Col className="col-sm-2">
        <div className="btn btn-success btn-block" onClick={contestCategoriesClick} >
          <div>Categories</div>
        </div>
      </Col>
    ));

    const ContestFightsButton = userCanAcceptContestRequest(() => (
      <Col className="col-sm-2">
        <div className="btn btn-success btn-block" onClick={contestFightsClick}>
          <div>Fights</div>
        </div>
      </Col>
    ));

    const JudgesManageButton = userCanAcceptContestRequest(() => (
      <Col className="col-sm-2">
        <div className="btn btn-success btn-block" onClick={manageJudgesClick}>
          <div>Manage judges</div>
        </div>
      </Col>
    ));

    const AddRequestsButton = userCanAddContestRequest(() => (
      <Col className="col-sm-2">
        <div className="btn btn-primary btn-block" onClick={addRequestClick}>
          <div>Add request</div>
        </div>
      </Col>
    ));
    return (

          <Row>
            <div className="col-md-3">
              <img src="/img/contest_poster.jpg" className="img-thumbnail" />
            </div>
            <div className="col-md-9">
              <Row>
                <p className="h1">{contest.name}</p>
              </Row>
              <Row>
                <h3>
                  {contest.country && contest.country.name},{" "}
                  {moment(contest.date).format("YYYY.DD.MM")} -{" "}
                  {moment(contest.date)
                    .add("days", contest.duration)
                    .format("YYYY.DD.MM")}
                </h3>
              </Row>
              <Row>
                <h6>
                  {contest.city}, {contest.address}
                </h6>
              </Row>
              <Row>
                <h6>
                  Organizator: {contest.institution && contest.institution.name}
                </h6>
              </Row>
              <Row>
                <h6>
                  Website:{" "}
                  <a href={contest.website} target="_blank">
                    {contest.website}
                  </a>
                </h6>
              </Row>
              <Row>

                <SocialNetworksBox {...contest}/>
              </Row>
              <Row>
                <div className="h6">Registration statistic</div>
              </Row>
              <Row>
                <Col className="col-sm-3">
                  <div className="callout callout-warning">
                    <small className="text-muted">Pending requests</small>
                    <br />
                    <strong className="h4">{pendingCount}</strong>
                  </div>
                </Col>
                <Col className="col-sm-3">
                  <div className="callout callout-info">
                    <small className="text-muted">Fighters</small>
                    <br />
                    <strong className="h4">{fightersCount}</strong>
                  </div>
                </Col>
                <Col className="col-sm-3">
                  <div className="callout callout-success">
                    <small className="text-muted">Judges</small>
                    <br />
                    <strong className="h4">{judgesCount}</strong>
                  </div>
                </Col>
                <Col className="col-sm-3">
                  <div className="callout callout-danger">
                    <small className="text-muted">Doctors</small>
                    <br />
                    <strong className="h4">{doctorsCount}</strong>
                  </div>
                </Col>
              </Row>

              <Row>
                <ContestCategoriesButton />
                <ContestFightsButton />
                <JudgesManageButton />
              </Row>

              <Row className="mt-1">
                <PendingRequestsButton />
                <AddRequestsButton />
              </Row>
            </div>
          </Row>
    );
  }
}
