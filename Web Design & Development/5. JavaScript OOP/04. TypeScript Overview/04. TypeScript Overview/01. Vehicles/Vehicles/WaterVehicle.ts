module Vehicles {
    "use strict";

    export class WaterVehicle extends Vehicle implements Interfaces.IChangeSpinDirection {
        constructor(...propellers: PropulsionUnits.Propeller[]) {
            super(propellers);
        }

        public changeSpinDirection(): void {
            this.propulsionUnits.forEach(function (propeller: PropulsionUnits.Propeller): void {
                (<PropulsionUnits.Propeller>propeller).changeSpinDirection();
            });
        }
    }
} 