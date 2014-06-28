var ConsoleModule = (function() {
    var _selfContainer = null;

    function ConsoleModule(container) {
        _selfContainer = $(container);
    }

    ConsoleModule.prototype = {
        writeLine: function(message) { _writeLine(_format(arguments)); },
        writeError: function(message) { _writeError(_format(arguments)); },
        writeWarning: function(message) { _writeWarning(_format(arguments)); }
    }

    function _writeLine(message) {
        var span = null;
        if (message && _selfContainer) {
            var span = $('<span/>').text(message);
            _selfContainer.append(span);
        }
        _selfContainer.append($('<br/>'));
        
        return span;
    }

    function _writeError(message) {
        var errorMsg = _writeLine(message);
        if (errorMsg) errorMsg.css('color', 'red');
    }

    function _writeWarning(message) {
        var warningMsg = _writeLine(message);
        if (warningMsg) warningMsg.css('color', 'yellow');
    }

    function _format(args) {
        if (arguments[0].length == 0) {
            return null;
        }

        var selfArguments = arguments[0];
        var message = arguments[0][0];

        return message.replace(/\{(\d+)\}/g, function (match, arg) {
            return selfArguments[+arg + 1];
        })
    }

    return ConsoleModule;
})();