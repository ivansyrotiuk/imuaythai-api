import React, { Component } from 'react';
import { connect } from 'react-redux'
import { Alert } from 'reactstrap';
import { dismissError } from '../../actions/ErrorsActions'

class Errors extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        const {error} = this.props;
        if (!error) {
            return <div />
        }

        return (
            <Alert color="danger" isOpen={ error !== undefined } toggle={ this.props.dismiss }>
              { error }
            </Alert>
            );
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        error: state.Errors.error
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        dismiss: () => {
            dispatch(dismissError())
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(Errors)
