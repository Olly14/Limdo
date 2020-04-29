var registrationValidation = (function () {

    var emailInputIsValid = true;
    var passwordInputIsValid = true;
    var confirmedPasswordInputIsValid = true;


    var validateEmailInput = function () {

        if ($('#EmailInputId').val().length <= 0) {
            $('#EmailInputId').addClass("errorBox")
            $('#EmailInputErrorId').show();
            emailInputIsValid = false;
        } else {
            emailInputIsValid = true;
        }
    }

    var validatePasswordInput = function () {

        if ($('#PasswordInputId').val().length <= 0) {
            $('#PasswordInputId').addClass("errorBox")
            $('#PasswordInputErrorId').show();
            passwordInputIsValid = false;
        } else {
            passwordInputIsValid = true
        }
    }

    var validateConfirmedPasswordInput = function () {

        if ($('#ConfirmedPasswordInputId').val().length <= 0) {
            $('#ConfirmedPasswordInputId').addClass("errorBox")
            $('#ConfirmedPasswordInputErrorId').show();
            confirmedPasswordInputIsValid = false;
        } else {
            confirmedPasswordInputIsValid = true;
        }
    }

    var validatePasswordMatches = function () {
        var requiredPattern = new RegExp("^([a-zA-Z0-9@*#]{8,20})$");
        var isAMatch = requiredPattern.test($('#PasswordInputId'));
        if (!isAMatch) {

            PasswordMatchedIsValid = false;
            $('#PasswordInputId').addClass("inputFieldError");
            $('#help-block-id-PasswordId').removeClass("hidden");
        } else {
            passwordMatchedIsValid = true;
        }
    }

    var validateConfirmedPasswordMatches = function () {
        var requiredPattern = new RegExp("^([a-zA-Z0-9@*#]{8,15})$");
        var isAMatch = requiredPattern.test($('#ConfirmedPasswordInputId'));
        if (!isAMatch) {

            passwordMatchedIsValid = false;
            $('#ConfirmedPasswordInputId').addClass("inputFieldError");
            $('#help-block-id-ConfirmedPasswordId').removeClass("hidden");
        } else {
            ConfirmedPasswordMatchedIsValid = true;
        }
    }

    var resetPasswordInputMatchedRequiredError = function () {
        $('#PasswordInputId').removeClass("inputFieldError");
        $('#help-block-id-PasswordId').addClass("hidden");
    }
    var resetConfirmedPasswordInputMatchedRequiredError = function () {
        $('#ConfirmedPasswordInputId').removeClass("inputFieldError");
        $('#help-block-id-ConfirmedPasswordId').addClass("hidden");
    }


    var resetEmailInput = function () {

        $('#EmailInputId').removeClass("errorBox")
        $('.EmailInputError').hide();
    }

    var resetPasswordInput = function () {

        $('#PasswordInputId').removeClass("errorBox")
        $('.PasswordInputError').hide();
    }

    var resetConfirmedPasswordInput = function () {

        $('#ConfirmedPasswordInputId').removeClass("errorBox")
        $('.ConfirmedPasswordInputError').hide();
    }

    var onEmailInputFocusKeyPressedAndBackspace = function (event) {
        var emailInput = $('.EmailInput');
        var emailInputBackgroundColour = emailInput.css('backgroung-color');

        emailInput.focus(function () {

            if ((emailInputBackgroundColour === 'rgb(238,238,238)') ||
                (emailInputBackgroundColour === 'rgb(255,192,203)')) {
                emailInput.css("background", '#FFFFFF');
            }
            resetEmailInput();

        }).on('keydown', function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                if ((emailInputBackgroundColour === 'rgb(238,238,238)') ||
                    (emailInputBackgroundColour === 'rgb(255,192,203)')) {
                    emailInput.css("background", '#FFFFFF');
                }
                resetEmailInput();
            }

        });
    }

    var onPasswordInputFocusKeyPressedAndBackspace = function (event) {
        var passwordInput = $('.PasswordInput');
        var passwordInputBackgroundColour = passwordInput.css('backgroung-color');

        passwordInput.focus(function () {

            if ((passwordInputBackgroundColour === 'rgb(238,238,238)') ||
                (passwordInputBackgroundColour === 'rgb(255,192,203)')) {
                passwordInput.css("background", '#FFFFFF');
            }
            resetPasswordInput();

        }).on('keydown', function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                if ((passwordInputBackgroundColour === 'rgb(238,238,238)') ||
                    (passwordInputBackgroundColour === 'rgb(255,192,203)')) {
                    passwordInput.css("background", '#FFFFFF');
                }
                resetPasswordInput();
            }

        });
    }


    var onConfirmedPasswordInputFocusKeyPressedAndBackspace = function (event) {
        var confirmedPasswordInput = $('.ConfirmedPasswordInput');
        var confirmedPasswordInputBackgroundColour = confirmedPasswordInput.css('backgroung-color');

        confirmedPasswordInput.focus(function () {

            if ((confirmedPasswordInputBackgroundColour === 'rgb(238,238,238)') ||
                (confirmedPasswordInputBackgroundColour === 'rgb(255,192,203)')) {
                confirmedPasswordInput.css("background", '#FFFFFF');
            }
            resetConfirmedPasswordInput();

        }).on('keydown', function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                if ((confirmedPasswordInputBackgroundColour === 'rgb(238,238,238)') ||
                    (confirmedPasswordInputBackgroundColour === 'rgb(255,192,203)')) {
                    confirmedPasswordInput.css("background", '#FFFFFF');
                }
                resetConfirmedPasswordInput();
            }

        });
    }

    var init = function () {

        $('#registrationBtnId').click(function (e) {

            e.preventDefault();

            validateEmailInput();
            validatePasswordInput();
            validateConfirmedPasswordInput();


            var submitControl = emailInputIsValid &&
                passwordInputIsValid &&
                confirmedPasswordInputIsValid;



            if (submitControl) {
                $('.registrationForm').submit();
            }
        });



        validateEmailInput();
        validatePasswordInput();
        validateConfirmedPasswordInput()

        resetEmailInput();
        resetPasswordInput();
        resetConfirmedPasswordInput();

        onEmailInputFocusKeyPressedAndBackspace();
        onPasswordInputFocusKeyPressedAndBackspace();
        onConfirmedPasswordInputFocusKeyPressedAndBackspace();
    }

    return {
        init: init,
        validateEmailInput: validateEmailInput,
        validatePasswordInput: validatePasswordInput,
        validateConfirmedPasswordInput: validateConfirmedPasswordInput,


        resetEmailInput: resetEmailInput,
        resetPasswordInput: resetPasswordInput,
        resetConfirmedPasswordInput: resetConfirmedPasswordInput,

        onEmailInputFocusKeyPressedAndBackspace: onEmailInputFocusKeyPressedAndBackspace,
        onPasswordInputFocusKeyPressedAndBackspace: onPasswordInputFocusKeyPressedAndBackspace,
        onConfirmedPasswordInputFocusKeyPressedAndBackspace: onConfirmedPasswordInputFocusKeyPressedAndBackspace
    }

})();