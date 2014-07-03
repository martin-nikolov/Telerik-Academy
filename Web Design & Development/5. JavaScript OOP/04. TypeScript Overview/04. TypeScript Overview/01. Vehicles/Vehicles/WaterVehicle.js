var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Vehicles;
(function (Vehicles) {
    "use strict";

    var WaterVehicle = (function (_super) {
        __extends(WaterVehicle, _super);
        function WaterVehicle() {
            var propellers = [];
            for (var _i = 0; _i < (arguments.length - 0); _i++) {
                propellers[_i] = arguments[_i + 0];
            }
            _super.call(this, propellers);
        }
        WaterVehicle.prototype.changeSpinDirection = function () {
            this.propulsionUnits.forEach(function (propeller) {
                propeller.changeSpinDirection();
            });
        };
        return WaterVehicle;
    })(Vehicles.Vehicle);
    Vehicles.WaterVehicle = WaterVehicle;
})(Vehicles || (Vehicles = {}));
//# sourceMappingURL=WaterVehicle.js.map
