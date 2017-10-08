import React from "react";
import moment from "moment";

export const FightInfoBox = props => {
    const { fight } = props;
    const { contest } = fight;
    return (
        <div className="row">
            <div className="col">
                <div className="card">
                    <div className="card-block">
                        <div className="h1 text-muted text-right mb-2">
                            <i className="fa fa-trophy fa-1x" />
                        </div>
                        <div className="h4 mb-0">{contest.name}</div>
                        <small className="text-muted text-uppercase font-weight-bold">Contest</small>
                    </div>
                </div>
            </div>
            <div className="col">
                <div className="card">
                    <div className="card-block">
                        <div className="h1 text-muted text-right mb-2">
                            <i className="fa fa-map-marker fa-1x" />
                        </div>
                        <div className="h4 mb-0">{fight.contest.address + " " + fight.contest.city}</div>
                        <small className="text-muted text-uppercase font-weight-bold">Place</small>
                    </div>
                </div>
            </div>
            <div className="col">
                <div className="card">
                    <div className="card-block">
                        <div className="h1 text-muted text-right mb-2">
                            <i className="fa fa-calendar" />
                        </div>
                        <div className="h4 mb-0">{moment(fight.startDate).format("YYYY-MM-DD HH:mm")}</div>
                        <small className="text-muted text-uppercase font-weight-bold">Fight date</small>
                    </div>
                </div>
            </div>
            <div className="col">
                <div className="card">
                    <div className="card-block">
                        <div className="h1 text-muted text-right mb-2">
                            <i className="fa fa-tasks" />
                        </div>
                        <div className="h4 mb-0">{fight.structure.weightAgeCategory.name}</div>
                        <small className="text-muted text-uppercase font-weight-bold">Age weight category</small>
                    </div>
                </div>
            </div>
            <div className="col">
                <div className="card">
                    <div className="card-block">
                        <div className="h1 text-muted text-right mb-2">
                            <i className="fa fa-circle-o fa-1x" />
                        </div>
                        <div className="h4 mb-0">{fight.ring}</div>
                        <small className="text-muted text-uppercase font-weight-bold">Ring</small>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default FightInfoBox;
