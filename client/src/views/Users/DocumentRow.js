import React from "react";
import { Link } from "react-router-dom";
export const DocumentRow = props => {
  const transformToDownloadUrl = url => {
    let paramArray = url.split("/");
    let uploadItem = paramArray.find(param => param === "upload");
    paramArray.splice(paramArray.indexOf(uploadItem) + 1, 0, "fl_attachment");
    return paramArray.join("/");
  };
  return (
    <tr>
      <td>{props.document.name}</td>
      <td>
        <a href={transformToDownloadUrl(props.document.url)} target="_blank">
          <i className="fa fa-download fa-lg" />
        </a>
      </td>
      <td>
        <a href={props.document.url} target="_blank">
          <i className="fa fa-eye fa-lg" />
        </a>
      </td>
    </tr>
  );
};

export default DocumentRow;
