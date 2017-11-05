import React from 'react';
import Avatar from "react-avatar";
import InstitutionInfoBox from "./InstitutionInfoBox";
import SocialNetworksBox from "../Social/SocialNetworksBox";

const InstitutionViewBox = (props) => {
    const {institution, actions} = props;
    return (
        <div className="row">
            <div className="col-md-9">
                <div className="row">
                    <div className="col-auto">
                        <Avatar size={170} name={institution.name} src={institution.logo}/>
                        <div className="mt-1">
                            <SocialNetworksBox facebook={institution.facebook} twitter={institution.twitter}
                                               instagram={institution.instagram} vk={institution.vk}/>
                        </div>
                    </div>
                    <div className="col">
                        <InstitutionInfoBox institution={institution}/>
                    </div>
                </div>
            </div>
            <div className="col-md-3">

                <div className="card">
                    <div className="card-header bg-mute">
                        Actions
                    </div>
                    <div className="card-block p-0">
                        <div onClick={actions.goToEditPage} className="btn btn-link text-mute">
                            <i className="fa fa-pencil" aria-hidden="true"></i> Edit
                        </div>
                    </div>
                </div>

            </div>
        </div>
    );
};

export default InstitutionViewBox;
