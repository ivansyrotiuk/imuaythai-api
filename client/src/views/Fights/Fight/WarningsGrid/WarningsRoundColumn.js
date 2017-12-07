import React from "react";
import Row from "../../../../components/Layout/Row";
import Col from "../../../../components/Layout/Col";

export const WarningsRoundColumn = props => {
    return <th className="col-md-auto">
        <Row className="justify-content-center">Round {props.roundNumber}</Row>
        <Row className="justify-content-center">
            <Col className="col-md-3">C</Col>
            <Col className="col-md-3">KD</Col>
            <Col className="col-md-3">W</Col>
            <Col className="col-md-3">J</Col>
        </Row>
    </th>;
};

export default WarningsRoundColumn;
