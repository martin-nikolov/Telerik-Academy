var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var PropulsionUnits;
(function (PropulsionUnits) {
    "use strict";

    var PropellingNozzle = (function (_super) {
        __extends(PropellingNozzle, _super);
        function PropellingNozzle(powerUnits) {
            _super.call(this);
            this._powerUnits = powerUnits;
            this._afterBurnerSwitch = new PropulsionUnits.AfterBurnerSwitch();
        }
        Object.defineProperty(PropellingNozzle.prototype, "powerUnits", {
            get: function () {
                return this._powerUnits;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(PropellingNozzle.prototype, "afterBurnerSwitch", {
            get: function () {
                return this._afterBurnerSwitch;
            },
            enumerable: true,
            configurable: true
        });

        PropellingNozzle.prototype.produceAcceleration = function () {
            return (this._afterBurnerSwitch.isActive ? 2 : 1) * this._powerUnits;
        };
        return PropellingNozzle;
    })(PropulsionUnits.PropulsionUnit);
    PropulsionUnits.PropellingNozzle = PropellingNozzle;
})(PropulsionUnits || (PropulsionUnits = {}));
//# sourceMappingURL=PropellingNozzle.js.map
