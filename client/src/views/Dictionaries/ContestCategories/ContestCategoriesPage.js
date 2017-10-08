import React, { Component } from 'react';
import { host } from "../../../global"
import { fetchContestCategories, deleteContestCategory } from "../../../actions/Dictionaries/ContestCategoriesActions"
import RemoveButton from "../../Components/Buttons/RemoveButton"
import EditButton from "../../Components/Buttons/EditButton"
import AddButton from "../../Components/Buttons/AddButton"
import { Link } from 'react-router-dom'
import { connect } from "react-redux"
import axios from "axios";
import Spinner from "../../Components/Spinners/Spinner"

class ContestAgeCategoriesPage extends Component {
    constructor(props) {
        super(props);
        this.props.fetchContestCategories();
    }

    removeCategory(id) {
        var self = this;
        axios
            .post(host + 'api/dictionaries/categories/remove', {
                Id: id
            })
            .then(function(response) {
                self.props.deleteContestCategory(response.data)
            })
            .catch(function(error) {
                console.log(error);
            });
    }

    render() {

        const {categories, fetching} = this.props;
        if (fetching) {
            return <Spinner />
        }
        const mappedContestCategories = categories.map((category, i) => <tr key={ i }>
                                                                          <td>
                                                                            { category.id }
                                                                          </td>
                                                                          <td>
                                                                            { category.name }
                                                                          </td>
                                                                          <td>
                                                                          </td>
                                                                          <td>
                                                                            <Link to={ "/dictionaries/categories/" + category.id }>
                                                                            <EditButton id={ category.id } />
                                                                            </Link>
                                                                            <RemoveButton id={ category.id } click={ this.removeCategory.bind(this, category.id) } />
                                                                          </td>
                                                                        </tr>);


        return (

            <div className="animated fadeIn">
              <div className="row">
                <div className="col-12">
                  <div className="card">
                    <div className="card-header">
                      <strong>Contest categories</strong>
                      <div className="pull-right">
                        <Link to={ "/dictionaries/categories/new" }>
                        <AddButton/>
                        </Link>
                      </div>
                    </div>
                    <div className="card-block">
                      <table className="table">
                        <thead>
                          <tr>
                            <th>Id</th>
                            <th className="col-md-9">Name</th>
                            <th>Action</th>
                          </tr>
                        </thead>
                        <tbody>
                          { mappedContestCategories }
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
        categories: state.ContestCategories.categories,
        fetching: state.ContestCategories.fetching,
        fetched: state.ContestCategories.fetched
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        fetchContestCategories: () => {
            dispatch(fetchContestCategories())
        },

        deleteContestCategory: (id) => {
            dispatch(deleteContestCategory(id))
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(ContestAgeCategoriesPage)