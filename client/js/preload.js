// preload.js
const { contextBridge, ipcRenderer } = require("electron");

/**
 * Експонуємо у вікно безпечне API:
 *  - Redux-міст: getState / dispatch / onStateChange
 *  - Конфіг: getApiBaseUrl / getImageBaseUrl
 *
 * ВАЖЛИВО: усі HTTP-запити (fetch...) робимо у файлах-сервісах з рендера
 *          (наприклад, features/categories/categoriesService.js, features/expenses/expensesService.js).
 *          Preload не виконує HTTP — лише прокидає IPC до main.
 */
contextBridge.exposeInMainWorld("electronAPI", {
  // --- Redux bridge ---
  /** Отримати поточний Redux-стан із main-процесу */
  getState: () => ipcRenderer.invoke("redux:get-state"),

  /** Відіслати action у Redux store main-процесу */
  dispatch: (action) => ipcRenderer.send("redux:dispatch", action),

  /**
   * Підписка на зміни Redux-стану.
   * Повертає функцію unsubscribe(), щоб за потреби зняти підписку.
   * Примітка: removeAllListeners запобігає накопиченню слухачів при HMR/перезавантаженнях.
   */
  onStateChange: (callback) => {
    const channel = "redux:state-updated";
    ipcRenderer.removeAllListeners(channel);
    const handler = (_e, newState) => callback(newState);
    ipcRenderer.on(channel, handler);
    return () => ipcRenderer.off(channel, handler);
  },

  // --- Config / базові URL ---
  /** URL API для бекенду (налаштовується у main через ipcMain.handle) */
  getApiBaseUrl: () => ipcRenderer.invoke("get-api-base-url"),
  /** URL для зображень/іконок (якщо інший хост/шлях) */
  getImageBaseUrl: () => ipcRenderer.invoke("get-image-base-url"),
});
