import React from "react"

export default class LoadButton extends React.Component {

    render() {

        const {text, loading, click} = this.props;

        if (loading) {
            return (
                <a class="btn btn-primary">
                    <i class="fa fa-spinner fa-pulse fa-1x fa-fw"></i>
                    {text}
                </a>
            );
        } else {
            return (
                <a onClick={click} class="btn btn-primary">{text}</a>
            );
        }

    }
}