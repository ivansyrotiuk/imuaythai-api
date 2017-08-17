export default function reducer(state = {
        structures: [],
        fetching: false,
        fetched: false,
        error: null
    } , action) {

    switch (action.type) {
        case "FETCH_STRUCTURES": {
            return {
                ...state,
                fetching: true
            }
        }
        case "FETCH_STRUCTURES_REJECTED": {
            return {
                ...state,
                fetching: false,
                error: action.payload
            }
        }
        case "FETCH_STRUCTURES_FULFILLED": {
            return {
                ...state,
                fetching: false,
                fetched: true,
                structures: action.payload
            }
        }
        case "SAVE_STRUCTURE": {

            const structure = action.payload
            const newStructures = [...state.structures]
            const structureToUpdate = newStructures.findIndex(t => t.id === structure.id)
            if (structureToUpdate > -1) {
                newStructures[structureToUpdate] = structure;
                return {
                    ...state,
                    structures: newStructures
                }
            } else {
                return {
                    ...state,
                    structures: [...state.structures, structure]
                }
            }

        }
        case "DELETE_STRUCTURE": {
            return {
                ...state,
                structures: state
                    .structures
                    .filter(t => t.id !== action.payload)
            }
        }
    }
    return state
}