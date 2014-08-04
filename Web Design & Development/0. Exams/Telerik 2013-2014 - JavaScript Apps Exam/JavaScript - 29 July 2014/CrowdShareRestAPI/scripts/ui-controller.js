define(['jquery', 'underscore'], function ($, _) {
    var UI = (function () {
        function drawLogInForm() {
            return '<fieldset id="login-user-container">' +
                   '<legend>Log In</legend>' +
                   '<label for="login-user-nickname">Nickname</label>' +
                   '<input id="login-user-nickname" type="text" name="name" value="" placeholder="Enter your nickname" autofocus="true" />' +
                   '<label for="login-user-password">Password</label>' +
                   '<input id="login-user-password" type="password" name="name" value="" placeholder="Enter your password" />' +
                   '<button id="button-log-in">Log In</button>' +
                   '<a id="register-now" href="#">Register now</a>' +
                   '</fieldset>';
        }

        function drawRegisterForm() {
            var html = '<fieldset id="register-user-container">' +
                       '<legend>Register</legend>' +
                       '<label for="register-user-nickname">Username</label>' +
                       '<input id="register-user-nickname" type="text" name="name" value="" placeholder="Enter your nickname" />' +
                       '<label for="register-user-password">Password</label>' +
                       '<input id="register-user-password" type="password" name="name" value="" placeholder="Enter your password" />' +
                       '<label for="register-user-password-re">Password</label>' +
                       '<input id="register-user-password-re" type="password" name="name" value="" placeholder="Confirm your password" />' +
                       '<a id="back-to-homepage" href="#" >Back</a>' +
                       '<button id="button-register">Register</button>' +
                       '<div id="reg-msg">Loggin after registration</div>' +
                       '</fieldset>';

            return html;
        }

        function drawLoggedInForm() {
            return '<div id="user-loged-in">' +
                   '<p id="greetings">Hello, ' + localStorage.getItem('username') + ' | </p>' +
                   '<button id="button-logout">Log out</button>' +
                   '<h3>Create new post:</h3>' +
                   '<div id="create-post-container"></div>' +
                   '</div>';
        }

        function drawPosts(posts, postsCount, pageNumber) {
            var postsHtml = "",
                postsToSkip = postsCount * (pageNumber - 1),
                numberOfGotPosts = 0;

            for (var i = postsToSkip; i < posts.length && numberOfGotPosts < postsCount ; i++, numberOfGotPosts++) {
                var postData = {
                    title: posts[i].title,
                    body: posts[i].body,
                    postDate: posts[i].postDate,
                    username: posts[i].user.username
                };

                postsHtml += drawPost(postData);
            }

            return postsHtml;
        }

        function drawPost(postData) {
            var html = '<fieldset class="post-entry">' +
                       '<legend>' +
                       '<strong>Title: </strong>' +
                       '<span class="post-title">' + postData.title + '</span>' +
                       '</legend>' +
                       '<div class="post-body">' +
                       '<strong>Content: </strong>' +
                       '<span class="post-content">' + postData.body + '</span>' +
                       '</div>' +
                       '<div class="post-date">' +
                       '<strong>Posted on: </strong>' +
                       '<span class="posted-on">' + postData.postDate + '</span>' +
                       '</div>' +
                       '<div class="post-by">' +
                       '<strong>Posted by: </strong>' +
                       '<span class="posted-by">' + postData.username + '</span>' +
                       '</div>' +
                       '</fieldset>';
            return html;
        }

        function showAppErrorMessage(message) {
            $('#error-messages').text(message);

            setTimeout(function () {
                $('#error-messages').text('');
            }, 15000);
        }

        function showAppSuccessMessage(message) {
            $('#success-messages').text(message);

            setTimeout(function () {
                $('#success-messages').text('');
            }, 3000);
        }

        function showErrorMessage(err) {
            $('#error-messages').text(err.responseJSON.Message);

            setTimeout(function () {
                $('#error-messages').text('');
            }, 15000);
        }

        function showMessage(message) {
            $('#messages').text(message);

            setTimeout(function () {
                $('#messages').text('');
            }, 15000);
        }

        function clearErrorMessage() {
            $('#error-messages').text('');
            $('#success-messages').text('');
        }

        function drawCreatePostForm() {
            var html = '<div class="create-post-form">' +
                       '<div>Post title: <input type="text" id="post-title-input" /></div>' +
                       '<div>Post content: <textarea id="post-body-input"></textarea></div>' +
                       '<input type="button" value="Create post" id="create-post-btn" />' +
                       '</div>';
            return html;
        }

        return {
            drawLogInForm: drawLogInForm,
            drawRegisterForm: drawRegisterForm,
            drawLoggedInForm: drawLoggedInForm,
            drawPosts: drawPosts,
            showAppErrorMessage: showAppErrorMessage,
            showAppSuccessMessage: showAppSuccessMessage,
            showErrorMessage: showErrorMessage,
            showMessage: showMessage,
            clearErrorMessage: clearErrorMessage,
            drawCreatePostForm: drawCreatePostForm
        }
    }());

    return UI;
})