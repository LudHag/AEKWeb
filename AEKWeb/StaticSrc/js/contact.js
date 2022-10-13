const form = document.getElementById('joinform');
if (form) {
  const error = form.querySelector('.error');
  const confirm = form.querySelector('.confirm');
  form.addEventListener('submit', function (e) {
    e.preventDefault();
    const data = new FormData(form);
    fetch('/Signup', {
      method: 'POST',
      body: data,
    }).then((res) => {
      if (res.ok) {
        res.text().then((text) => {
          if (!text.length) {
            error.classList.add('hide');
            form.reset();
            confirm.classList.remove('hide');
          } else {
            error.classList.remove('hide');
            error.textContent = text;
          }
        });
      } else {
        error.classList.remove('hide');
        error.textContent = 'Oväntat fel';
      }
    });
  });
}

const removeButtons = document.querySelectorAll('.signuplist .remove');

removeButtons.forEach((button) => {
  button.addEventListener('click', (e) => {
    e.preventDefault();

    fetch(button.href, {
      method: 'DELETE',
    }).then(() => location.reload());
  });
});
