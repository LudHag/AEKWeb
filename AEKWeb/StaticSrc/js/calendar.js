import datepicker from "js-datepicker";

datepicker(".date-picker", {
  formatter: (input, date, instance) => {
    const value = date.toLocaleDateString();
    input.value = value; // => '1/1/2099'
  },
});

const form = document.getElementById("createevent");
const error = form.querySelector(".error");
form.addEventListener("submit", function (e) {
  e.preventDefault();
  const data = new FormData(form);
  fetch("/Event", {
    method: "POST",
    body: data,
  })
    .then(() => location.reload())
    .catch(() => {
      error.textContent = "Oväntat fel";
    });
});

const removeButtons = document.querySelectorAll(".calendar .remove");

removeButtons.forEach((button) => {
  button.addEventListener("click", (e) => {
    e.preventDefault();

    fetch(button.href, {
      method: "DELETE",
    }).then(() => location.reload());
  });
});
