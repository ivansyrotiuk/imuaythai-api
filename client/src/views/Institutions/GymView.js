import React from 'react';
import Avatar from "react-avatar";
import Accordion from 'react-responsive-accordion';
import Page from "../../components/Page/Page";
import PageHeader from "../../components/Page/PageHeader";
import PageContent from "../../components/Page/PageContent";
import InstitutionInfoBox from "../../components/Institutions/InstitutionInfoBox";
import SocialNetworksBox from "../../components/Social/SocialNetworksBox";

const GymView = (props) => {
    const {gym, actions} = props;

    return (
        <Page>
            <PageHeader>
                <strong>{ gym.name }</strong>
            </PageHeader>
            <PageContent>
                <Accordion closeable="true">
                <div className="col-md-12" data-trigger="A nifty React accordion component">
                    <div className="row">
                        <div className="col-md-6">
                            <div className="row">
                                <div className="col-auto">
                                    <Avatar size="150" name={ gym.name } src={ gym.logo } />
                                </div>
                                <div className="col">
                                    <InstitutionInfoBox institution={ gym } />
                                </div>
                            </div>
                        </div>
                        <div className="col-md-6">
                            <SocialNetworksBox facebook={gym.facebook} twitter={gym.twitter} instagram={gym.instagram} vk={gym.vk}/>
                        </div>
                    </div>
                </div>
                <div onClick={ actions.goToEditPage } data-trigger="A nifty React accordion component2">
                    <i className="fa fa-pencil" aria-hidden="true"></i>  Edit
                </div>
                </Accordion>

            </PageContent>
        </Page>
    );
};

export default GymView;
