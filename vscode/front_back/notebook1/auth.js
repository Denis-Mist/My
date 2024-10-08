const form = document.querySelector('form');

form.addEventListener('submit', (e) => {
  e.preventDefault();

  const name = document.getElementById('name');
  const email = document.getElementById('email');
  const phone = document.getElementById('phone');
  const country = document.getElementById('country');
  const date = document.getElementById('date');
  const comment = document.getElementById('comment');
  const consent = document.getElementById('consent');

  let error = false;

  if (name.value.trim() === '') {
    alert('Please enter your name');
    error = true;
  }
  if (email.value.trim() === '') {
    alert('Please enter your email');
    error = true;
  } else if (!validateEmail(email.value)) {
    alert('Please enter a valid email address');
    error = true;
  }
  if (phone.value.trim() === '') {
    alert('Please enter your phone number');
    error = true;
  } else if (phone.value.trim().length !== 11 || !validatePhoneNumber(phone.value.trim())) {
    alert('Please enter a valid phone number with 11 digits');
    error = true;
  }
  if (country.value === '') {
    alert('Please select your country');
    error = true;
  }
  if (date.value.trim() === '') {
    alert('Please enter the date');
    error = true;
  } else if (!validateDate(date.value.trim())) {
    alert('Please enter a valid date in the format YYYY-MM-DD');
    error = true;
  }
  if (comment.value.trim() === '') {
    alert('Please enter a comment');
    error = true;
  }
  if (!consent.checked) {
    alert('Please agree to the terms');
    error = true;
  }

  if (!error) {
    const successMessage = document.createElement('p');
    successMessage.textContent = 'Form successfully sent!';
    form.appendChild(successMessage);
  }
});

function validateEmail(email) {
  const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
  return emailRegex.test(email);
}

function validatePhoneNumber(phoneNumber) {
  const phoneRegex = /^\d{11}$/;
  return phoneRegex.test(phoneNumber);
}

function validateDate(date) {
  const dateRegex = /^\d{4}-\d{2}-\d{2}$/;
  return dateRegex.test(date);
}