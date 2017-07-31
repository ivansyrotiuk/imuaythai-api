import React, { Component } from 'react';
import { Bracket, BracketGame, BracketGenerator } from 'react-tournament-bracket';
import JSOG from 'jsog';
import testData from '../../testData';
import dataJson from '../../data'

const GameComponent = props => {
    return (
        <BracketGame {...props} />
        );
};

class CreateFightsDiagram extends Component {
    render() {
        return (
            <BracketGenerator GameComponent={ GameComponent } games={ this.props.fights } homeOnTop={ false } />
            );
    }
}

export default CreateFightsDiagram;