define(['http-requester', 'validation-controller', 'ui'], function(HttpRequester, ValidationController, UI) {
    var Controller = (function() {
        var Controller = function(resourceUrl) {
            this.resourseUrl = resourceUrl;
            this.refreshTimeMS = 4000;
            this.showLastMessagesCount = 200;
        };

        Controller.prototype.getUsername = function() {
            return sessionStorage.getItem('username');
        };

        Controller.prototype.setUsername = function(username) {
            sessionStorage.setItem('username', username);
        };

        Controller.prototype.destroyUsername = function() {
            sessionStorage.clear();
        };

        Controller.prototype.isLoggedIn = function() {
            return this.getUsername() != null;
        };

        Controller.prototype.loadChatBox = function() {
            var _this = this;

            $.when(
                $.get('views/chat-template.html', function(data) {
                    $('#wrapper').html(data);
                    $('.username-box').html(_this.getUsername());
                    _this.updateChatBox();
                    setInterval(function() {
                        _this.updateChatBox();
                    }, _this.refreshTimeMS);
                }));
        };

        Controller.prototype.updateChatBox = function() {
            var _this = this;
            HttpRequester.getJSON(this.resourseUrl)
                .then(function(data) {
                    var chatBoxHtml = UI.buildChatBox(data, _this.showLastMessagesCount);
                    $('#chatbox').html(chatBoxHtml)
                });
        };

        Controller.prototype.loadLoginForm = function() {
            $('#wrapper').load('views/login-template.html');
        };

        Controller.prototype.setEventHandler = function() {
            var _this = this,
                $wrapper = $('#wrapper');

            $wrapper.on('click', '#login-btn', function() {
                var $loginInput = $('#login-name'),
                    username = $loginInput.val(),
                    isValidUsername = ValidationController.isUsernameCorrect(username);

                if (isValidUsername) {
                    _this.setUsername(username);
                    $loginInput.removeClass('error-validation');
                    window.location = '#/chat';
                }
                else {
                    $loginInput.addClass('error-validation');
                }
            });

            $wrapper.on('click', '#exit-btn', function() {
                var exit = confirm("Are you sure you want to end the session?");
                if (exit === true) {
                    _this.destroyUsername();
                    window.location = '#/login';
                }
            });

            $wrapper.on('click', '#submitmsg', function() {
                var $messageInput = $('#usermsg'),
                    enteredMessage = $messageInput.val().trim(),
                    postBy = _this.getUsername();

                if (enteredMessage) {
                    HttpRequester.postJSON(_this.resourseUrl, {
                        user: postBy,
                        text: enteredMessage
                    })
                        .then(function() {
                            $messageInput.val('');
                            var postHtml = UI.buildMessage(postBy, enteredMessage);
                            $('#chatbox').prepend(postHtml);
                            $messageInput.removeClass('error-validation');
                        }, function() {
                            $messageInput.addClass('error-validation');
                        })
                }
                else {
                    $messageInput.addClass('error-validation');
                }
            });
        };

        return Controller;
    }());

    return Controller;
});