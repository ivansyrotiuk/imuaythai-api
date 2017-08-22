import React from "react"

export default class LoadButton extends React.Component {

    render() {

        const {text, loading, click} = this.props;

        if (loading) {
            return (
                <a className="btn btn-primary">
                  <i className="fa fa-spinner fa-pulse fa-1x fa-fw"></i>
                  { text }
                </a>
                );
        } else {
            return (
                <a onClick={ click } className="btn btn-primary">
                  { text }
                </a>
                );
        }

    }
}