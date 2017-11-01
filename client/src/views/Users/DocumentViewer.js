import React, { Component } from "react";
import DocumentRow from "./DocumentRow";
export default class DocumentViewer extends Component {
  render() {
    const documents = this.props.documents.map((document, key) => (
      <DocumentRow document={document} />
    ));

    return (
      <table className="table">
        <tr>
          <th style={{ width: "80%" }}>Name</th>
          <th>Download</th>
          <th>Preview</th>
        </tr>
        {documents}
      </table>
    );
  }
}
