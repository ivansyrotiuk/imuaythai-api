import React, { Component } from 'react';
import Avatar from 'react-avatar';
import moment from 'moment';
import SocialNetworksBox from '../../components/Social/SocialNetworksBox';

const UserDetails = props => {
    const { user } = props;
    const titleTextSyle = {
        color: '#697078'
    };

    const gender =
        user.gender == 'male' ? (
            <h6 style={titleTextSyle}>
                <i className="fa fa-mars" aria-hidden="true" />  Male
            </h6>
        ) : (
            <h6 style={titleTextSyle}>
                <i className="fa fa-venus" aria-hidden="true" />  Female
            </h6>
        );

    const userName = (user.firstname || 'No name') + ' ' + (user.surname || '');

    return (
        <div className="row">
            <div className="col-auto">
                <Avatar
                    size={150}
                    name={user.firstname + ' ' + user.surname || user.email}
                    src={user.photo}
                    style={{ display: 'block', margin: 'auto' }}
                />
                <div className="mt-1">
                    <SocialNetworksBox
                        facebook={user.facebook}
                        twitter={user.twitter}
                        instagram={user.instagram}
                        vk={user.vk}
                    />
                </div>
            </div>
            <div className="col">
                <div>
                    <h2> {userName} </h2>
                    {user.birthdate && (
                        <div className="row">
                            <div className="col-auto">
                                <i className="fa fa-birthday-cake" aria-hidden="true" />
                            </div>
                            <div className="col">{moment(user.birthdate).format('YYYY-MM-DD')}</div>
                        </div>
                    )}
                    {user.gender && (
                        <div className="row">
                            <div className="col-auto">
                                <i
                                    className={user.gender === 'male' ? 'fa fa-mars' : 'fa fa-venus'}
                                    aria-hidden="true"
                                />
                            </div>
                            <div className="col">{user.gender}</div>
                        </div>
                    )}
                    {user.phone && (
                        <div className="row">
                            <div className="col-auto">
                                <i className="fa fa-phone" aria-hidden="true" />
                            </div>
                            <div className="col">{user.phone}</div>
                        </div>
                    )}
                    {user.email && (
                        <div className="row">
                            <div className="col-auto">
                                <i className="fa fa-envelope" aria-hidden="true" />
                            </div>
                            <div className="col">{user.email}</div>
                        </div>
                    )}
                    {user.countryName && (
                        <div className="row">
                            <div className="col-auto">
                                <i className="fa fa-globe" aria-hidden="true" />
                            </div>
                            <div className="col">{user.countryName}</div>
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
};

export default UserDetails;
