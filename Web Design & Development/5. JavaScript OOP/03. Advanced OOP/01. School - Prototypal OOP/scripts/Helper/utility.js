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

    if (typeof Object.prototype.extend != 'function') {
        Object.prototype.extend = function(properties) {
            function f() {};
            f.prototype = Object.create(this);

            for (var prop in properties) {
                f.prototype[prop] = properties[prop];
            }

            f.prototype._super = this;

            return new f();
        }
    }
})