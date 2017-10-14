import React from "react";
import { ListGroup, ListGroupItem, Badge } from "reactstrap";
import Page from "../Components/Page";
import FighterMoveListItem from "./List/FighterMoveListItem";
import { DragDropContext } from "react-dnd";
import HTML5Backend from "react-dnd-html5-backend";

export const FightsListView = props => {
    const header = <strong>Fights list</strong>;
    const mappedFights = props.fights.map((fight, index) => (
        <FighterMoveListItem key={index} number={index + 1} fight={fight} openFight={props.openFight.bind(props, fight.id)} />
    ));

    return <Page header={header} content={mappedFights} />;
};
export default DragDropContext(HTML5Backend)(FightsListView);
