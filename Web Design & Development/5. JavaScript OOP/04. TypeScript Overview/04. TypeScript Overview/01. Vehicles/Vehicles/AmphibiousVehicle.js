var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Vehicles;
(function (Vehicles) {
    "use strict";

    var AmphibiousVehicle = (function (_super) {
        __extends(AmphibiousVehicle, _super);
        function AmphibiousVehicle(wheels, propellers) {
            _super.call(this, wheels);
            this._wheels = wheels;
            this._propellers = propellers;
        }
        AmphibiousVehicle.prototype.changePropulsionUnits = function () {
            this.propulsionUnits = (this.propulsionUnits === this._wheels) ? this._propellers : this._wheels;
        };
        return AmphibiousVehicle;
    })(Vehicles.Vehicle);
    Vehicles.AmphibiousVehicle = AmphibiousVehicle;
})(Vehicles || (Vehicles = {}));
//# sourceMappingURL=AmphibiousVehicle.js.map
