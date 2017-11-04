import React from 'react';

const SocialNetworksBox = (props) => {
    const {facebook, twitter, instagram, vk} = props;

    return (
        <div className="row justify-content-center">
            { facebook && <a href={ facebook } target="_blank">
                <button type="button" className="btn icon btn-facebook">
                    <span>Facebook</span>
                </button> </a> }
            { twitter && <a href={ twitter } target="_blank">
                <button type="button" className="btn icon btn-twitter">
                    <span>Twitter</span>
                </button> </a> }
            { instagram && <a href={ instagram } target="_blank">
                <button type="button" className="btn icon btn-instagram">
                    <span>Instagram</span>
                </button> </a> }
            { vk && <a href={ vk } target="_blank">
                <button type="button" className="btn icon btn-vk">
                    <span>VK</span>
                </button>
            </a> }
        </div>
    )
}

export default SocialNetworksBox
