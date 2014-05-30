define(function(require) {

    var pressedKey = null;

    // Constructor
    function KeyboardEventHandler() {}

    KeyboardEventHandler.prototype.dispatch = function() {
        document.onkeydown = function(e) {
            var keyCode = e ? (e.which ? e.which : e.keyCode) : event.keyCode;

            switch (keyCode) {
                case 37:
                    pressedKey = 'left';
                    break;
                case 38:
                    pressedKey = 'up';
                    break;
                case 39:
                    pressedKey = 'right';
                    break;
                case 40:
                    pressedKey = 'down';
                    break;
            }
        };

        return pressedKey;
    };

    return KeyboardEventHandler;
});