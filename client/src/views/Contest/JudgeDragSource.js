import dragTypes from '../../common/dragTypes'

export const judgeDragSource = {
    beginDrag(props) {
        // Return the data describing the dragged item
        const item = {
            requestId: props.judgeRequest.id
        }

        console.log(props);
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

export function collect(connect, monitor) {
    return {
        // Call this function inside render()
        // to let React DnD handle the drag events:
        connectDragSource: connect.dragSource(),
        // You can ask the monitor about the current drag state:
        isDragging: monitor.isDragging(),
    };
}