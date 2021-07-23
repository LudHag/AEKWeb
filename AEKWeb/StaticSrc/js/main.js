import "../scss/main.scss";
import "./modal.js";


const form = document.getElementById('login-form');

form.addEventListener("submit", function (e) {
    e.preventDefault();


    console.log("send");
});
