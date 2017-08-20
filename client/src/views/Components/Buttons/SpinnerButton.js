import React from "react"

export default class SpinnerButton extends React.Component {

    render() {

        const {text, loading, click, className = "btn btn-primary"} = this.props;


        if (loading) {
            return (
                <div className={ className }>
                  <i className="fa fa-spinner fa-pulse fa-1x fa-fw"></i>
                  { text }
                </div>
                );
        } else {
            return (
                <div onClick={ click } className={ className }>
                  { text }
                </div>
                );
        }

    }
}