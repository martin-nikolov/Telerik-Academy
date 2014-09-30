/// <reference path="jquery-2.0.2.js" />

var BullsAndCows = BullsAndCows || {};

BullsAndCows.ui = (function () {
    var generateLoginHtml = function () {
        var html = '<div id="login-container">' +
        '    <label for="login-username-input">Username: </label>' +
        '    <input type="text" id="login-username-input" />' +
        '    <label for="login-password-input">Password: </label>' +
        '    <input type="password" id="login-password-input" />' +
        '    <button id="login-button">Login</button>' +
        '</div>' +
        '<div id="register-container" class="hidden">' +
        '    <label for="register-username-input">Username: </label>' +
        '    <input type="text" id="register-username-input" />' +
        '    <label for="register-nickname-input">Nickname: </label>' +
        '    <input type="text" id="register-nickname-input" />' +
        '    <label for="register-password-input">Password: </label>' +
        '    <input type="password" id="register-password-input" />' +
        '    <button id="register-button">Register</button>' +
        '</div>';

        return html;
    };

    return {
        loginHtml: generateLoginHtml
    }
}());