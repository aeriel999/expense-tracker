const { app, BrowserWindow, ipcMain, Menu } = require("electron");
const path = require("path");
require("dotenv").config();
const store = require("../store/store");

// ---------------------- Config ----------------------
// Беремо з .env або дефолти; зрізаємо фінальні слеші, щоб не було "//api/..."
// 🔧 Отримуємо API URL з .env або дефолтний
const BASE_URL = process.env.BASE_URL;

// (не обов’язково) зручно знати, чи дев-режим
const isDev = !app.isPackaged;

// ---------------------- IPC (до створення вікна) ----------------------
// Redux: віддати стан у renderer
ipcMain.handle("redux:get-state", () => store.getState());

// Redux: прийняти action з renderer і розіслати оновлений стан у всі вікна
ipcMain.on("redux:dispatch", (_event, action) => {
  store.dispatch(action);
  broadcastState(); // розсилаємо після кожного dispatch із renderer
});

// Базові URL'и для рендера (preload → renderer)

ipcMain.handle("get-base-url", () => BASE_URL);


// Універсальна розсилка стану у всі відкриті вікна
function broadcastState() {
  const newState = store.getState();
  BrowserWindow.getAllWindows().forEach((win) =>
    win.webContents.send("redux:state-updated", newState)
  );
}

// ---------------------- Створення вікна ----------------------
function createWindow() {
  const win = new BrowserWindow({
    width: 1200,
    height: 800,
    autoHideMenuBar: true, // Alt показує/ховає меню
    webPreferences: {
      preload: path.join(__dirname, "preload.js"),
      contextIsolation: true,
      nodeIntegration: false,
      enableRemoteModule: true, // залиш, якщо справді потрібен remote API; інакше краще вимкнути
    },
  });

  // Меню (Reload / DevTools / Fullscreen + About)
  const template = [
    {
      label: "View",
      submenu: [
        { role: "reload" },
        { role: "toggleDevTools" },
        { type: "separator" },
        { role: "togglefullscreen" },
      ],
    },
    {
      label: "Help",
      submenu: [
        { label: "About", click: () => win.webContents.send("menu-about") },
      ],
    },
  ];
  Menu.setApplicationMenu(Menu.buildFromTemplate(template));

  // Завантажуємо UI
  win.loadFile("index.html");

  if (isDev) {
    // зручно, але не обов’язково
    // win.webContents.openDevTools({ mode: "detach" });
  }
}

// ---------------------- App lifecycle ----------------------
app.whenReady().then(createWindow);

// macOS: повторно відкрити вікно при кліку на іконку, якщо вікон нема
app.on("activate", () => {
  if (BrowserWindow.getAllWindows().length === 0) createWindow();
});

// Windows/Linux: вихід при закритті всіх вікон
app.on("window-all-closed", () => {
  if (process.platform !== "darwin") app.quit();
});
