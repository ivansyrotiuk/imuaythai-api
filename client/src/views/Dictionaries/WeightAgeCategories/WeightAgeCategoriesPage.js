import React, { Component } from 'react';
import { host } from "../../../global"
import { fetchWeightCategories, deleteWeightCategory } from "../../../actions/Dictionaries/WeightCategoriesActions"
import RemoveButton from "../../Components/Buttons/RemoveButton"
import EditButton from "../../Components/Buttons/EditButton"
import AddButton from "../../Components/Buttons/AddButton"
import { Link } from 'react-router-dom'
import { connect } from "react-redux"
import axios from "axios";
import Spinner from "../../Components/Spinners/Spinner"

class WeightAgeCategoriesPage extends Component {
  constructor(props) {
    super(props);
    this.props.fetchWeightCategories();
  }

  removeCategory(id) {
    var self = this;
    axios
      .post(host + 'api/dictionaries/weightcategories/remove', {
        Id: id
      })
      .then(function(response) {
        self.props.deleteWeightCategory(response.data)
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
    const mappedWeightCategories = categories.map((category, i) => <tr key={ i }>
                                                                     <td>
                                                                       { category.id }
                                                                     </td>
                                                                     <td>
                                                                       { category.name }
                                                                     </td>
                                                                     <td>
                                                                     </td>
                                                                     <td>
                                                                       <Link to={ "/dictionaries/weightcategories/" + category.id }>
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
                <strong>Weight categories</strong>
                <div className="pull-right">
                  <Link to={ "/dictionaries/weightcategories/new" }>
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
                      <th>Categories</th>
                      <th>Action</th>
                    </tr>
                  </thead>
                  <tbody>
                    { mappedWeightCategories }
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
    categories: state.WeightCategories.categories,
    fetching: state.WeightCategories.fetching,
    fetched: state.WeightCategories.fetched
  }
}

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    fetchWeightCategories: () => {
      dispatch(fetchWeightCategories())
    },

    deleteWeightCategory: (id) => {
      dispatch(deleteWeightCategory(id))
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(WeightAgeCategoriesPage)