import React, { Component } from 'react';
import { host } from "../../global"
import { fetchFighters, deleteFighter } from "../../actions/UsersActions"
import RemoveButton from "../Components/Buttons/RemoveButton"
import EditButton from "../Components/Buttons/EditButton"
import PreviewButton from "../Components/Buttons/PreviewButton"
import Spinner from "../Components/Spinners/Spinner"
import { Link } from 'react-router-dom'
import { connect } from "react-redux"
import axios from "axios";
import UserAvatar from 'react-user-avatar'


class FightersPage extends Component {
  constructor(props) {
    super(props);
    this.props.fetchFighters();
  }

  removeFighter(id) {
    var self = this;
    axios.post(host + 'api/users/remove', {
      Id: id
    })
      .then(function(response) {
        self.props.deleteFighter(response.data)
      })
      .catch(function(error) {
        console.log(error);
      });
  }

  render() {
    const {fighters, fetching} = this.props;

    if (fetching) {
      return <Spinner />
    }

    const mappedFighters = fighters.map((fighter, i) => 
      <tr key={ i }>
        <td className="col-md-1">
          <UserAvatar size="40" name={ fighter.firstname + ' ' + fighter.surname } />
        </td>
        <td className="col-md-7">
          { fighter.firstname + ' ' + fighter.surname }
        </td>
        <td className="col-md-2">
          { fighter.countryName }
        </td>
        <td className="col-md-2">
          <Link to={ "/fighters/" + fighter.id }>
          <PreviewButton id={ fighter.id } />
          </Link>
          <Link to={ "/fighters/" + fighter.id + "/edit" }>
          <EditButton id={ fighter.id } />
          </Link>
          <RemoveButton id={ fighter.id } click={ this.removeFighter.bind(this, fighter.id) } />
        </td>
      </tr>);

    return (
      <div className="animated fadeIn">
        <div className="row">
          <div className="col-12">
            <div className="card">
              <div className="card-header">
                <strong>Fighters</strong>
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
                    { mappedFighters }
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
    fighters: state.Fighters.fighters,
    fetching: state.Fighters.fetching,
    fetched: state.Fighters.fetched
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    fetchFighters: () => {
      dispatch(fetchFighters());
    },
    deleteFighter: (id) => {
      dispatch(deleteFighter(id));
    }
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(FightersPage);