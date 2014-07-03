var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Vehicles;
(function (Vehicles) {
    "use strict";

    var LandVehicle = (function (_super) {
        __extends(LandVehicle, _super);
        function LandVehicle(w1, w2, w3, w4) {
            _super.call(this, [w1, w2, w3, w4]);
        }
        return LandVehicle;
    })(Vehicles.Vehicle);
    Vehicles.LandVehicle = LandVehicle;
})(Vehicles || (Vehicles = {}));
//# sourceMappingURL=LandVehicle.js.map
