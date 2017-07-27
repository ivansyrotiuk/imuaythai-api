import React, { Component } from 'react';
import { Link } from 'react-router-dom'
import { connect } from "react-redux"
import UserAvatar from 'react-user-avatar'
import RemoveButton from "../../Components/Buttons/RemoveButton"
import EditButton from "../../Components/Buttons/EditButton"
import PreviewButton from "../../Components/Buttons/PreviewButton"
import Spinner from "../../Components/Spinners/Spinner"
import { fetchJudges, deleteUser } from "../../../actions/UsersActions"

class JudgesPage extends Component {
  componentWillMount() {
    this.props.fetchJudges();
  }

  render() {
    const {judges, fetching} = this.props;

    if (fetching) {
      return <Spinner />
    }

    const mappedJudges = judges.map((judge, i) => <tr key={ i }>
                                                          <td className="col-md-1">
                                                            <UserAvatar size="40" name={ judge.firstname + ' ' + judge.surname } />
                                                          </td>
                                                          <td className="col-md-7">
                                                            { judge.firstname + ' ' + judge.surname }
                                                          </td>
                                                          <td className="col-md-2">
                                                            { judge.countryName }
                                                          </td>
                                                          <td className="col-md-2">
                                                            <Link to={ "/users/" + judge.id }>
                                                            <PreviewButton id={ judge.id } />
                                                            </Link>
                                                            <Link to={ "/users/" + judge.id + "/edit" }>
                                                            <EditButton id={ judge.id } />
                                                            </Link>
                                                            <RemoveButton id={ judge.id } click={ this.props.deleteUser.bind(this, judge.id) } />
                                                          </td>
                                                        </tr>);

    return (
      <div className="animated fadeIn">
        <div className="row">
          <div className="col-12">
            <div className="card">
              <div className="card-header">
                <strong>Judges</strong>
              </div>
              <div className="card-block">
                <table className="table">
                  <thead>
                    <tr>
                      <th></th>
                      <th>Name</th>
                      <th>Country</th>
                      <th>Action</th>
                    </tr>
                  </thead>
                  <tbody>
                    { mappedJudges }
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </div>
      </div>
      );
  }
}

const mapStateToProps = (state, ownProps) => {
  return {
    judges: state.Users.judges,
    fetching: state.Users.fetching,
    fetched: state.Users.fetched
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    fetchJudges: () => {
      dispatch(fetchJudges());
    },
    deleteUser: (id) => {
      dispatch(deleteUser(id));
    }
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(JudgesPage);