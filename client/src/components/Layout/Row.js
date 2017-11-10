import React from 'react';
import classnames from 'classnames';

const Row = (props) => {
    const rowClasses = classnames('row', props.className);
    return (
        <div className={rowClasses}>
            {props.children}
        </div>
    );
};

export default Row;
