var ShapeModule = (function() {
    function ShapeModule(container) {
        this.container = container;
        return this;
    }

    ShapeModule.prototype.add = function(shapeName) {
        var shape = _generateDiv(shapeName);
        this.container.append(shape);
    }

    function _getRandomRgbColor() {
        return 'rgb(' + [GetRandomInt(255), GetRandomInt(255), GetRandomInt(255)].join(',') + ')';
    }

    function _getRandomFontFamily() {
        var fonts = ['Arial', 'Consolas', 'Tahoma', 'Verdana'];
        return fonts[GetRandomInt(fonts.length - 1)];
    }

    function GetRandomInt(max) {
        return Math.floor(Math.random() * (max + 1));
    }

    function _generateDiv(className) {
        var div = $('<div/>')
            .addClass('shape').addClass(className)
            .css('font-family', _getRandomFontFamily())
            .css('background-color', _getRandomRgbColor())
            .css('border-color', _getRandomRgbColor());
        div.text(div.css('font-family'));
        return div;
    }

    return ShapeModule;
})();