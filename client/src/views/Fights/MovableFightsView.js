import React, { Component } from "react";
import Page from "../Components/Page";
import FightMoveListItem from "../Fights/List/FightMoveListItem";
import { DragDropContext } from "react-dnd";
import HTML5Backend from "react-dnd-html5-backend";
import { TabContent, TabPane, Nav, NavItem, NavLink } from "reactstrap";
import classnames from "classnames";

export class ContestFightsView extends Component {
    constructor(props) {
        super(props);
        this.toggle = this.toggle.bind(this);
        this.state = {
            activeTab: "1"
        };
    }

    toggle(tab) {
        if (this.state.activeTab !== tab) {
            this.setState({
                activeTab: tab
            });
        }
    }

    render() {
        const { fights, tossupJudgesClick, scheduleFightsClick, tossingup, dragFight, moveFight, openFight, scheduling } = this.props;
        const header = <strong>Fights list</strong>;
        const mappedFights = fights.map((fight, index) => (
            <FightMoveListItem key={index} number={index + 1} fight={fight} moveFight={moveFight} dragFight={dragFight} openFight={openFight.bind(this, fight.id)} />
        ));
        const fightsRingA = fights
            .filter(fight => fight.ring === "A")
            .map((fight, index) => <FightMoveListItem key={index} number={index + 1} fight={fight} moveFight={moveFight} dragFight={dragFight} openFight={openFight.bind(this, fight.id)} />);
        const fightsRingB = fights
            .filter(fight => fight.ring === "B")
            .map((fight, index) => <FightMoveListItem key={index} number={index + 1} fight={fight} moveFight={moveFight} dragFight={dragFight} openFight={openFight.bind(this, fight.id)} />);
        const fightsRingC = fights
            .filter(fight => fight.ring === "C")
            .map((fight, index) => <FightMoveListItem key={index} number={index + 1} fight={fight} moveFight={moveFight} dragFight={dragFight} openFight={openFight.bind(this, fight.id)} />);

        const content = (
            <div>
                <div className="row justify-content-end">
                    <div className="col-md-1">
                        <div className="btn btn-success pull-right" onClick={scheduleFightsClick}>
                            {scheduling && <i className="fa fa-spinner fa-spin fa-1x fa-fw" />}
                            Schedule fights
                        </div>
                    </div>
                    <div className="col-md-1">
                        <div className="btn btn-primary pull-right" onClick={tossupJudgesClick}>
                            {tossingup && <i className="fa fa-spinner fa-spin fa-1x fa-fw" />}
                            Tossup judges
                        </div>
                    </div>
                </div>
                <Nav tabs>
                    <NavItem>
                        <NavLink
                            className={classnames({
                                active: this.state.activeTab === "1"
                            })}
                            onClick={() => {
                                this.toggle("1");
                            }}
                        >
                            <i className="fa fa-hand-rock-o" /> All fights  <span className="badge badge-pill badge-primary"> {mappedFights.length}</span>
                        </NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink
                            className={classnames({
                                active: this.state.activeTab === "2"
                            })}
                            onClick={() => {
                                this.toggle("2");
                            }}
                        >
                            <i className="fa fa-hand-rock-o" /> Ring A<span className="badge badge-pill badge-info"> {fightsRingA.length}</span>
                        </NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink
                            className={classnames({
                                active: this.state.activeTab === "3"
                            })}
                            onClick={() => {
                                this.toggle("3");
                            }}
                        >
                            <i className="fa fa-hand-rock-o" /> Ring B <span className="badge badge-pill badge-info"> {fightsRingB.length}</span>
                        </NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink
                            className={classnames({
                                active: this.state.activeTab === "4"
                            })}
                            onClick={() => {
                                this.toggle("4");
                            }}
                        >
                            <i className="fa fa-hand-rock-o" /> Ring C <span className="badge badge-pill badge-info"> {fightsRingC.length}</span>
                        </NavLink>
                    </NavItem>
                </Nav>
                <TabContent activeTab={this.state.activeTab}>
                    <TabPane tabId="1">{mappedFights}</TabPane>
                    <TabPane tabId="2">{fightsRingA}</TabPane>
                    <TabPane tabId="3">{fightsRingB}</TabPane>
                    <TabPane tabId="4">{fightsRingC}</TabPane>
                </TabContent>
            </div>
        );

        return <Page header={header} content={content} />;
    }
}

export default DragDropContext(HTML5Backend)(ContestFightsView);
