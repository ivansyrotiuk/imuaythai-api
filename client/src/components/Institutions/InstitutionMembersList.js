import React from 'react';
import UserTable from "../Users/UserTable";

const InstitutionMembersList = (props) => {
        return <UserTable users={props.members}/>
};

export default InstitutionMembersList;
