import React, { Component } from 'react';
import { Table } from 'reactstrap';
import Avatar from 'react-avatar';
import RemoveButton from '../Components/Buttons/RemoveButton';
import EditButton from '../Components/Buttons/EditButton';
import AddButton from '../Components/Buttons/AddButton';
import PreviewButton from '../Components/Buttons/PreviewButton';
import TablePage from '../Components/TablePage';
import { Link } from 'react-router-dom';
import Row from '../../components/Layout/Row';

class ContestsPage extends Component {
    render() {
        const { contests } = this.props;

        const pageHeader = (
            <div>
                <strong>Contests</strong>
                <div className="pull-right">
                    <AddButton click={this.props.addContestClick} />
                </div>
            </div>
        );

        const headers = (
            <tr>
                <th>No.</th>
                <th>Contest name</th>
                <th className="text-center">Action</th>
            </tr>
        );

        const mappedContests = contests.map((contest, i) => (
            <tr key={i}>
                <td>
                    <Avatar size={40} name={contest.name} src="http://localhost:3000/img/contest_poster.jpg" />
                </td>
                <td>{contest.name}</td>
                <td>
                    <Row className="justify-content-between">
                        <Link to={'/contests/' + contest.id}>
                            <PreviewButton />
                        </Link>
                        <Link to={'/contests/' + contest.id + '/edit'}>
                            <EditButton />
                        </Link>
                        <RemoveButton />
                    </Row>
                </td>
            </tr>
        ));

        return <TablePage pageHeader={pageHeader} headers={headers} content={mappedContests} />;
    }
}

export default ContestsPage;
