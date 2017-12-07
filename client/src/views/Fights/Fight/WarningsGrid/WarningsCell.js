import React from "react";
import Col from "../../../../components/Layout/Col";
import Row from "../../../../components/Layout/Row";

export const WarningsCell = props => {
    const red = props.points.redFighterPoints;
    const blue = props.points.blueFighterPoints;
    const redCautions = red !== null ? red.cautions : "-";
    const blueCautions = blue !== null ? blue.cautions : "-";

    const redKnockDown = red !== null ? red.knockDown : "-";
    const blueKnockDown = blue !== null ? blue.knockDown : "-";

    const redWarnings = red !== null ? red.warnings : "-";
    const blueWarnings = blue !== null ? blue.warnings : "-";

    const redJ = red !== null ? red.j : "-";
    const blueJ = blue !== null ? blue.j : "-";

    const accepted = (red && red.accepted) ? 'text-primary' : 'text-muted';
    return (
        <td>
            <Row className="justify-content-center ">
                <Col className="col-md-2">
                    <div className={accepted}>
                        {redCautions}/{blueCautions}
                    </div>
                </Col>
                <Col className="col-md-2">
                    <div className={accepted}>
                        {redKnockDown}/{blueKnockDown}
                    </div>
                </Col>
                <Col className="col-md-2">
                    <div className={accepted}>
                        {redWarnings}/{blueWarnings}
                    </div>
                </Col>
                <Col className="col-md-2">
                    <div className={accepted}>
                        {redJ}/{blueJ}
                    </div>
                </Col>
            </Row>
        </td>
    );
};

export default WarningsCell;
