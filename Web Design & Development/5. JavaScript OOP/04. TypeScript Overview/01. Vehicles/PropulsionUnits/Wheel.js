var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var PropulsionUnits;
(function (PropulsionUnits) {
    "use strict";

    var Wheel = (function (_super) {
        __extends(Wheel, _super);
        function Wheel(radius) {
            _super.call(this);
            this._radius = radius;
        }
        Object.defineProperty(Wheel.prototype, "radius", {
            get: function () {
                return this._radius;
            },
            enumerable: true,
            configurable: true
        });

        Wheel.prototype.produceAcceleration = function () {
            return MathLib.Utility.calcCirclePerimeter(this._radius);
        };
        return Wheel;
    })(PropulsionUnits.PropulsionUnit);
    PropulsionUnits.Wheel = Wheel;
})(PropulsionUnits || (PropulsionUnits = {}));
//# sourceMappingURL=Wheel.js.map
