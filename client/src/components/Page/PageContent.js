import React from 'react';


const PageContent = (props) => {
    return (
        <div className="card-block">
            { props.children }
        </div>
    );
};

export default PageContent;
