import React from 'react';

const SocialNetworksBox = (props) => {
    const {facebook, twitter, instagram, vk} = props;

    return (
        <div className="row justify-content-end">
            { facebook && <a href={ facebook } target="_blank">
                <button type="button" className="btn  btn-facebook">
                    <span>Facebook</span>
                </button> </a> }
            { twitter && <a href={ twitter } target="_blank">
                <button type="button" className="btn  btn-twitter">
                    <span>Twitter</span>
                </button> </a> }
            { instagram && <a href={ instagram } target="_blank">
                <button type="button" className="btn btn-instagram">
                    <span>Instagram</span>
                </button> </a> }
            { vk && <a href={ vk } target="_blank">
                <button type="button" className="btn  btn-vk">
                    <span>VK</span>
                </button>
            </a> }
        </div>
    )
}

export default SocialNetworksBox
