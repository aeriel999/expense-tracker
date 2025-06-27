const { app, BrowserWindow, ipcMain } = require("electron");
const path = require("path");
require("dotenv").config();
const store = require("./store/store");

// 🔧 Отримуємо API URL з .env або дефолтний
const API_BASE_URL = process.env.API_BASE_URL;
const IMAGE_BASE_URL = process.env.IMAGE_BASE_URL;

// 📦 Реєструємо всі обробники ДО створення вікна
ipcMain.handle("redux:get-state", () => store.getState());

ipcMain.on("redux:dispatch", (event, action) => {
    store.dispatch(action);
    const newState = store.getState();
    BrowserWindow.getAllWindows().forEach((win) =>
        win.webContents.send("redux:state-updated", newState)
    );
});

// 📡 Обробник для API Base URL
ipcMain.handle("get-api-base-url", () => API_BASE_URL);
ipcMain.handle("get-image-base-url", () => IMAGE_BASE_URL);

function createWindow() {
    const win = new BrowserWindow({
        width: 1000,
        height: 800,
        webPreferences: {
            preload: path.join(__dirname, "preload.js"),
            contextIsolation: true,
            nodeIntegration: false,
            enableRemoteModule: true, // можна залишити, якщо потрібно
        },
    });

    win.loadFile("index.html");
}

// 🚀 Запускаємо застосунок
app.whenReady().then(createWindow);

// ❌ Закриваємо застосунок при закритті всіх вікон (на Windows)
app.on("window-all-closed", () => {
    if (process.platform !== "darwin") app.quit();
});
