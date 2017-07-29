import React, { Component } from 'react';
import { Table } from 'reactstrap';
import RemoveButton from "../Components/Buttons/RemoveButton";

class RenderContestCategoriesTable extends Component {
    constructor() {
        super();

        this.addContestCategory = this.addContestCategory.bind(this);
    }

    addContestCategory(contestCategory) {
        if (contestCategory != undefined)
            this.props.fields.push(contestCategory);
    }


    render() {
        const {fields, meta: {error, submitFailed}} = this.props;
        return (
            <Table>
              <thead>
                <tr>
                  <th className="col-md-11">
                    Contest category
                  </th>
                  <th className="col-md-1">
                    Remove
                  </th>
                </tr>
              </thead>
              <tbody>
                { fields.map((member, index) => {
                      return (<tr key={ index }>
                                <td className="col-md-11">
                                  { fields.get(index).name }
                                </td>
                                <td className="col-md-1">
                                  <RemoveButton click={ () => fields.remove(index) } />
                                </td>
                              </tr>)
                  }
                  ) }
              </tbody>
            </Table>
            );
    }
}
export default RenderContestCategoriesTable;