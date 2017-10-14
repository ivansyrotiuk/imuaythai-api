import React from "react";

const style = { color: "white", width: "100%", height: "100%" };

const CornerBox = props => {
    const color = props.color === "red" ? "bg-danger" : "bg-primary";
    return (
        <div className={color} style={style}>
            {props.children}
        </div>
    );
};

export default CornerBox;
