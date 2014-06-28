var ConsoleModule = (function() {
    function ConsoleModule(container) {
        this.container = $(container);
        return this;
    }

    ConsoleModule.prototype = {
        writeLine: function(message) { _writeLine.call(this, _format(arguments)); },
        writeError: function(message) { _writeError.call(this, _format(arguments)); },
        writeWarning: function(message) { _writeWarning.call(this, _format(arguments)); }
    }

    function _writeLine(message) {
        var span = null;
        if (this.container) {
            if (message) {
                span = $('<span/>').text(message);
            }

            this.container.append(span);
            this.container.append($('<br/>'));
        }
        return span;
    }

    function _writeError(message) {
        var errorMsg = _writeLine.call(this, message);
        if (errorMsg) errorMsg.css('color', 'red');
    }

    function _writeWarning(message) {
        var warningMsg = _writeLine.call(this, message);
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