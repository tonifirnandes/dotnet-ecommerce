(function () {
    emailValidation();
    passwordValidation();
    confirmPassValidation();

    $("#PhoneNumber").mask("9999-9999-9999");
})();

function emailValidation() {
    var email = document.getElementById("Email"),
        message = document.getElementById("msg-err-email");

    email.addEventListener('keypress', function () {
        message.textContent = "";
    })
}

function passwordValidation() {
    var password = document.getElementById("Password"),
        message = document.getElementById("msg-err-password");

    password.addEventListener('keypress', function () {
        message.textContent = "";
    })
}

function confirmPassValidation() {
    var password = document.getElementById("Password"),
        passConfirm = document.getElementById("ConfirmPassword"),
        passConfirmMsg = document.getElementById("msg-err-confirm-password"),
        passwordMsg = document.getElementById("msg-err-password");

    passConfirm.onkeyup = function () {
        if (passConfirm.value !== password.value) {
            passConfirmMsg.textContent = "Password Confirm not match with Password";
        } else {
            passConfirmMsg.textContent = "";
        }
    }
}





