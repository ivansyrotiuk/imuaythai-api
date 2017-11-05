import React from 'react';
import Collapsible from 'react-collapsible';

const CollapsiblePanel = (props) => {
    return (
        <Collapsible {...props}
                     triggerClassName="card-header"
                     triggerOpenedClassName="card-header"
                     contentInnerClassName="card-content"
                     classParentString="card-override" >
            {props.children}
        </Collapsible>
    );
};

export default CollapsiblePanel;
