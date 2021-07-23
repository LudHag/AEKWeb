import "../scss/main.scss";
import "./modal.js";

const form = document.getElementById("login-form");
const error = form.querySelector(".error");
form.addEventListener("submit", function (e) {
  e.preventDefault();
  const data = new FormData(form);
  fetch("/Account/Login", {
    method: "POST",
    body: data,
  })
    .then((response) => response.json())
    .then((result) => {
      if (result.success) {
        location.reload();
      } else {
        error.textContent = result.message;
      }
    })
    .catch((error) => {
      error.textContent = "Oväntat fel";
    });
});
