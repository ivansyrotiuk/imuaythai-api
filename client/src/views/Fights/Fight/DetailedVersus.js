import React from "react";

export const DetailedVersus = props => {
    return (
        <div className="col-md-12 align-self-center">
            {
                <h3>
                    <strong>VS</strong>
                </h3>
            }
            {<h6 className="card-subtitle mb-2 text-muted"> Country</h6>}
            {<h5 className="card-title">Age </h5>}
            {<h5 className="card-title"> Won </h5>}
            {<h5 className="card-title"> Lost </h5>}
            {<h5 className="card-title">Khan</h5>}
        </div>
    );
};

export default DetailedVersus;
