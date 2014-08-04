define(function () {
    var ValidationController = (function () {
        function isUsernameCorrect(username) {
            var isCorrect = true;

            if (username.length < 6 || username.length > 40) {
                isCorrect = false;
            }

            return isCorrect;
        }

        function isPasswordCorrect(password) {
            var isCorrect = true;

            if (password.length < 4 || password.length > 30) {
                isCorrect = false;
            }

            return isCorrect;
        }

        return {
            isUsernameCorrect: isUsernameCorrect,
            isPasswordCorrect: isPasswordCorrect
        }
    }());

    return ValidationController;
});