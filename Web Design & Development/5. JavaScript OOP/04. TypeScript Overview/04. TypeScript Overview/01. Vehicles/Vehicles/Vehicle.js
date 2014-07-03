var Vehicles;
(function (Vehicles) {
    "use strict";

    // abstract class
    var Vehicle = (function () {
        function Vehicle(propulsionUnits) {
            this._propulsionUnits = propulsionUnits;
            this._speed = 0;
        }
        Object.defineProperty(Vehicle.prototype, "propulsionUnits", {
            get: function () {
                return this._propulsionUnits;
            },
            set: function (newPropulsionUnits) {
                this._propulsionUnits = newPropulsionUnits;
            },
            enumerable: true,
            configurable: true
        });


        Object.defineProperty(Vehicle.prototype, "speed", {
            get: function () {
                return this._speed;
            },
            enumerable: true,
            configurable: true
        });

        Vehicle.prototype.accelerate = function () {
            if (!this._propulsionUnits) {
                return;
            }

            var sum = 0;
            this._propulsionUnits.forEach(function (propulsionUnit) {
                sum += propulsionUnit.produceAcceleration();
            });
            this._speed = sum;

            return this._speed;
        };
        return Vehicle;
    })();
    Vehicles.Vehicle = Vehicle;
})(Vehicles || (Vehicles = {}));
//# sourceMappingURL=Vehicle.js.map
