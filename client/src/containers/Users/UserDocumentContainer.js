import UserDocuments from '../../views/Users/UserDocuments'
import React from 'react'
import {connect} from 'react-redux'

const mapStateToProps = (state) => {
    return {
        documents: state.Documents.documents
    }
}
const mapDispatchToProps = (dispatch) => {
    return {

    }
}
export default connect(mapStateToProps, mapDispatchToProps)(UserDocuments);