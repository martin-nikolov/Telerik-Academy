define(function(require) {

    Function.prototype.inherit = function(parent) {
        this.prototype = new parent();
        this.prototype.constructor = parent;
    }

    var utils = {
        circle: {
            calculatePerimeter: function(radius) {
                return 2 * Math.PI * radius;
            }
        }
    };

    return utils;
})