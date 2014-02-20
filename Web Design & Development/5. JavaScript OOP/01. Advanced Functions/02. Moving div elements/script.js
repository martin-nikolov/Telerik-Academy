/*
    2. Create a module that works with moving div elements. 
       Implement functionality for:

    - Add new moving div element to the DOM
        - The module should generate random background, font and border colors for the div element
        - All the div elements are with the same width and height
    - The movements of the div elements can be either circular or rectangular
    - The elements should be moving all the time
*/

taskName = "2. Moving div elements";

function Main(bufferElement) {
    SetConsoleSize(100);

    var container = includeContainer();

    container.append(shape.circle());
    container.append(shape.circle());

    container.append(shape.rectangle());
    container.append(shape.rectangle());
}

function includeContainer() {
    var container = document.createElement('div');
    container.style.position = 'absolute';
    container.style.left = "300px";
    container.style.top = "220px";

    _GetDefaultContainer().appendChild(container);

    return {
        append: function(child) { container.appendChild(child); }
    }
}

(function() {
    shape = (function() {
        function _generateDiv(className) {
            className = className + " shape" || "shape";

            var div = document.createElement('div');
            div.className = className || null;

            div.style.fontFamily = _getRandomFontFamily();
            div.style.backgroundColor = _getRandomRgbColor();
            div.style.borderColor = _getRandomRgbColor();

            div.innerHTML = div.style.fontFamily;

            return div;
        }

        return {
            circle: function() { return _generateDiv('circle'); },
            rectangle: function() { return _generateDiv('rectangle'); },
        }
    }())

    function _getRandomRgbColor() {
        return 'rgb(' + [GetRandomInt(255), GetRandomInt(255), GetRandomInt(255)].join(',') + ')';
    }

    function _getRandomFontFamily() {
        var fonts = ['Arial', 'Consolas', 'Tahoma', 'Verdana'];
        return fonts[GetRandomInt(fonts.length - 1)];
    }
}())