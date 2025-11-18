export function showRowError(row, message, ms = 2500) {
  if (!row) return;

  const host = row.querySelector(".amount-wrap") || row; 

  let box = host.querySelector(".row-error");

  if (!box) {
    box = document.createElement("div");
    box.className = "row-error";
    box.setAttribute("role", "alert");
    box.setAttribute("aria-live", "polite");
    host.appendChild(box);
  }

  box.textContent = message;
  box.classList.add("visible");

  clearTimeout(box._hide);
  
  box._hide = setTimeout(() => box.classList.remove("visible"), ms);
}
