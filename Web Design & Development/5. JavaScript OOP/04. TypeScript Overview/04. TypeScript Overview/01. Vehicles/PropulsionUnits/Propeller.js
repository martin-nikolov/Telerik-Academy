var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var PropulsionUnits;
(function (PropulsionUnits) {
    "use strict";

    var SpinDirection;
    (function (SpinDirection) {
        SpinDirection[SpinDirection["Clockwise"] = 0] = "Clockwise";
        SpinDirection[SpinDirection["CounterClockwise"] = 1] = "CounterClockwise";
    })(SpinDirection || (SpinDirection = {}));
    ;

    var Propeller = (function (_super) {
        __extends(Propeller, _super);
        function Propeller(finsCount) {
            _super.call(this);
            this._finsCount = finsCount;
            this._spinDirection = 0 /* Clockwise */;
        }
        Object.defineProperty(Propeller.prototype, "finsCount", {
            get: function () {
                return this._finsCount;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Propeller.prototype, "spinDirection", {
            get: function () {
                return this._spinDirection === 0 /* Clockwise */ ? "Clockwise" : "CounterClockwise";
            },
            enumerable: true,
            configurable: true
        });

        Propeller.prototype.changeSpinDirection = function () {
            var isClockwise = (this._spinDirection === 0 /* Clockwise */);
            this._spinDirection = SpinDirection[isClockwise ? "CounterClockwise" : "Clockwise"];
        };

        Propeller.prototype.produceAcceleration = function () {
            return (this._spinDirection === 0 /* Clockwise */ ? 1 : -1) * this._finsCount;
        };
        return Propeller;
    })(PropulsionUnits.PropulsionUnit);
    PropulsionUnits.Propeller = Propeller;
})(PropulsionUnits || (PropulsionUnits = {}));
//# sourceMappingURL=Propeller.js.map
