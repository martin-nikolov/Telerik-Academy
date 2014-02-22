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

    function merge(self, object) {
        for (var property in object) {
            if (object.hasOwnProperty(property) && property !== 'constructor') {
                self[property] = object[property];
            }
        }

        return self;
    }

    Function.prototype.inherit = function(parent) {
        var child = this;

        if (Object.keys(child.prototype).length === 0) {
            child.prototype = Object.create(parent.prototype);
            child.prototype.parent = parent.prototype;
            child.prototype.constructor = child;
        } else {
            merge(child.prototype, parent.prototype);
        }
    }
})