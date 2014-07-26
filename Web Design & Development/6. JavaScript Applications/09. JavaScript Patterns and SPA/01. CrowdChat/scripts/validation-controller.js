define(function() {
    var ValidationController = (function() {
        function isUsernameCorrect(username) {
            var isValidUsername = username && typeof username == 'string' &&
                                  username.length >= 4 && username.length <= 20;
            return isValidUsername;
        }

        return {
            isUsernameCorrect: isUsernameCorrect
        }
    }());

    return ValidationController;
});