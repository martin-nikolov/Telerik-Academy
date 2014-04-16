/*
    3. Create a module to work with the console object.
       Implement functionality for:
    - Writing a line to the console 
    - Writing a line to the console using a format
    - Writing to the console should call toString() to each element
    - Writing errors and warnings to the console with and without format
*/

taskName = "3. Console Module";

function Main(bufferElement) {

    var specialConsole = SetConsole(bufferElement);

    specialConsole.writeLine("Message: hello");

    specialConsole.writeLine("Message: {0}", "hello");

    specialConsole.writeError("Error: {0}", "Something happened");

    specialConsole.writeWarning("Warning: {0}", "A warning");
}

function SetConsole(container) {
    var _selfContainer = container;

    function _writeLine(message) {
        if (message && _selfContainer) {
            var span = document.createElement('span');
            span.innerHTML = message;
            _selfContainer.appendChild(span);
        }

        _selfContainer.appendChild(document.createElement("br"));

        if (typeof span !== 'undefined') {
            return span;
        }
    }

    function _writeError(message) {
        var errorMsg = _writeLine(message);
        if (errorMsg) errorMsg.style.color = 'red';
    }

    function _writeWarning(message) {
        var warningMsg = _writeLine(message);
        if (warningMsg) warningMsg.style.color = 'yellow';
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

    return {
        writeLine: function(message) { _writeLine(_format(arguments)); },
        writeError: function(message) { _writeError(_format(arguments)); },
        writeWarning: function(message) { _writeWarning(_format(arguments)); }
    }
}