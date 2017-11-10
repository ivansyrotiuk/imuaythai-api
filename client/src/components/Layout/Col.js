import React from 'react';
import classnames from 'classnames';

const Col = (props) => {
    const colClasses = classnames('col', props.className);
    return (
        <div className={colClasses}>
            {props.children}
        </div>
    );
};

export default Col;
