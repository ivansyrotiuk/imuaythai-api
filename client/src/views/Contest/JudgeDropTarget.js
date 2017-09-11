import { findDOMNode } from 'react-dom';
import { allocateJudgeRequest } from '../../actions/ContestActions'
import * as judgeTypes from '../../common/contestJudgeTypes'
import store from '../../store'

export function collect(connect, monitor) {
    return {
        // Call this function inside render()
        // to let React DnD handle the drag events:
        connectDropTarget: connect.dropTarget(),
        // You can ask the monitor about the current drag state:
        isOver: monitor.isOver(),
        isOverCurrent: monitor.isOver({
            shallow: true
        }),
        canDrop: monitor.canDrop(),
        itemType: monitor.getItemType(),
    };
}

const canDropJudge = (source, target) => {
    return true;
}

export const mainJudgeTarget = {
    canDrop(props, monitor) {
        const item = monitor.getItem();
        return canDropJudge(item, props);
    },

    hover(props, monitor, component) {
        const clientOffset = monitor.getClientOffset();
        const isJustOverThisOne = monitor.isOver({
            shallow: true
        });
        const canDrop = monitor.canDrop();
    },

    drop(props, monitor, component) {
        if (monitor.didDrop()) {
            return;
        }

        const item = monitor.getItem();

        const judgeAllocation = {
            requestId: item.requestId,
            judgeType: judgeTypes.CONTEST_MAIN_JUDGE
        }

        store.dispatch(allocateJudgeRequest(judgeAllocation));

        return {
            moved: true
        };
    }
};

export const regularJudgeTarget = {
    canDrop(props, monitor) {
        // You can disallow drop based on props or item
        const item = monitor.getItem();
        return canDropJudge(item, props);
    },

    hover(props, monitor, component) {
        const clientOffset = monitor.getClientOffset();
        const isJustOverThisOne = monitor.isOver({
            shallow: true
        });
        const canDrop = monitor.canDrop();
    },

    drop(props, monitor, component) {
        if (monitor.didDrop()) {
            return;
        }
        const item = monitor.getItem();
        const judgeAllocation = {
            requestId: item.requestId,
            judgeType: judgeTypes.CONTEST_REGULAR_JUDGE
        }

        store.dispatch(allocateJudgeRequest(judgeAllocation));
        return {
            moved: true
        };
    }
};

export const refereeTarget = {
    canDrop(props, monitor) {
        // You can disallow drop based on props or item
        const item = monitor.getItem();
        return canDropJudge(item, props);
    },

    hover(props, monitor, component) {
        const clientOffset = monitor.getClientOffset();
        const isJustOverThisOne = monitor.isOver({
            shallow: true
        });
        const canDrop = monitor.canDrop();
    },

    drop(props, monitor, component) {
        if (monitor.didDrop()) {
            return;
        }

        const item = monitor.getItem();

        const judgeAllocation = {
            requestId: item.requestId,
            judgeType: judgeTypes.CONTEST_REFEREE
        }

        store.dispatch(allocateJudgeRequest(judgeAllocation));

        return {
            moved: true
        };
    }
};

export const timeKeepperTarget = {
    canDrop(props, monitor) {
        // You can disallow drop based on props or item
        const item = monitor.getItem();
        return canDropJudge(item, props);
    },

    hover(props, monitor, component) {
        const clientOffset = monitor.getClientOffset();
        const isJustOverThisOne = monitor.isOver({
            shallow: true
        });
        const canDrop = monitor.canDrop();
    },

    drop(props, monitor, component) {
        if (monitor.didDrop()) {
            return;
        }

        const item = monitor.getItem();

        const judgeAllocation = {
            requestId: item.requestId,
            judgeType: judgeTypes.CONTEST_TIME_KEEPPER
        }

        store.dispatch(allocateJudgeRequest(judgeAllocation));
        return {
            moved: true
        };
    }
};

export const acceptedJudgeTarget = {
    canDrop(props, monitor) {
        // You can disallow drop based on props or item
        const item = monitor.getItem();
        return canDropJudge(item, props);
    },

    hover(props, monitor, component) {
        const clientOffset = monitor.getClientOffset();
        const isJustOverThisOne = monitor.isOver({
            shallow: true
        });
        const canDrop = monitor.canDrop();
    },

    drop(props, monitor, component) {
        if (monitor.didDrop()) {
            return;
        }

        const item = monitor.getItem();

        const judgeAllocation = {
            requestId: item.requestId,
        }

        store.dispatch(allocateJudgeRequest(judgeAllocation));

        return {
            moved: true
        };
    }
};


