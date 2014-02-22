define(function(require) {

    (function() {
        if (!Object.create) {
            Object.create = function(obj) {
                function func() { };
                func.prototype = obj;
                return new func();    
            };
        }
    }());

    function isEmpty(destination) {
        return Object.keys(destination).length === 0;
    }


    function extend(destination, source) {
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
        } else {
            extend(child.prototype, parent.prototype);
        }
    }
})