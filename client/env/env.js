export async function getBaseUrl() {
    return await window.electronAPI.getApiBaseUrl();
}
