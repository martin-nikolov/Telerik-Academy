var Class = (function() {
  function subclass() {}

  function createClass(properties) {
    function f() {
      this.init.apply(this, arguments);
    }

    var prototype = {};
    for (var prop in properties) {
      prototype[prop] = properties[prop];
    }
    if (!prototype.init) {
      prototype.init = function() {};
    }

    f.prototype = prototype;
    f.extend = extendClass;

    return f;
  }

  var initializing = false;

  function extendClass(properties) {
    var _super = this.prototype;

    initializing = true;
    var prototype = new this();
    initializing = false;

    for (var name in properties) {
      var value = properties[name];
      if (_super[name] && typeof value === "function" && typeof _super[name] === "function" && value.toString().indexOf("this._super(") >= 0) {
        value = (function(name, fn) {
          return function() {
            var tmp = this._super;
            this._super = _super[name];
            var ret = fn.apply(this, arguments);
            this._super = tmp;
            return ret;
          };
        }(name, value));
      }
      prototype[name] = value;
    }

    function f() {
      if (!initializing && this.init) {
        this.init.apply(this, arguments);
      }
    }

    f.prototype = prototype;

    f.prototype.constructor = f;
    f.extend = extendClass;
    return f;
  }

  return {
    create: createClass
  };
}());

// module.exports = Class;