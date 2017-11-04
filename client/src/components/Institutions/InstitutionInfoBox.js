import React from 'react';

export const InstitutionInfoBox = (props) => {
    const {name, address, owner, contactPerson, phone, email, website} = props.institution;

    return (
        <div>
            <h2> {name} </h2>
            <div className="row">
                <div className="col-auto">
                    <i className="fa fa-home" aria-hidden="true"> </i>
                </div>
                <div className="col">{address}</div>
            </div>
            <div className="row">
                <div className="col-auto">
                    <i className="fa fa-user" aria-hidden="true"> </i>
                </div>
                <div className="col">{owner}</div>
            </div>
            <div className="row">
                <div className="col-auto">
                    <i className="fa fa-life-ring" aria-hidden="true"></i>
                </div>
                <div className="col">{contactPerson}</div>
            </div>
            <div className="row">
                <div className="col-auto">
                    <i className="fa fa-phone" aria-hidden="true"></i>
                </div>
                <div className="col">{phone}</div>
            </div>
            <div className="row">
                <div className="col-auto">
                    <i className="fa fa-envelope" aria-hidden="true"> </i>
                </div>
                <div className="col">{email}</div>
            </div>
            <div className="row">
                <div className="col-auto">
                    <i className="fa fa-globe" aria-hidden="true"> </i>
                </div>
                <div className="col">
                    <a href={website}>{website}</a>
                </div>
            </div>
        </div>

    )
}
export default InstitutionInfoBox