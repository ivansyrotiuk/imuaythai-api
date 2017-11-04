import React from 'react';
import Avatar from "react-avatar";
import Accordion from 'react-responsive-accordion';
import Page from "../../components/Page/Page";
import PageHeader from "../../components/Page/PageHeader";
import PageContent from "../../components/Page/PageContent";
import InstitutionInfoBox from "../../components/Institutions/InstitutionInfoBox";
import SocialNetworksBox from "../../components/Social/SocialNetworksBox";
import {ListGroup, ListGroupItem} from 'reactstrap';

const GymView = (props) => {
    const {gym, actions} = props;

    return (
        <Page>
            <PageHeader>
                <strong>{gym.name}</strong>
            </PageHeader>
            <PageContent>

                <div className="col-md-12">
                    <div className="row">
                        <div className="col-md-9">
                            <div className="row">
                                <div className="col-auto">
                                    <Avatar size="170" name={gym.name} src={gym.logo}/>
                                    <div className="mt-1">
                                        <SocialNetworksBox facebook={gym.facebook} twitter={gym.twitter}
                                                           instagram={gym.instagram} vk={gym.vk}/>
                                    </div>
                                </div>
                                <div className="col">
                                    <InstitutionInfoBox institution={gym}/>
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

                </div>
            </PageContent>
        </Page>
    );
};

export default GymView;
