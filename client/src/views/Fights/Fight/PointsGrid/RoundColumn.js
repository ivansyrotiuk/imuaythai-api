import React from "react";
import Row from "../../../../components/Layout/Row";

export const RoundColumn = props => {
    return <th className="col-md-auto">
        <Row className="justify-content-center">Round {props.roundNumber}</Row>
    </th>;
};

export default RoundColumn;
