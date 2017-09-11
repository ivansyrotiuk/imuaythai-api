import React, { Component } from 'react';
import { Bracket, BracketGame, BracketGenerator } from 'react-tournament-bracket';
import Page from '../Components/Page'
import SpinnerButton from '../Components/Buttons/SpinnerButton'
const GameComponent = props => {
    return (
        <BracketGame {...props}/>
        );
};

class FightsDrawsView extends Component {
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

        const fightsNotGenerated = this.props.draws === undefined || this.props.draws.length == 0;

        const header = <div><strong>Contest fights draws </strong>
                         <div className="btn btn-link btn-sm pull-right" onClick={ this.handleClick }><i className="fa fa-print fa-1x" aria-hidden="true"></i></div>
                       </div>

        const content = <div>
                          { fightsNotGenerated && <SpinnerButton className="btn btn-success" loading={ this.props.generating } click={ this.props.generateContestDrawsClick } text="Generate fights" /> }
                          <iframe id="ifmcontentstoprint" style={ style } scrolling="no"></iframe>
                          <div id="divcontents">
                            <BracketGenerator GameComponent={ GameComponent } games={ this.props.draws } homeOnTop={ false } />
                          </div>
                          { !fightsNotGenerated &&
                            <div className="row justify-content-between">
                              <div className="col-md-6">
                                <SpinnerButton loading={ this.props.tossingup } className="btn btn-warning" click={ this.props.tossupDrawsClick } text="Tossup again" />
                              </div>
                              <div className="col-md-6">
                                <SpinnerButton loading={ this.props.generating } className="btn btn-danger pull-right" click={ this.props.regenerateContestDrawsClick } text="Regenerate fights" />
                              </div>
                            </div> }
                        </div>
        return <Page header={ header } content={ content } />
    }
}

export default FightsDrawsView;