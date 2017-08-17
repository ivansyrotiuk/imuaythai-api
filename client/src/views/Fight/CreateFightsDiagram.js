import React, { Component } from 'react';
import { Bracket, BracketGame, BracketGenerator } from 'react-tournament-bracket';
import Page from '../Components/Page'
const GameComponent = props => {
    return (
        <BracketGame {...props}/>
        );
};

class CreateFightsDiagram extends Component {
    constructor() {
        super();
        this.state = {
            hoveredTeamId: null
        }
        this.handleClick = this.handleClick.bind(this);
    }

    handleClick() {
        var content = document.getElementById("divcontents");
        var pri = document.getElementById("ifmcontentstoprint").contentWindow;
        pri.document.open();
        pri.document.write(content.innerHTML);
        pri.document.close();
        pri.focus();
        pri.print();
    }
    render() {

        const style = {
            height: "0px",
            width: "0px",
            position: "absolute",
            overflow: "hidden",
            size: "landscape",
            display: "none"
        }

        const header = <strong>Fight draw demo</strong>

        const content = <div>
                          <iframe id="ifmcontentstoprint" style={ style } scrolling="no"></iframe>
                          <button className="btn btn-primary" onClick={ this.handleClick }>Print</button>
                          <div id="divcontents">
                            <BracketGenerator GameComponent={ GameComponent } games={ this.props.fights } homeOnTop={ true } />
                          </div>
                        </div>
        return <Page header={ header } content={ content } />
    }
}

export default CreateFightsDiagram;