import React, { Component } from 'react';
import { connect } from 'react-redux'


export const Errors = (props) => {
    if (props.error) {

    }
    return (
        <div/>
    )
}

const mapStateToProps = (state, ownProps) => {
    return {
        error: state.Errors.error
    }
}

export default connect(mapStateToProps)(Errors)