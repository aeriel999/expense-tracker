export async function getBaseUrl() {
    return await window.electronAPI.getApiBaseUrl();
}

export async function getImageBaseUrl() {
    return await window.electronAPI.getImageBaseUrl();
}
