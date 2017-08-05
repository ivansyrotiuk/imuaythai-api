export default function reducer(state = {
        suspensionTypes: [],
        fetching: false,
        fetched: false,
        error: null
    } , action) {

    switch (action.type) {
        case "FETCH_SUSPENSION_TYPES": {
            return {
                ...state,
                fetching: true
            }
        }
        case "FETCH_SUSPENSION_TYPES_REJECTED": {
            return {
                ...state,
                fetching: false,
                error: action.payload
            }
        }
        case "FETCH_SUSPENSION_TYPES_FULFILLED": {
            return {
                ...state,
                fetching: false,
                fetched: true,
                suspensionTypes: action.payload
            }
        }
        case "SAVE_SUSPENSION_TYPE": {

            const type = action.payload
            const newTypes = [...state.suspensionTypes]
            const typeToUpdate = newTypes.findIndex(t => t.id === type.id)
            if (typeToUpdate > -1) {
                newTypes[typeToUpdate] = type;
                return {
                    ...state,
                    suspensionTypes: newTypes
                }
            } else {
                return {
                    ...state,
                    suspensionTypes: [...state.suspensionTypes, type]
                }
            }

        }
        case "DELETE_SUSPENSION_TYPE": {
            return {
                ...state,
                suspensionTypes: state
                    .suspensionTypes
                    .filter(t => t.id !== action.payload)
            }
        }
    }
    return state
}