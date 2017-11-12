import React, { Component } from "react";
import { connect } from "react-redux";
import { Alert } from "reactstrap";
import { dismiss } from "../../actions/ErrorsActions";

class NotificationsBox extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        const { error, success } = this.props;

        return (
            <div>
                {error && (
                    <Alert color="danger" isOpen={error !== undefined} toggle={this.props.dismiss}>
                        {error}
                    </Alert>
                )}
                {success && (
                    <Alert color="success" isOpen={success !== undefined} toggle={this.props.dismiss}>
                        {success}
                    </Alert>
                )}
            </div>
        );
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        error: state.Notifications.error,
        success: state.Notifications.success
    };
};

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        dismiss: () => {
            dispatch(dismiss());
        }
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(NotificationsBox);
