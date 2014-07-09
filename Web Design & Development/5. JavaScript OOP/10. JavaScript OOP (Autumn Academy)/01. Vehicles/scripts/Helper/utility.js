define(function(require) {

    if (typeof Object.create != 'function') {
        var F = function () {};
        Object.create = function (o) {
            if (arguments.length > 1) { throw Error('Second argument not supported'); }
            if (o === null) { throw Error('Cannot set a null [[Prototype]]'); }
            if (typeof o != 'object') { throw TypeError('Argument must be an object'); }
            F.prototype = o;
            return new F;
        }
    }

    function isEmpty(destination) {
        return Object.keys(destination).length === 0;
    }

    function merge(destination, source) {
        for (var property in source) {
            if (source.hasOwnProperty(property) && property !== 'constructor') {
                destination[property] = source[property];
            }
        }

        return destination; 
    }

    Function.prototype.inherit = function(parent) {
        var child = this;

        if (isEmpty(child.prototype)) {
            child.prototype = Object.create(parent.prototype);
            child.prototype.parent = parent.prototype;
            child.prototype.constructor = child;
        } 
        else {
            merge(child.prototype, parent.prototype);
        }
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