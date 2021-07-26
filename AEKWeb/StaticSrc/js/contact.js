
const form = document.getElementById("joinform");
if (form) {
    const error = form.querySelector(".error");
    form.addEventListener("submit", function (e) {
      e.preventDefault();
      const data = new FormData(form);
        fetch("/Signup", {
            method: "POST",
            body: data,
        })
        .then(() => location.reload())
        .catch(() => {
          error.textContent = "Oväntat fel";
        });
    });
}

const removeButtons = document.querySelectorAll(".signuplist .remove");

removeButtons.forEach((button) => {
    button.addEventListener("click", (e) => {
        e.preventDefault();

        fetch(button.href, {
            method: "DELETE",
        }).then(() => location.reload());
    });
});
