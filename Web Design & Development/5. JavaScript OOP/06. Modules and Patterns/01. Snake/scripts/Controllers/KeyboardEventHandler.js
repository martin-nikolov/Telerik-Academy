define(function(require) {
    var KeyboardEventHandler = (function() {
        var _pressedKey = null;

        // Constructor
        function KeyboardEventHandler() {}

        KeyboardEventHandler.prototype.dispatch = function() {
            document.onkeydown = function(e) {
                var keyCode = e ? (e.which ? e.which : e.keyCode) : event.keyCode;

                switch (keyCode) {
                    case 37:
                        _pressedKey = 'left';
                        break;
                    case 38:
                        _pressedKey = 'up';
                        break;
                    case 39:
                        _pressedKey = 'right';
                        break;
                    case 40:
                        _pressedKey = 'down';
                        break;
                }
            };

            return _pressedKey;
        };

        return KeyboardEventHandler;
    }());

    return KeyboardEventHandler;
});