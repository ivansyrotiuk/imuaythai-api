import React from 'react';
import Page from '../Components/Page';
import Avatar from 'react-avatar';
import { Link } from 'react-router-dom';

const renderFighters = fighters => {
    const mappedFighters = fighters.map((fighter, index) => (
        <tr key={index}>
            <td>
                <Avatar
                    size={40}
                    name={fighter.firstname + ' ' + fighter.surname || fighter.email}
                    src={fighter.photo}
                />
            </td>
            <td className="col-md-6">
                <div>{fighter.firstname + ' ' + fighter.surname}</div>
                <div className="small text-muted">{fighter.email}</div>
            </td>
            <td>{fighter.gymName}</td>
            <td>{fighter.countryName}</td>
        </tr>
    ));
    return (
        <table className="table table-hover mb-0 hidden-sm-down">
            <thead>
                <tr className="thead-default">
                    <th className="col-md-1 text-center">
                        <i className="fa fa-user-circle-o" aria-hidden="true" />
                    </th>
                    <th className="col-md-6">Name</th>
                    <th className="col-md-3">Gym</th>
                    <th className="col-md-2">Country</th>
                </tr>
            </thead>
            <tbody>{mappedFighters}</tbody>
        </table>
    );
};

const renderContestCategory = (category, contestId) => {
    const renderedFighters = renderFighters(category.fighters);

    return (
        <div className="row">
            <div className="col-md-12">
                <div className="card card-accent-primary">
                    <div className="card-header">
                        <strong>
                            {category.name} <div className="pull-right">Fighters: {category.fighters.length}</div>
                        </strong>
                    </div>
                    <div className="card-block">
                        {renderedFighters}
                        <div>
                            <Link
                                className="btn btn-secondary pull-right"
                                to={'/contests/' + contestId + '/category/' + category.id + '/draws'}
                            >
                                <i className="fa fa-sitemap" aria-hidden="true" /> Draws
                            </Link>
                            <Link
                                className="btn btn-secondary pull-right"
                                to={'/contests/' + contestId + '/category/' + category.id + '/fights'}
                            >
                                <i className="fa fa-hand-rock-o" aria-hidden="true" /> Fights
                            </Link>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export const ContestCategoriesView = props => {
    const header = <strong>Categories</strong>;
    const content = props.categories.map((category, index) => renderContestCategory(category, props.contestId));

    return <Page header={header} content={content} />;
};

export default ContestCategoriesView;
