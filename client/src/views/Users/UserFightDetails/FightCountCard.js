import React from "react";

const FightCountCard = props => {
  let icon;
  switch (props.text) {
    case "fights":
      icon = "fa fa-user bg-primary p-3 font-2xl mr-3 float-left";
      break;
    case "win":
      icon = "fa fa-trophy p-3 bg-success font-2xl mr-3 float-left";
      break;
    case "lost":
      icon = "fa fa-frown-o bg-danger p-3 font-2xl mr-3 float-left";
      break;
  }
  return (
    <div className="col">
      <div className="card">
        <div className="card-block p-3 clearfix">
          <i className={icon} />
          <div className="h5 text-primary mb-0 mt-2">{props.count}</div>
          <div className="text-muted text-uppercase font-weight-bold font-xs">
            {props.text}
          </div>
        </div>
      </div>
    </div>
  );
};
export default FightCountCard;
