var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Vehicles;
(function (Vehicles) {
    "use strict";

    var AirVehicle = (function (_super) {
        __extends(AirVehicle, _super);
        function AirVehicle(propellingNozzle) {
            _super.call(this, [propellingNozzle]);
        }
        AirVehicle.prototype.switchAfterBurner = function () {
            this.propulsionUnits.forEach(function (propellingNozzle) {
                propellingNozzle.afterBurnerSwitch.toggleCondition();
            });
        };
        return AirVehicle;
    })(Vehicles.Vehicle);
    Vehicles.AirVehicle = AirVehicle;
})(Vehicles || (Vehicles = {}));
//# sourceMappingURL=AirVehicle.js.map
