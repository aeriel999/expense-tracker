const { contextBridge, ipcRenderer } = require("electron");
const path = require("path");
const { getCategories } = require(path.resolve(
    __dirname,
    "store",
    "categories",
    "category.actions"
));

contextBridge.exposeInMainWorld("electronAPI", {
    getReduxState: () => ipcRenderer.invoke("redux:get-state"),

    onReduxUpdate: (callback) => {
        ipcRenderer.on("redux:state-updated", (event, newState) => {
            callback(newState);
        });
    },

    dispatch: (action) => {
        console.log("📤 dispatch action", action);
        ipcRenderer.send("redux:dispatch", action);
    },

    dispatchGetCategories: () => {
        console.log("📦 Dispatch getCategories()");
        ipcRenderer.send("redux:dispatch", getCategories()); // ✅ відправляє action через ipc
    },
});
