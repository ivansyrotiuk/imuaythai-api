export const loadState = () => {
    try {
        const authAccount = localStorage.getItem("authAccount");
        if (authAccount === null) {
            return undefined;
        } else {
            return {
                Account: JSON.parse(authAccount)
            };
        }

    } catch (err) {
        return undefined
    }
};

export const saveState = (state) => {
    try {
        const authAccount = JSON.stringify(state);
        localStorage.setItem("authAccount", authAccount);
    } catch (err) {
        //ignore
    }
}

export const removeState = (id) => {
    try {
        localStorage.removeItem(id);

    } catch (err) {
        return undefined
    }
}