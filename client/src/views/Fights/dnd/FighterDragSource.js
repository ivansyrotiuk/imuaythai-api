import dragTypes from "../../../common/dragTypes";

export const fighterSource = {
    beginDrag(props) {
        // Return the data describing the dragged item
        const item = {
            fight: props.fight,
            fighter: props.fighter
        };
        return item;
    },

    endDrag(props, monitor, component) {
        if (!monitor.didDrop()) {
            return;
        }

        // When dropped on a compatible target, do something
        const item = monitor.getItem();
        const dropResult = monitor.getDropResult();

        //CardActions.moveCardToList(item.id, dropResult.listId);
    }
};

export const collectDragSource = (connect, monitor) => {
    return {
        connectDragSource: connect.dragSource(),
        isDragging: monitor.isDragging()
    };
};
