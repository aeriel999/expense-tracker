const { contextBridge, ipcRenderer } = require("electron");

contextBridge.exposeInMainWorld("electronAPI", {
    getState: () => ipcRenderer.invoke("redux:get-state"),
    dispatch: (action) => ipcRenderer.send("redux:dispatch", action),
    onStateChange: (callback) => {
        ipcRenderer.on("redux:state-updated", (_e, newState) =>
            callback(newState)
        );
    },
    getApiBaseUrl: () => ipcRenderer.invoke("get-api-base-url"), // 💡 тепер працює правильно
});
