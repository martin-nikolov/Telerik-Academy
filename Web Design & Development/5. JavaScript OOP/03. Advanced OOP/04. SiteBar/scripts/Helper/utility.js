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

    var Class = (function() {
        function createClass(properties) {
            var f = function () {
                //This is an addition to enable super (base) class with inheritance
                if (this._superConstructor){
                    this._super = new this._superConstructor(arguments);
                }

                this.init.apply(this, arguments);
            }

            for (var prop in properties) {
                f.prototype[prop] = properties[prop];
            }

            if (!f.prototype.init) {
                f.prototype.init = function() {}
            }

            return f;
        }

        Function.prototype.inherit = function(parent) {
            var oldPrototype = this.prototype;
            this.prototype = new parent();
            this.prototype._superConstructor = parent;

            for (var prop in oldPrototype) {
                this.prototype[prop] = oldPrototype[prop];
            }
        }

        return {
            create: createClass
        }
    }());

    return Class;
})