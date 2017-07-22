import { connect } from 'react-redux'
import React, { Component } from 'react';

export class UserRoleRequestsPage extends Component{
    render(){
        return (<div>

        </div>);
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        prop: state.prop
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        dispatch1: () => {
            dispatch(actionCreator)
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(UserRoleRequestsPage)