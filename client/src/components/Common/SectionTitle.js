import React from "react";

export const SectionTitle = props => {
    return (
        <div className="row justify-content-center mt-4">
            <div className="h3 mx-auto">{props.children}</div>
        </div>
    );
};

export default SectionTitle;
