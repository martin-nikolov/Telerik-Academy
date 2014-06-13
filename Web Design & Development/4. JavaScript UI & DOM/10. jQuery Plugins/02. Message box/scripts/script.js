(function($) {
    $.fn.messageBox = function(message, type) {
        var messageBox = $(this);

        var msgBox = $('<div class="message" />')
            .addClass(type)
            .text(message);

        $(msgBox).fadeIn(3000, "linear");

        $(messageBox).append(msgBox);

        // FadeOut + remove element
        setTimeout(function() {
            $(msgBox).fadeOut(3000, "linear");
            setTimeout(function() {
                $(msgBox).remove();
            }, 3000);
        }, 3000);
    };
}(jQuery));

window.onload = function() {
    var errorMsg = $('#message-box').messageBox('Change your password', 'error');
    var warningMsg = $('#message-box').messageBox('Check your email', 'warning');
    var successMsg = $('#message-box').messageBox('You received 10 points', 'success');

    addRandomMessages();
};

function addRandomMessages() {
    var interval = 500;
    var i = 1;

    function addMessage() {
        setTimeout(function() {
            var randomType = ['error', 'warning', 'success'][i % 3];
            var msg = $('#message-box').messageBox('Message: ' + i++, randomType);
        }, interval);

        interval += 500;
    }

    setTimeout(function() {
        for (var i = 0; i < 5; i++) {
            addMessage();
        }
    }, interval);
}