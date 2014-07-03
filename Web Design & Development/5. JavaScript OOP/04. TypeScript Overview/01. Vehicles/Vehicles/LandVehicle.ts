module Vehicles {
    "use strict";

    export class LandVehicle extends Vehicle {
        constructor(w1: PropulsionUnits.Wheel, w2: PropulsionUnits.Wheel, w3: PropulsionUnits.Wheel, w4: PropulsionUnits.Wheel) {
            super([w1, w2, w3, w4]);
        }
    }
}