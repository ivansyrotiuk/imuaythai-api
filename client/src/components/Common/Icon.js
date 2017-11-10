import React from 'react';
import classnames from 'classnames';
import PropTypes from 'prop-types';

const Icon = (props) => {
    const iconClasses = classnames('fa', props.name);

    return (
        <i className={iconClasses} aria-hidden="true"></i>
    );
};

Icon.propTypes = {
    name: PropTypes.string
};

Icon.defaultProps = {
    name: ""
};

export default Icon;
