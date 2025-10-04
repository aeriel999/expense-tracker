export function parseAmount(raw) {
  if (!raw) return NaN;
  const s = String(raw).replace(/[^\d]/g, "");
  if (!s) return NaN;
  return parseInt(s, 10);
}
